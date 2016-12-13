using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CharBox
{
    #region PanelDesigner
    /// <summary>
    /// 面板设计器基类，用于扩展应接收滚动消息的 System.Windows.Forms.Control 的设计模式行为。
    /// </summary>
    internal class PanelDesigner : ScrollableControlDesigner
    {/// <summary>
     /// 面板设计器
     /// </summary>
        public PanelDesigner()
        {
            base.AutoResizeHandles = true;
        }
        /// <summary>
        /// 画边框
        /// </summary>
        /// <param name="graphics"></param>
        protected virtual void DrawBorder(Graphics graphics)
        {
            Panel component = (Panel)base.Component;
            if ((component != null) && component.Visible)
            {
                Pen borderPen = this.BorderPen;
                Rectangle clientRectangle = this.Control.ClientRectangle;
                clientRectangle.Width--;
                clientRectangle.Height--;
                graphics.DrawRectangle(borderPen, clientRectangle);
                borderPen.Dispose();
            }
        }
        /// <summary>
        /// 涂料装饰
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            Panel component = (Panel)base.Component;
            if (component.BorderStyle == BorderStyle.None)
            {
                this.DrawBorder(pe.Graphics);
            }
            base.OnPaintAdornments(pe);
        }
        /// <summary>
        /// 边界的笔
        /// </summary>
        protected Pen BorderPen
        {
            get
            {
                Color color = (this.Control.BackColor.GetBrightness() < 0.5) ? ControlPaint.Light(this.Control.BackColor) : ControlPaint.Dark(this.Control.BackColor);
                Pen pen = new Pen(color);
                pen.DashStyle = DashStyle.Dash;
                return pen;
            }
        }
    }

    #endregion
}
