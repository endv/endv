using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Windows.Forms;

namespace XYJ_Chat_Sever
{
    class ImageSending
    {
        public void SendImage(String IP,int Port,Image image)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                image.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imgbyte = memStream.ToArray();
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress ip = IPAddress.Parse(IP);
                IPEndPoint ipendpoint = new IPEndPoint(ip, Port);
                socket.SendTo(imgbyte, ipendpoint);
                socket.Close();
            }
            catch (Exception)
            {
               // MessageBox.Show("¡¨Ω”÷–∂œ£°","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
