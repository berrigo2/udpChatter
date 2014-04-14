using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace chatter
{
    public partial class Form1 : Form
    {
        #region comments
        // Create a socket object. This is the fundamental device used to network
        // communications. When creating this object we specify:
        // Internetwork: We use the internet communications protocol
        // Dgram: We use datagrams or broadcast to everyone rather than send to
        // a specific listener
        // UDP: the messages are to be formated as user datagram protocal.
        // The last two seem to be a bit redundant.
        #endregion
        Socket sendingSocket;
        #region comments
        // create an address object and populate it with the IP address that we will use
        // in sending at data to. This particular address ends in 255 meaning we will send
        // to all devices whose address begins with 192.168.2.
        // However, objects of class IPAddress have other properties. In particular, the
        // property AddressFamily. Does this constructor examine the IP address being
        // passed in, determine that this is IPv4 and set the field. If so, the notes
        // in the help file should say so.
        #endregion
        IPAddress sendToAddress;
        IPAddress localIpAddress;
        Int32 sendPort;
        Int32 listenPort;
        #region comments
        // IPEndPoint appears (to me) to be a class defining the first or final data
        // object in the process of sending or receiving a communications packet. It
        // holds the address to send to or receive from and the port to be used. We create
        // this one using the address just built in the previous line, and adding in the
        // port number. As this will be a broadcase message, I don't know what role the
        // port number plays in this.
        #endregion
        IPEndPoint sendingEndPoint;
        #region comments
        // The below three lines of code will not work. They appear to load
        // the variable broadcast_string witha broadcast address. But that
        // address causes an exception when performing the send.
        //
        //string broadcast_string = IPAddress.Broadcast.ToString();
        //Console.WriteLine("broadcast_string contains {0}", broadcast_string);
        //send_to_address = IPAddress.Parse(broadcast_string);
        #endregion
        UdpClient listener;
        BackgroundWorker listenLoop;

        public Form1()
        {
            InitializeComponent();
            listenPort = 6050;
            portBox.ValueChanged += sendToInfoChanged;
            ipBox.Text = "127.0.0.1";

            portBox.Value = 6050;

            sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            convoBox.AppendText("type in lower box and press send to chat\n");
            sendingSocket.Blocking = false;
            listener = new UdpClient(listenPort, AddressFamily.InterNetwork);
            listenLoop = new BackgroundWorker();
            localIpAddress = getLocalIp();
            //sendingEndPoint = new IPEndPoint(sendToAddress, sendPort);
            listenLoop.DoWork += delegate
            {
                while (true)
                {
                    var recieve_byte_array = listener.Receive(ref sendingEndPoint);
                    string recieved = Encoding.ASCII.GetString(recieve_byte_array, 0, recieve_byte_array.Length);
                    convoBox.Invoke((MethodInvoker)(() => convoBox.AppendText("remote: " + recieved + "\n")));
                }
            };
            listenLoop.RunWorkerAsync();
        }

        private IPAddress getLocalIp()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                convoBox.AppendText("local: " + typingBox.Text + "\n");
                var bytes_to_send = Encoding.ASCII.GetBytes(typingBox.Text);
                typingBox.Text = "";
                sendingSocket.SendTo(bytes_to_send, sendingEndPoint);
            }
            catch (Exception ex)
            {
                convoBox.AppendText("failed to send string:" + ex.GetHashCode().ToString() + "\n");
            }
        }

        private void sendToInfoChanged(object sender, EventArgs e)
        {
            try
            {
                sendToAddress = IPAddress.Parse(ipBox.Text);
                sendingEndPoint = new IPEndPoint(sendToAddress, Convert.ToInt32(portBox.Value));
            }
            catch { }
        }

        private void portBox_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                sendPort = Convert.ToInt32(portBox.Value);
            }
            catch { }
        }
    }
}
