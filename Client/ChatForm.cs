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
namespace Client
{
    public partial class ChatForm : Form
    {
        private bool connected = false;
        private Thread listener = null;
        private struct MyClient
        {
            public string username;
            public string key;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };
        private MyClient newClient;
        private Task send = null;
        private bool exit = false;

        public ChatForm()
        {
            InitializeComponent();
        }

        private void checkLogAndClear(string mssg = "")
        {
            if (!exit)
            {
                logChatHistory.Invoke((MethodInvoker)delegate
                {
                    if (mssg.Length > 0)
                    {
                        logChatHistory.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), mssg, Environment.NewLine));
                        //in ra thời gian thực + message
                        //vd: [9:00] username: hello
                    }
                    else
                    {
                        logChatHistory.Clear();
                    }
                });
            }
        }

        private void bttClearDisplayChat_Click(object sender, EventArgs e)
        {
            checkLogAndClear();
        }

        private void checkbttConnect(bool status)
        {
            if (!exit)
            {
                bttConnect.Invoke((MethodInvoker)delegate
                {
                    connected = status;
                    if (status)
                    {
                        //trường hợp mới bắt đầu connect
                        bttConnect.Text = "STOP CONNECTION";
                        //khóa chỉnh sửa address/port/username/key room khi còn đang trong trạng thái Connect
                        txtAdress.Enabled = false;
                        txtPort.Enabled = false;
                        txtUsername.Enabled = false;
                        txtKey.Enabled = false;
                        checkLogAndClear("You are now connected");
                    }
                    else
                    {
                        //trường hợp ngắt kết nối connect
                        bttConnect.Text = "START";
                        //cho phép điều chỉnh
                        txtAdress.Enabled = true;
                        txtPort.Enabled = true;
                        txtUsername.Enabled = true;
                        txtKey.Enabled = true;
                        checkLogAndClear("You are now disconnected");
                    }
                });
            }
        }

        private void read1 (IAsyncResult result)
        {
            int bytesLength = 0;
            if (newClient.client.Connected)
            {
                try
                {
                    bytesLength = newClient.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
            if (bytesLength > 0)
            {
                newClient.data.AppendFormat("{0}", Encoding.UTF8.GetString(newClient.buffer, 0, bytesLength));
                try
                {
                    if (newClient.stream.DataAvailable)
                    {
                        newClient.stream.BeginRead(newClient.buffer, 0, newClient.buffer.Length, new AsyncCallback(read1), null);
                    }
                    else
                    {
                        checkLogAndClear(newClient.data.ToString());
                        newClient.data.Clear();
                        newClient.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    newClient.data.Clear();
                    checkLogAndClear(ex.Message);
                    newClient.handle.Set();
                }
            }
            else
            {
                newClient.client.Close();
                newClient.handle.Set();
            }
        }

        private void read2(IAsyncResult result)
        {
            int bytesLength = 0;
            if (newClient.client.Connected)
            {
                try
                {
                    bytesLength = newClient.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
            if (bytesLength > 0)
            {
                newClient.data.AppendFormat("{0}", Encoding.UTF8.GetString(newClient.buffer, 0, bytesLength));

                try
                {
                    if (newClient.stream.DataAvailable)
                    {
                        newClient.stream.BeginRead(newClient.buffer, 0, newClient.buffer.Length, new AsyncCallback(read2), newClient);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer();
                        Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(newClient.data.ToString());
                        //nhận serialize bên gửi, deserialize để dùng
                        //lưu vào mảng dictionary

                        //if-else kiểm tra ràng buộc json có chứa properties là username và key
                        if (!data.ContainsKey("status") || data["status"].Equals("authorized"))
                        {
                            checkbttConnect(true);
                        }
                        newClient.data.Clear();
                        newClient.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    newClient.data.Clear();
                    newClient.handle.Set();
                    checkLogAndClear(ex.Message);
                }
            }
            else
            {
                newClient.client.Close();
                newClient.handle.Set();
            }
        }

        private bool Authorize()
        {
            bool success = false;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("username", newClient.username);
            data.Add("key", newClient.key);
            JavaScriptSerializer json = new JavaScriptSerializer(); // feel free to use JSON serializer
            sendMsg(json.Serialize(data));
            while (newClient.client.Connected)
            {
                try
                {
                    newClient.stream.BeginRead(newClient.buffer, 0, newClient.buffer.Length, new AsyncCallback(read2), null);
                    newClient.handle.WaitOne();
                    if (connected)
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
            if (!connected)
            {
                checkLogAndClear("Unauthorized");
            }
            return success;
        }

        private void checkConnection(IPAddress ip, int port, string username, string key)
        {
            try
            {
                newClient = new MyClient();
                newClient.username = username;
                newClient.key = key;
                newClient.client = new TcpClient();
                newClient.client.Connect(ip, port);
                newClient.stream = newClient.client.GetStream();
                newClient.buffer = new byte[newClient.client.ReceiveBufferSize];
                newClient.data = new StringBuilder();
                newClient.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                if (Authorize())
                {
                    while (newClient.client.Connected)
                    {
                        try
                        {
                            newClient.stream.BeginRead(newClient.buffer, 0, newClient.buffer.Length, new AsyncCallback(read1), null);
                            newClient.handle.WaitOne();
                        }
                        catch (Exception ex)
                        {
                            checkLogAndClear(ex.Message);
                        }
                    }
                    newClient.client.Close();
                    checkbttConnect(false);
                }
            }
            catch (Exception ex)
            {
                checkLogAndClear(ex.Message);
            }
        }

        private void bttConnect_Click(object sender, EventArgs e)
        {
            if (connected) 
            { 
                newClient.client.Close(); 
            } //nếu nhấn vào button CONNECT sau khi đã kết nối -> button DISCONNECT
            else

            if (listener == null || !listener.IsAlive)
            {

                //IPEndPoint endPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
                string IPaddress = txtAdress.Text.Trim();
                string port = this.txtPort.Text.Trim();
                string username = txtUsername.Text.Trim();
                bool checkError = false;
                if (IPaddress.Length < 1)
                {
                    checkError = true;
                    checkLogAndClear("Tên đăng nhập không được để trống!");
                }
                if (port.Length < 1)
                {
                    checkError = true;
                    checkLogAndClear("Số Port không được để trống!");
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(this.txtPort.Text, "[^0-9999]"))
                {
                    checkError = true;
                    checkLogAndClear("Số Port không hợp lệ!");
                }
                if (username.Length < 1)
                {
                    checkError = true;
                    checkLogAndClear("Username không được để trống!");
                }
                if (!checkError)
                {
                    int intPort = Int32.Parse(port);
                    IPAddress ip = IPAddress.Parse(txtAdress.Text);
                    listener = new Thread(() => checkConnection(ip, intPort, username, txtKey.Text))
                    {
                        IsBackground = true
                    };
                    listener.Start();
                }
            }
        }

        private void Write(IAsyncResult result)
        {
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

        private void beginWrite(string message) 
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            if (newClient.client.Connected)
            {
                try
                {
                    newClient.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), newClient);
                }
                catch (Exception ex)
                {
                    checkLogAndClear(ex.Message);
                }
            }
        }

        private void sendMsg(string message)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => beginWrite(message));
            }
            else
            {
                send.ContinueWith(antecendent => beginWrite(message));
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
                    if (connected)
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
                if (connected)
                    sendMsg(string.Format("{0}: {1}", txtUsername.Text.Trim(), message)); //gửi khi nhấn nút send
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            if (connected)
                newClient.client.Close();
        }

    }
}
