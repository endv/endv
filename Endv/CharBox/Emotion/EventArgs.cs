using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CharBox
{
    /// <summary>
    /// 表情单击事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void EmotionItemMouseEventHandler(
        object sender,
        EmotionItemMouseClickEventArgs e);
    /// <summary>
    /// 表情单击事件参数, 为 System.Windows.Forms.Control.MouseUp、System.Windows.Forms.Control.MouseDown
    /// 和 System.Windows.Forms.Control.MouseMove 事件提供数据。
    /// </summary>
    public class EmotionItemMouseClickEventArgs : MouseEventArgs
    {
        private EmotionItem _item;
        /// <summary>
        /// 鼠标单击事件 MouseButtons 值之一，指示按下的鼠标按钮 鼠标按钮曾被按下的次数 
        /// 鼠标单击的 x y 坐标（以像素为单位）。
        /// 鼠标轮已转动的制动器数的有符号计数。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="e"></param>
        public EmotionItemMouseClickEventArgs(EmotionItem item, MouseEventArgs e)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            _item = item;
        }

        public EmotionItem Item
        {
            get { return _item; }
        }
    }
}
