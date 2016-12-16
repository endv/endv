namespace CSharpWinDemo
{
    partial class FormCSharpWinDemo
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonInsertEmotion = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.linkLabelCSharpWin = new System.Windows.Forms.LinkLabel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.radUseImageOle = new System.Windows.Forms.RadioButton();
            this.radUseDynamic = new System.Windows.Forms.RadioButton();
            this.radUseGifBox = new System.Windows.Forms.RadioButton();
            this.chatRichTextBox1 = new CSharpWin.ChatRichTextBox();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.radUseGifBox);
            this.panelBottom.Controls.Add(this.radUseDynamic);
            this.panelBottom.Controls.Add(this.radUseImageOle);
            this.panelBottom.Controls.Add(this.buttonInsertEmotion);
            this.panelBottom.Controls.Add(this.buttonAbout);
            this.panelBottom.Controls.Add(this.linkLabelCSharpWin);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 238);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(496, 57);
            this.panelBottom.TabIndex = 0;
            // 
            // buttonInsertEmotion
            // 
            this.buttonInsertEmotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsertEmotion.Location = new System.Drawing.Point(10, 31);
            this.buttonInsertEmotion.Name = "buttonInsertEmotion";
            this.buttonInsertEmotion.Size = new System.Drawing.Size(80, 23);
            this.buttonInsertEmotion.TabIndex = 17;
            this.buttonInsertEmotion.Text = "插入表情";
            this.buttonInsertEmotion.UseVisualStyleBackColor = true;
            this.buttonInsertEmotion.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Location = new System.Drawing.Point(409, 31);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout.TabIndex = 16;
            this.buttonAbout.Text = "关于...";
            this.buttonAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabelCSharpWin
            // 
            this.linkLabelCSharpWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCSharpWin.AutoSize = true;
            this.linkLabelCSharpWin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelCSharpWin.Location = new System.Drawing.Point(135, 34);
            this.linkLabelCSharpWin.Name = "linkLabelCSharpWin";
            this.linkLabelCSharpWin.Size = new System.Drawing.Size(258, 14);
            this.linkLabelCSharpWin.TabIndex = 15;
            this.linkLabelCSharpWin.TabStop = true;
            this.linkLabelCSharpWin.Text = "www.csharpwin.com(CS 程序员之窗)";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.chatRichTextBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(496, 238);
            this.panelTop.TabIndex = 1;
            // 
            // radUseImageOle
            // 
            this.radUseImageOle.AutoSize = true;
            this.radUseImageOle.Checked = true;
            this.radUseImageOle.Location = new System.Drawing.Point(12, 6);
            this.radUseImageOle.Name = "radUseImageOle";
            this.radUseImageOle.Size = new System.Drawing.Size(95, 16);
            this.radUseImageOle.TabIndex = 18;
            this.radUseImageOle.TabStop = true;
            this.radUseImageOle.Text = "使用ImageOle";
            this.radUseImageOle.UseVisualStyleBackColor = true;
            // 
            // radUseDynamic
            // 
            this.radUseDynamic.AutoSize = true;
            this.radUseDynamic.Location = new System.Drawing.Point(113, 6);
            this.radUseDynamic.Name = "radUseDynamic";
            this.radUseDynamic.Size = new System.Drawing.Size(89, 16);
            this.radUseDynamic.TabIndex = 19;
            this.radUseDynamic.Text = "使用Dynamic";
            this.radUseDynamic.UseVisualStyleBackColor = true;
            // 
            // radUseGifBox
            // 
            this.radUseGifBox.AutoSize = true;
            this.radUseGifBox.Location = new System.Drawing.Point(214, 6);
            this.radUseGifBox.Name = "radUseGifBox";
            this.radUseGifBox.Size = new System.Drawing.Size(83, 16);
            this.radUseGifBox.TabIndex = 20;
            this.radUseGifBox.Text = "使用GifBox";
            this.radUseGifBox.UseVisualStyleBackColor = true;
            // 
            // chatRichTextBox1
            // 
            this.chatRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.chatRichTextBox1.Name = "chatRichTextBox1";
            this.chatRichTextBox1.Size = new System.Drawing.Size(496, 238);
            this.chatRichTextBox1.TabIndex = 0;
            this.chatRichTextBox1.Text = "";
            // 
            // FormCSharpWinDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 295);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "FormCSharpWinDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在RichTextBox中插入Gif动画图片";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.LinkLabel linkLabelCSharpWin;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonInsertEmotion;
        private CSharpWin.ChatRichTextBox chatRichTextBox1;
        private System.Windows.Forms.RadioButton radUseGifBox;
        private System.Windows.Forms.RadioButton radUseDynamic;
        private System.Windows.Forms.RadioButton radUseImageOle;
    }
}

