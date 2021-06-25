using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Web.Script.Serialization; //sử dụng json lưu data
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Server
{
    public partial class ControlScreen : Form
    {
        private bool checkActive = false;
        private Thread listener = null;
        private int id = 0;
        private struct MyClient
        {
            public int id;
            public StringBuilder username;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer; //dùng để lưu trữ dữ liệu tạm thời
            public StringBuilder data;
            public EventWaitHandle handle;
        };
        private ConcurrentDictionary<long, MyClient> clients = new ConcurrentDictionary<long, MyClient>();
        private Task send = null;
        private bool exit = false;
        private Thread disconnect = null;

        public ControlScreen()
        {
            InitializeComponent();
        }

        private void checkLogAndClear(string mssg = "")
        {
            if (!exit)
            {
                logClientHistory.Invoke((MethodInvoker)delegate
                {
                    if (mssg.Length > 0)
                    {
                        logClientHistory.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), mssg, Environment.NewLine));
                        //in ra thời gian thực + tên user + message
                        //vd: [9:00] username: hello
                    }
                    else
                    {
                        logClientHistory.Clear();
                    }
                });
            }
        }

        private void bttClearDisplayChat_Click(object sender, EventArgs e)
        {
            checkLogAndClear();
        }

        private void checkBttStarttActive (bool status)
        {
            if (!exit)
            {
                bttStart.Invoke((MethodInvoker)delegate
                {
                    checkActive = status;
                    if (status)
                    {
                        //trường hợp mới bắt đầu connect
                        bttStart.Text = "STOP CONNECTION";
                        //khóa chỉnh sửa address/port/username/key room khi còn đang trong trạng thái Connect
                        txtAdress.Enabled = false;
                        port.Enabled = false;
                        txtUsername.Enabled = false;
                        txtKey.Enabled = false;
                        checkLogAndClear("Server has started");
                    }
                    else
                    {
                        //trường hợp ngắt kết nối connect
                        bttStart.Text = "START";
                        //cho phép điều chỉnh
                        txtAdress.Enabled = true;
                        port.Enabled = true;
                        txtUsername.Enabled = true;
                        txtKey.Enabled = true;
                        checkLogAndClear("Server has stopped");
                    }
                });
            }
        }

        private void addClientInfo (int id, string ussername)
        {
            if (!exit)
            {
                clientDataGridView.Invoke((MethodInvoker)delegate 
                {
                    string[] info = new string[]
                    {
                        id.ToString(), ussername
                    };
                    clientDataGridView.Rows.Add(info); //thêm thông tin user vào data grid view
                    totalLabel.Text = clientDataGridView.Rows.Count.ToString(); //hiển thị tổng số lượng user đang online(không tính server)
                });
            }
        }

        private void removeClientInfo (long id)
        {
            if (!exit)
            {
                clientDataGridView.Invoke((MethodInvoker)delegate
                {
                    //check method invoke
                    foreach (DataGridViewRow info in clientDataGridView.Rows)
                    {
                        if (info.Cells["IDentifier"].Value.ToString() == id.ToString())
                        {
                            clientDataGridView.Rows.RemoveAt(info.Index);
                            break;
                        }
                    }
                    totalLabel.Text = clientDataGridView.Rows.Count.ToString();
                });
            }
        }

        private void read1 (IAsyncResult result)
        {
            //parse result qua MyClient(obData)
            MyClient obData = (MyClient)result.AsyncState;
            int bytesLength = 0;
            if (obData.client.Connected) //kiểm tra connect, client connected thì chạy tiếp
            {
                try
                {
                    bytesLength = obData.stream.EndRead(result);
                    //đếm byte result (độ dài result)
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                    //in ra giờ + nội dung lỗi
                }
            }
            if (bytesLength > 0)
            {
                obData.data.AppendFormat("{0}", Encoding.UTF8.GetString(obData.buffer, 0, bytesLength));
                //lấy data từ obData
                //vd: "username":"client(name)","key:","abc"
                try
                {
                    if (obData.stream.DataAvailable)
                    {
                        obData.stream.BeginRead(obData.buffer, 0, obData.buffer.Length, new AsyncCallback(read1), obData);
                    }
                    else
                    {
                        //message có format: username + message
                        string message = string.Format("{0}: {1}", obData.username, obData.data);
                        checkLogAndClear(message);
                        sendMsg(message, obData.id);
                        obData.data.Clear();
                        obData.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obData.data.Clear();
                    checkLogAndClear(ex.Message);
                    obData.handle.Set();
                }
            }
            else
            {
                obData.client.Close();
                obData.handle.Set();
            }
        }

        private void read2(IAsyncResult result)
        {
            MyClient obData = (MyClient)result.AsyncState;
            int bytesLength = 0;
            if (obData.client.Connected)
            {
                try
                {
                    bytesLength = obData.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
            if (bytesLength > 0)
            {
                obData.data.AppendFormat("{0}", Encoding.UTF8.GetString(obData.buffer, 0, bytesLength));
                try
                {
                    if (obData.stream.DataAvailable)
                    {
                        obData.stream.BeginRead(obData.buffer, 0, obData.buffer.Length, new AsyncCallback(read2), obData);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer();
                        Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(obData.data.ToString());
                        //nhận serialize bên gửi, deserialize để dùng
                        //lưu vào mảng dictionary

                        //if-else kiểm tra ràng buộc json có chứa properties là username và key
                        if (!data.ContainsKey("username") || data["username"].Length < 1)
                        {
                            obData.client.Close();
                        }
                        else if (!data.ContainsKey("key") || !data["key"].Equals(txtKey.Text))
                        {
                            obData.client.Close();
                        }
                        else
                        {
                            obData.username.Append(data["username"].Length > 200 ? data["username"].Substring(0, 200) : data["username"]);
                            sendMsg("{\"status\": \"authorized\"}", obData);
                        }
                        obData.data.Clear();
                        obData.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obData.data.Clear();
                    checkLogAndClear(ex.Message);
                    obData.handle.Set();
                }
            }
            else
            {
                obData.client.Close();
                obData.handle.Set();
            }
        }
        private bool Authorize(MyClient obj)
        {
            bool success = false;
            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(read2), obj);
                    obj.handle.WaitOne();
                    if (obj.username.Length > 0)
                    {
                        success = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
            return success;
        }

        private void checkConnection (MyClient obj)
        {
            if (Authorize(obj))
            {
                clients.TryAdd(obj.id, obj);
                addClientInfo(obj.id, obj.username.ToString());
                string message = string.Format("User {0} đã kết nối thành công vào server", obj.username);
                //gửi message thông báo user [username] đã kết nối vào server
                checkLogAndClear(message);
                sendMsg(message, obj.id);
                while (obj.client.Connected)
                {
                    try
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(read1), obj);
                        obj.handle.WaitOne();
                    }
                    catch (Exception ex)
                    {
                        checkLogAndClear(ex.Message);
                    }
                }
                //check client disconnect, nếu có thì xóa info user tại dataGridView
                obj.client.Close();
                clients.TryRemove(obj.id, out MyClient rn);
                removeClientInfo(rn.id);
                message = string.Format("User {0} đã rời khỏi server", obj.username);
                checkLogAndClear(message);
                //gửi messenge này đến toàn bộ client hiện đang online
                sendMsg(message, rn.id);
            }
        }

        private void checkListener (IPAddress ip, int port)
        {
            // Parse the server's IP address out of the TextBox
            //IPAddress ipAddr = IPAddress.Parse(txtAdress.Text);
            // Create a new instance of the ChatServer object
            //ChatServer mainServer = new ChatServer(ipAddr);
            // Hook the StatusChanged event handler to mainServer_StatusChanged
            //ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
            // Start listening for connections
            //mainServer.StartListening();
            // Show that we started to listen for connections
            //txtLog.AppendText("Monitoring for connections...\r\n");

            TcpListener check;
            check = null;

            try
            {
                check = new TcpListener(ip, port);
                check.Start();
                checkBttStarttActive(true);
                while (checkActive)
                {
                    if (check.Pending())
                    {
                        try 
                        {
                            MyClient newClient = new MyClient();
                            newClient.id = id; //CHANGE LOGIN?SIGNUP LATERRRRRRRRRR
                            newClient.username = new StringBuilder();
                            newClient.client = check.AcceptTcpClient();
                            newClient.stream = newClient.client.GetStream();
                            newClient.buffer = new byte[newClient.client.ReceiveBufferSize];
                            newClient.data = new StringBuilder();
                            newClient.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                            Thread newThread = new Thread(() => checkConnection(newClient))
                            {
                                IsBackground = true
                            };
                            newThread.Start();
                            id++;
                        }
                        catch (Exception ex)
                        {
                            checkLogAndClear(ex.Message);
                        }
                    }
                    else { Thread.Sleep(1500); }
                }
                checkBttStarttActive(false);
            }
            catch (Exception ex)
            {
                checkLogAndClear(ex.Message);
            }
            finally
            {
                if (check != null)
                {
                    check.Server.Close(); //ngắt kết nối server
                }
            }
        }

        private void bttStart_Click(object sender, EventArgs e)
        {

            if (checkActive) { checkActive = false; }
            else

            if (listener == null || !listener.IsAlive)
            {

                //IPEndPoint endPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));

                string IPaddress = txtAdress.Text.Trim();
                string port = this.port.Text.Trim();
                string username = txtUsername.Text.Trim();
                bool checkError = false;
                if (IPaddress.Length < 1)
                {
                    checkError = true;
                    checkLogAndClear("IP Adress không được để trống!");
                }
                IPAddress ip = IPAddress.Parse(txtAdress.Text);
                if (port.Length < 1)
                {
                    checkError = true;
                    checkLogAndClear("Số Port không được để trống!");
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(this.port.Text, "[^0-9999]"))
                {
                    checkError = true;
                    checkLogAndClear("Số Port không hợp lệ!");
                }
                if (username.Length < 1)
                {
                    checkError = true;
                    checkLogAndClear("Username không được để trống!");
                }
                if (checkError == false)
                {
                    int intPort = Int32.Parse(port);
                    listener = new Thread(() => checkListener(ip, intPort))
                    {
                        IsBackground = true
                    };
                    listener.Start();
                }
            }
        }
        
        private void Write(IAsyncResult result)
        {
            MyClient newClient = (MyClient)result.AsyncState;
            if (newClient.client.Connected)
            {
                try
                {
                    newClient.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
        }

        private void beginWrite(string message, MyClient newClient) //send message to a client
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            if (newClient.client.Connected)
            {
                try
                {
                    newClient.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), newClient);
                }
                catch(Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
        }
        private void sendMsg(string message, MyClient obj)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => beginWrite(message, obj));
            }
            else
            {
                send.ContinueWith(antecendent => beginWrite(message, obj));
            }
        }

        private void beginWrite (string message, int id = -1) //gửi message tới tất cả client
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (KeyValuePair<long, MyClient> newClient in clients)
            {
                if (id != newClient.Value.id && newClient.Value.client.Connected)
                {
                    try
                    {
                        newClient.Value.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), newClient);
                    }
                    catch (Exception ex)
                    {
                        checkLogAndClear(ex.Message);
                    }
                }
            }
        }

        private void sendMsg(string message, int id = -1)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => beginWrite(message, id));
            }
            else
            {
                send.ContinueWith(antecendent => beginWrite(message, id));
            }
        }

        private void txtSendBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (txtSendBox.Text.Length > 0)
                {
                    string message = txtSendBox.Text;
                    txtSendBox.Clear();
                    checkLogAndClear(string.Format("You: {0}", message));
                    sendMsg(string.Format("{0}: {1}", txtUsername.Text.Trim(), message)); //gửi khi nhấn nút enter
                }
            }
        }
        private void bttSend_Click(object sender, EventArgs e)
        {
            if (txtSendBox.Text.Length > 0)
            {
                string message = txtSendBox.Text;
                txtSendBox.Clear();
                checkLogAndClear(string.Format("You: {0}", message));
                sendMsg(string.Format("{0}: {1}", txtUsername.Text.Trim(), message)); //gửi khi nhấn nút send
            }
        }

        private void Disconnect(int id = -1) // disconnect everyone
        {
            if (disconnect == null || !disconnect.IsAlive)
            {
                disconnect = new Thread(() =>
                {
                    if (id >= 0)
                    {
                        clients.TryGetValue(id, out MyClient obj);
                        obj.client.Close();
                        removeClientInfo(obj.id);
                    }
                    else
                    {
                        foreach (KeyValuePair<long, MyClient> obj in clients)
                        {
                            obj.Value.client.Close();
                            removeClientInfo(obj.Value.id);
                        }
                    }
                })
                {
                    IsBackground = true
                };
                disconnect.Start();
            }
        }
        private void ControlScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            checkActive = false;
            Disconnect();
        }
        

    }

}
