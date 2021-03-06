﻿using CharBox; 
using Endv.Screenshot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;//biaoqing
using System.Windows.Forms;

namespace RichTextBoxTest
{
    public partial class Emoticons : Form
    {
      
        #region  Emoticons

        #region 内存回收

        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]

        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        /// <summary> 
        /// 释放内存 
        /// </summary> 
        public static void ClearMemory()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }

        }

        #endregion

        public Emoticons()
        {
            InitializeComponent();
            // _emotion
            _emotion = new EmotionDropdown();
            _emotion.EmotionContainer.ItemClick += delegate (object mySender, CharBox.EmotionItemMouseClickEventArgs myE)
            {
                Sendbox_SendMessage.InsertImageUseGifBox(myE.Item.Image);//Gif
                //rtbox_SendMessage.InsertImage(myE.Item.Image);//流

                emotionItem = myE.Item.Text;

                emotionList.Add(emotionItem);
                //_emotion.Dispose();
            };
            InitEvents();//截图
                         //this. CheckedChanged += new System.EventHandler(this.chBox_ShowRtf_CheckedChanged);
            ChatRichTextBoxAllowDropDragEnter(Sendbox_SendMessage);
          
        }

        #region 日志记录
        /// <summary>
        /// 日志记录
        /// </summary>
        StringBuilder appendText;
        private int line;
        public void AppendText(string _text)
        {
            ++line;
            appendText = new StringBuilder();
            appendText.Append("<");
            appendText.Append("Line ");
            appendText.Append(line);
            appendText.Append(">");
            appendText.Append(" ");
            appendText.Append(_text);
            tbox_RtfCodes.Text += appendText.ToString();
            tbox_RtfCodes.ScrollToCaret();//滚动到光标处
        }
        #endregion 日志记录


        #region 截图 
        /// <summary>
        /// 截图
        /// </summary>
        private void InitEvents()
        {
            toolStripButton6.Click += delegate (object sender, EventArgs e)
            {
                //if (checkBoxHide.Checked)
                //{
                Hide();
                System.Threading.Thread.Sleep(10);
                //}
                CaptureImageTool capture = new CaptureImageTool();

                if (capture.ShowDialog() == DialogResult.OK)
                {
                    Image image = capture.Image;
                    //pictureBox.Width = image.Width;
                    //pictureBox.Height = image.Height;
                    //pictureBox.Image = image;
                    //rtbox_SendMessage.InsertImageUseGifBox(image);
                    Sendbox_SendMessage.InsertImage(image);
                    image.Dispose();
                    capture.Dispose();
                }

                if (!Visible)
                {
                    Show();
                }
            };
        }

        #endregion 截图
 
        #region 设置发送消息窗口的字体式样

        /// <summary>
        /// 设置发送消息窗口的字体式样
        /// </summary>
        private System.Windows.Forms.FontDialog fdlg_SendMessage;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.fdlg_SendMessage = new System.Windows.Forms.FontDialog();
            this.fdlg_SendMessage.ShowColor = true;
            if (DialogResult.OK == fdlg_SendMessage.ShowDialog())
            {
                Sendbox_SendMessage.Font = fdlg_SendMessage.Font;
                Sendbox_SendMessage.ForeColor = fdlg_SendMessage.Color;
            }

        }

        #endregion 设置发送消息窗口的字体式样

        #region 显示增加 Gif 表情
        EmotionDropdown _emotion;
        string emotionItem = null;
        List<string> emotionList = new List<string>();

        /// <summary>
        /// 显示增加 Gif 表情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _emotion.Show(toolStripButton1.Owner);
        }

        private EmotionItem getEmotionItem(string itemStr)
        {
            EmotionItem eitem = null;
            foreach (EmotionItem item in _emotion.EmotionContainer.Items)
            {
                if (item.Text.Equals(itemStr))
                {
                    eitem = item;
                    break;
                }
            }
            return eitem;
        }

        #endregion 显示增加 Gif 表情

        #region Message 协议

        class Message
        {
            string messageStr;
            public string MessageStr { get { return messageStr; } set { messageStr = value; } }
            List<string> face = new List<string>();
            public List<string> Face { get { return face; } set { face = value; } }

        }


        #endregion Message 协议

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ClearMemory();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            readbox_ShowMessage.Rtf = null;
        }
        #endregion  Emoticons
        //private void OnFrameChanged(object sender, EventArgs e)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new EventHandler(this.OnFrameChanged), new object[] { sender, e });
        //    }
        //    else
        //    {
        //        this.Invalidate();
        //    }
        //}
        ///  <summary>发消息，同时接收消息 </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// {{\rtf1\ansi\ansicpg936\deff0\deflang1033{\fonttbl{\f0\\fnil\fcharset0 宋体;}}
        /// {\pict\wmetafile8\picw10874\pich5001\picwgoal6165\pichgoal2835 FFF030000000000}
        private void btn_SendMessage_Click(object sender, EventArgs e)
        { 
            try
            {
                Message mm = new Message();  
                #region  readbox_ShowMessage 
                // 选择最后一个字节 
                readbox_ShowMessage.Select(readbox_ShowMessage.TextLength, 0);
              
                //foreach (string tempStr in mm.Face)
                //{
                //    EmotionItem emo = getEmotionItem(tempStr);
                //    if (emo != null)
                //    {
                //        readbox_ShowMessage.InsertImageUseGifBox(emo.Image);
                //        //mm.Face2.Remove(key);//移除原来的key键值对
                //        //mm.Face2.Add(emo.Image.ToString(), emo.Image);//新增key键值对
                //        emo = null;
                //    }
                //}

                 //this.readbox_ShowMessage.ScrollToCaret();//滚动到光标处
                 
                // 返回焦点到发送窗口
                //Sendbox_SendMessage.Focus();
                #endregion  readbox_ShowMessage
                ////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////
                #region  Sendbox_SendMessage

                //////////////// 发送消息 ///////////////////////


                readbox_ShowMessage.InsertTextAsRtf( "wwww.endv.cn "
                    + DateTime.Now.ToString() + "\r\n", new Font(this.Font, FontStyle.Underline | FontStyle.Bold), RtfColor.Blue, RtfColor.White);
                //mm.MessageStr = Sendbox_SendMessage.Text.Trim();//聊天内容

                foreach (string tempStr in emotionList)//获取表情列表
                {
                    EmotionItem emo = getEmotionItem(tempStr);//获取表情
                    if (emo != null)
                    {
                        readbox_ShowMessage.InsertImageUseGifBox(emo.Image);// 增加表情
                        //mm.Face.Add(emo.Text);//协议中增加表情
                        emo = null;
                    }
                }

                //this.readbox_ShowMessage.AppendText(mm.MessageStr );//+ "\r\n"

                ////  添加消息 （这会产生较大的内存，需要改进（如压缩、使用其它的途径传输））
                this.readbox_ShowMessage.AppendRtf(Sendbox_SendMessage.Rtf);//,null,0,0 InsertTextAsRtf AppendRtf 

                this.readbox_ShowMessage.ScrollToCaret();//滚动到光标处 
                //ClearMemory();
                // 清除 SendMessage 
                Sendbox_SendMessage.Rtf = string.Empty; 
            emotionList.Clear();
                mm = null;  
                #endregion  Sendbox_SendMessage 
            }
            catch (Exception _e)
            {
                MessageBox.Show("当发生错误 \"sending\" :\n\n" +
                    _e.Message, "发送错误");
            }
        }



        private void ChatRichTextBoxAllowDropDragEnter(ChatRichTextBox richTextBox1)
        {
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += delegate (object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files =
                        (string[])e.Data.GetData(DataFormats.FileDrop);
                    string file = files[0];

                    string ext =
                        System.IO.Path.GetExtension(file).ToLower();
                    if (ext == ".gif"
                        || ext == ".jpg" || ext == ".png"
                        || ext == ".bmp")
                        e.Effect = DragDropEffects.Copy;
                     
                    else

                       e.Effect = DragDropEffects.None;
                }
                else
                {
                    //如果是其它类型的文件，在这里改写成发送文件。
                    e.Effect = DragDropEffects.None;
                }
            };

            richTextBox1.DragDrop += delegate (object sender, DragEventArgs e) //  new DragEventHandler
            {
                string[] files =
              (string[])e.Data.GetData(DataFormats.FileDrop);
                string file = files[0];

                Clipboard.SetDataObject(Image.FromFile(file), false);
                richTextBox1.Paste();
            };

        }

 



    }
}
