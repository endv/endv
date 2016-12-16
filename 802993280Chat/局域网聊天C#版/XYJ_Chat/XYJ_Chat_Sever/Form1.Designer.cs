namespace XYJ_Chat_Sever
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.picOther = new System.Windows.Forms.PictureBox();
            this.picSelf = new System.Windows.Forms.PictureBox();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnSendImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelf)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShow
            // 
            this.txtShow.Location = new System.Drawing.Point(12, 65);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShow.Size = new System.Drawing.Size(403, 277);
            this.txtShow.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(160, 515);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(131, 35);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(160, 21);
            this.txtIP.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "对方IP：";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(12, 364);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSend.Size = new System.Drawing.Size(403, 128);
            this.txtSend.TabIndex = 5;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // picOther
            // 
            this.picOther.Location = new System.Drawing.Point(463, 59);
            this.picOther.Name = "picOther";
            this.picOther.Size = new System.Drawing.Size(273, 211);
            this.picOther.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOther.TabIndex = 6;
            this.picOther.TabStop = false;
            // 
            // picSelf
            // 
            this.picSelf.Location = new System.Drawing.Point(463, 281);
            this.picSelf.Name = "picSelf";
            this.picSelf.Size = new System.Drawing.Size(273, 211);
            this.picSelf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelf.TabIndex = 7;
            this.picSelf.TabStop = false;
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(463, 515);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(72, 27);
            this.btnVideo.TabIndex = 8;
            this.btnVideo.Text = "打开视频";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnSendImage
            // 
            this.btnSendImage.Location = new System.Drawing.Point(551, 515);
            this.btnSendImage.Name = "btnSendImage";
            this.btnSendImage.Size = new System.Drawing.Size(78, 27);
            this.btnSendImage.TabIndex = 9;
            this.btnSendImage.Text = "开始传输";
            this.btnSendImage.UseVisualStyleBackColor = true;
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "视频聊天";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(654, 517);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 24);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "停止视频";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 570);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendImage);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.picSelf);
            this.Controls.Add(this.picOther);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtShow);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "薛岩洁_局域网聊天";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSend;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.PictureBox picOther;
        private System.Windows.Forms.PictureBox picSelf;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSendImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
    }
}

