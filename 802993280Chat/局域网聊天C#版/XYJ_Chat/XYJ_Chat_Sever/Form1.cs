using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Threading;
using System.Media;
using System.IO;

namespace XYJ_Chat_Sever
{
    public partial class Form1 : Form
    {
        public video Video ;
        Image VideoImage,ReceivedImage;
        ImageSending imgSender = new ImageSending();

        public int port = 11000;
        delegate void MyDelegate();
        String strInfo = "";
        String strIP = "";
        Thread mythread,threadVideo;
        SoundPlayer player = new SoundPlayer("msg.wav");
       
        bool result=false;

        public Form1()
        {
            InitializeComponent();
            Video = new video(picSelf.Handle, this.picSelf.Left, this.picSelf.Top, this.picSelf.Width, (short)this.picSelf.Height);
        }

       


        public void InvokeFun()
        {
            this.txtShow.Text += "\r\n" + strIP + "\r\n" + strInfo+"\r\n";
            txtShow.Select(txtShow.Text.Length, 0);
            txtShow.ScrollToCaret();
        }
       

        public void  StartListen()
        {
            while (true)
            {
                UdpClient udpclient = new UdpClient(port);
                IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, port);

                try
                {
                    byte[] bytes = udpclient.Receive(ref ipendpoint);
                    strIP = ipendpoint.Address.ToString() + "   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ": ";
                    strInfo = Encoding.GetEncoding("gb2312").GetString(bytes, 0, bytes.Length);
                    player.Play();
                    txtShow.Invoke(new MyDelegate(this.InvokeFun));
                    
                    strInfo = "";
                    strIP = "";
                    udpclient.Close();
                }
                catch (Exception ex)
                {
                    String s = ex.Message;
                }
                finally
                {
                    udpclient.Close();

                }
            }
        }



        public void VideoInvoke()
        {
            this.picOther.Image = this.ReceivedImage;
        }

        public void StartListenVideo()
        {
            while (true)
            {
                UdpClient udpclient2 = new UdpClient(12000);
                IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 12000);

                try
                {
                    byte[] bytes = udpclient2.Receive(ref ipendpoint);
                    MemoryStream ms = new MemoryStream(bytes);
                    ReceivedImage = Image.FromStream(ms);
                    this.picOther.Invoke(new MyDelegate(this.VideoInvoke));
                    udpclient2.Close();
                }
                catch (Exception ex)
                {
                    String s = ex.Message;
                }
                finally
                {
                    udpclient2.Close();

                }
            }
        }
           
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            VideoImage = Video.CatchVideo();
            imgSender.SendImage(txtIP.Text.Trim(), 12000, VideoImage);
        }



        public void Send(String IP, String strMessage)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ip = IPAddress.Parse(IP);
            byte[] message = Encoding.GetEncoding("gb2312").GetBytes(strMessage);
            IPEndPoint ipendpoint = new IPEndPoint(ip, 11000);
            socket.SendTo(message, ipendpoint);
            socket.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send(txtIP.Text.Trim(),txtSend.Text.Trim());
            txtShow.Text += "\r\n\r\n" + "我说：" + "(" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ")\r\n" + txtSend.Text.Trim();
            txtSend.Text = "";
            txtShow.Select(txtShow.Text.Length, 0);
            txtShow.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.skinEngine1.SkinFile = "vista1.ssk";
            mythread = new Thread(new ThreadStart(StartListen));
            mythread.IsBackground = true;
            mythread.Start();
            //timer1.Enabled = true;
            this.AcceptButton = btnSend;

            threadVideo = new Thread(new ThreadStart(this.StartListenVideo));
            threadVideo.IsBackground = true;
            threadVideo.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
    
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            Video.opVideo();
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
            //VideoImage = Video.CatchVideo();
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            picOther.Image = null;
        }

       
    }
}