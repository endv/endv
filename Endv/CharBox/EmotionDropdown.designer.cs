namespace CharBox
{ 
    partial class EmotionDropdown
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.emotionContainer1 = new CharBox.EmotionContainer();
            this.SuspendLayout();
            // 
            // emotionContainer1
            // 
            this.emotionContainer1.Columns = 10;
            this.emotionContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emotionContainer1.GridSize = 32;
            this.emotionContainer1.Location = new System.Drawing.Point(0, 0);
            this.emotionContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.emotionContainer1.Name = "emotionContainer1";
            this.emotionContainer1.TabIndex = 0;
            // 
            // EmotionDropdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.emotionContainer1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "EmotionDropdown";
            this.Size = new System.Drawing.Size(665, 470);
            this.ResumeLayout(false);

        }

        #endregion

        private CharBox.EmotionContainer emotionContainer1;




    }
}
