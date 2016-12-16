using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CSharpWin;
using System.IO;

namespace CSharpWinDemo
{
    public partial class FormCSharpWinDemo : Form
    {
        #region Fileds

        private SystemMenuNativeWindow _systemMenuNativeWindow;

        #endregion

        #region Constructors

        public FormCSharpWinDemo()
        {
            InitializeComponent();
            InitEvents();
        }

        #endregion

        #region Properties

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = string.Format(
                    "CS 程序员之窗 - {0}", value);
            }
        }

        #endregion

        #region Override Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (_systemMenuNativeWindow == null)
            {
                _systemMenuNativeWindow = new SystemMenuNativeWindow(this);
            }

            _systemMenuNativeWindow.AppendSeparator();
            _systemMenuNativeWindow.AppendMenu(
                1001,
                "访问 www.csharpwin.com",
                delegate(object sender, EventArgs e)
                {
                    Process.Start("www.csharpwin.com");
                });

            _systemMenuNativeWindow.AppendMenu(
                1000,
                "关于...(&A)",
                delegate(object sender, EventArgs e)
                {
                    AboutBoxCSharpWinDemo about = new AboutBoxCSharpWinDemo();
                    about.ShowDialog();
                });
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (_systemMenuNativeWindow != null)
            {
                _systemMenuNativeWindow.Dispose();
                _systemMenuNativeWindow = null;
            }
        }

        #endregion

        #region Private Methods

        private void InitEvents()
        {
            linkLabelCSharpWin.Click += delegate(object sender, EventArgs e)
            {
                Process.Start("www.csharpwin.com");
            };

            buttonAbout.Click += delegate(object sender, EventArgs e)
            {
                AboutBoxCSharpWinDemo about = new AboutBoxCSharpWinDemo();
                about.ShowDialog();
            };
        }

        private void ButtonAboutClick(object sender, EventArgs e)
        {
            AboutBoxCSharpWinDemo f = new AboutBoxCSharpWinDemo();
            f.ShowDialog();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //if (radUseImageOle.Checked)
            //{
            //    chatRichTextBox1.InsertImageUseImageOle(
            //        ".\\Face2\\11.gif");
            //}
            //else if (radUseDynamic.Checked)
            //{
            //    chatRichTextBox1.InsertImageUseDynamic(
            //        ".\\Face2\\12.gif");
            //}
            //else
            //{
                chatRichTextBox1.InsertImageUseGifBox(
                    ".\\Face2\\13.gif");
            //}
        }


        int i = 0;
        private void SaveFile(string value)
        {
            FileStream fs = new FileStream(
                "d:\\" + i.ToString() + ".txt",
                FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(value);
            sw.Flush();
            sw.Close();
            fs.Close();
            i++;
        }
    }
}