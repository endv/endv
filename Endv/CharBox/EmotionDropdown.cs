using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace CharBox
{
    public partial class EmotionDropdown : UserControl// RichTextBox//FlowLayoutSettings// UserControl
    {
        private Popup _popup; 
        void  AddRangex() 
        { 

            this.emotionContainer1.Items.AddRange(new CharBox.EmotionItem[] {

                new EmotionItem("0.gif", global::CharBox.Properties.Resources._0),
                new EmotionItem("1.gif", Properties.Resources._1),
                new CharBox.EmotionItem("2.gif", global::CharBox.Properties.Resources._2),
                new CharBox.EmotionItem("3.gif", global::CharBox.Properties.Resources._3),
                new CharBox.EmotionItem("4.gif", global::CharBox.Properties.Resources._4),
                new CharBox.EmotionItem("5.gif", global::CharBox.Properties.Resources._5),
                new CharBox.EmotionItem("6.gif", global::CharBox.Properties.Resources._6),
                new CharBox.EmotionItem("7.gif", global::CharBox.Properties.Resources._7),
                new CharBox.EmotionItem("8.gif", global::CharBox.Properties.Resources._8),
                new CharBox.EmotionItem("9.gif", global::CharBox.Properties.Resources._9),
                new CharBox.EmotionItem("10.gif", global::CharBox.Properties.Resources._10),
                new CharBox.EmotionItem("11.gif", global::CharBox.Properties.Resources._11),
                new CharBox.EmotionItem("12.gif", global::CharBox.Properties.Resources._12),
                new CharBox.EmotionItem("13.gif", global::CharBox.Properties.Resources._13),
                new CharBox.EmotionItem("14.gif", global::CharBox.Properties.Resources._14),
                new CharBox.EmotionItem("15.gif", global::CharBox.Properties.Resources._15),
                new CharBox.EmotionItem("16.gif", global::CharBox.Properties.Resources._16),
                new CharBox.EmotionItem("17.gif", global::CharBox.Properties.Resources._17),
                new CharBox.EmotionItem("18.gif", global::CharBox.Properties.Resources._18),
                new CharBox.EmotionItem("19.gif", global::CharBox.Properties.Resources._19),
                new CharBox.EmotionItem("20.gif", global::CharBox.Properties.Resources._20),
                new CharBox.EmotionItem("21.gif", global::CharBox.Properties.Resources._21),
                new CharBox.EmotionItem("22.gif", global::CharBox.Properties.Resources._22),
                new CharBox.EmotionItem("23.gif", global::CharBox.Properties.Resources._23),
                new CharBox.EmotionItem("24.gif", global::CharBox.Properties.Resources._24),
                new CharBox.EmotionItem("27.gif", global::CharBox.Properties.Resources._27),
                new CharBox.EmotionItem("25.gif", global::CharBox.Properties.Resources._25),
                new CharBox.EmotionItem("26.gif", global::CharBox.Properties.Resources._26),
                new CharBox.EmotionItem("28.gif", global::CharBox.Properties.Resources._28),
                new CharBox.EmotionItem("29.gif", global::CharBox.Properties.Resources._29),
                new CharBox.EmotionItem("30.gif", global::CharBox.Properties.Resources._30),
                new CharBox.EmotionItem("31.gif", global::CharBox.Properties.Resources._31),
                new CharBox.EmotionItem("32.gif", global::CharBox.Properties.Resources._32),
                new CharBox.EmotionItem("33.gif", global::CharBox.Properties.Resources._33),
                new CharBox.EmotionItem("34.gif", global::CharBox.Properties.Resources._34),
                new CharBox.EmotionItem("35.gif", global::CharBox.Properties.Resources._35),
                new CharBox.EmotionItem("36.gif", global::CharBox.Properties.Resources._36),
                new CharBox.EmotionItem("37.gif", global::CharBox.Properties.Resources._37),
                new CharBox.EmotionItem("38.gif", global::CharBox.Properties.Resources._38),
                new CharBox.EmotionItem("39.gif", global::CharBox.Properties.Resources._39),
                new CharBox.EmotionItem("40.gif", global::CharBox.Properties.Resources._40),
                new CharBox.EmotionItem("41.gif", global::CharBox.Properties.Resources._41),
                new CharBox.EmotionItem("42.gif", global::CharBox.Properties.Resources._42),
                new CharBox.EmotionItem("43.gif", global::CharBox.Properties.Resources._43),
                new CharBox.EmotionItem("44.gif", global::CharBox.Properties.Resources._44),
                new CharBox.EmotionItem("45.gif", global::CharBox.Properties.Resources._45),
                new CharBox.EmotionItem("46.gif", global::CharBox.Properties.Resources._46),
                new CharBox.EmotionItem("47.gif", global::CharBox.Properties.Resources._47),
                new CharBox.EmotionItem("48.gif", global::CharBox.Properties.Resources._48),
                new CharBox.EmotionItem("49.gif", global::CharBox.Properties.Resources._49),
                new CharBox.EmotionItem("50.gif", global::CharBox.Properties.Resources._50),
                new CharBox.EmotionItem("51.gif", global::CharBox.Properties.Resources._51),
                new CharBox.EmotionItem("52.gif", global::CharBox.Properties.Resources._52),
                new CharBox.EmotionItem("53.gif", global::CharBox.Properties.Resources._53),
                new CharBox.EmotionItem("54.gif", global::CharBox.Properties.Resources._54),
                new CharBox.EmotionItem("55.gif", global::CharBox.Properties.Resources._55),
                new CharBox.EmotionItem("56.gif", global::CharBox.Properties.Resources._56),
                new CharBox.EmotionItem("57.gif", global::CharBox.Properties.Resources._57),
                new CharBox.EmotionItem("58.gif", global::CharBox.Properties.Resources._58),
                new CharBox.EmotionItem("59.gif", global::CharBox.Properties.Resources._59),
                new CharBox.EmotionItem("60.gif", global::CharBox.Properties.Resources._60),
                new CharBox.EmotionItem("61.gif", global::CharBox.Properties.Resources._61),
                new CharBox.EmotionItem("62.gif", global::CharBox.Properties.Resources._62),
                new CharBox.EmotionItem("63.gif", global::CharBox.Properties.Resources._63),
                new CharBox.EmotionItem("64.gif", global::CharBox.Properties.Resources._64),
                new CharBox.EmotionItem("65.gif", global::CharBox.Properties.Resources._65),
                new CharBox.EmotionItem("66.gif", global::CharBox.Properties.Resources._66),
                new CharBox.EmotionItem("67.gif", global::CharBox.Properties.Resources._67),
                new CharBox.EmotionItem("68.gif", global::CharBox.Properties.Resources._68),
                new CharBox.EmotionItem("69.gif", global::CharBox.Properties.Resources._69),
                new CharBox.EmotionItem("70.gif", global::CharBox.Properties.Resources._70),
                new CharBox.EmotionItem("71.gif", global::CharBox.Properties.Resources._71),
                new CharBox.EmotionItem("72.gif", global::CharBox.Properties.Resources._72),
                new CharBox.EmotionItem("73.gif", global::CharBox.Properties.Resources._73),
                new CharBox.EmotionItem("74.gif", global::CharBox.Properties.Resources._74),
                new CharBox.EmotionItem("75.gif", global::CharBox.Properties.Resources._75),
                new CharBox.EmotionItem("76.gif", global::CharBox.Properties.Resources._76),
                new CharBox.EmotionItem("77.gif", global::CharBox.Properties.Resources._77),
                new CharBox.EmotionItem("78.gif", global::CharBox.Properties.Resources._78),
                new CharBox.EmotionItem("79.gif", global::CharBox.Properties.Resources._79),
                new CharBox.EmotionItem("80.gif", global::CharBox.Properties.Resources._80),
                new CharBox.EmotionItem("81.gif", global::CharBox.Properties.Resources._81),
                new CharBox.EmotionItem("82.gif", global::CharBox.Properties.Resources._82),
                new CharBox.EmotionItem("83.gif", global::CharBox.Properties.Resources._83),
                new CharBox.EmotionItem("84.gif", global::CharBox.Properties.Resources._84),
                new CharBox.EmotionItem("85.gif", global::CharBox.Properties.Resources._85),
                new CharBox.EmotionItem("86.gif", global::CharBox.Properties.Resources._86),
                new CharBox.EmotionItem("87.gif", global::CharBox.Properties.Resources._87),
                new CharBox.EmotionItem("88.gif", global::CharBox.Properties.Resources._88),
                new CharBox.EmotionItem("89.gif", global::CharBox.Properties.Resources._89),
                new CharBox.EmotionItem("90.gif", global::CharBox.Properties.Resources._90),
                new CharBox.EmotionItem("91.gif", global::CharBox.Properties.Resources._91),
                new CharBox.EmotionItem("92.gif", global::CharBox.Properties.Resources._92),
                new CharBox.EmotionItem("93.gif", global::CharBox.Properties.Resources._93),
                new CharBox.EmotionItem("94.gif", global::CharBox.Properties.Resources._94),
                new CharBox.EmotionItem("95.gif", global::CharBox.Properties.Resources._95),
                new CharBox.EmotionItem("96.gif", global::CharBox.Properties.Resources._96),
                new CharBox.EmotionItem("97.gif", global::CharBox.Properties.Resources._97),
                new CharBox.EmotionItem("98.gif", global::CharBox.Properties.Resources._98),
                new CharBox.EmotionItem("99.gif", global::CharBox.Properties.Resources._99),
                new CharBox.EmotionItem("100.gif", global::CharBox.Properties.Resources._100),
                new CharBox.EmotionItem("101.gif", global::CharBox.Properties.Resources._101),
                new CharBox.EmotionItem("102.gif", global::CharBox.Properties.Resources._102),
                new CharBox.EmotionItem("103.gif", global::CharBox.Properties.Resources._103),
                new CharBox.EmotionItem("104.gif", global::CharBox.Properties.Resources._104),
                new CharBox.EmotionItem("105.gif", global::CharBox.Properties.Resources._105),
                new CharBox.EmotionItem("106.gif", global::CharBox.Properties.Resources._106),
                new CharBox.EmotionItem("107.gif", global::CharBox.Properties.Resources._107),
                new CharBox.EmotionItem("108.gif", global::CharBox.Properties.Resources._108),
                new CharBox.EmotionItem("109.gif", global::CharBox.Properties.Resources._109),
                new CharBox.EmotionItem("110.gif", global::CharBox.Properties.Resources._110),
                new CharBox.EmotionItem("111.gif", global::CharBox.Properties.Resources._111),
                new CharBox.EmotionItem("112.gif", global::CharBox.Properties.Resources._112),
                new CharBox.EmotionItem("113.gif", global::CharBox.Properties.Resources._113),
                new CharBox.EmotionItem("114.gif", global::CharBox.Properties.Resources._114),
                new CharBox.EmotionItem("115.gif", global::CharBox.Properties.Resources._115),
                new CharBox.EmotionItem("116.gif", global::CharBox.Properties.Resources._116),
                new CharBox.EmotionItem("117.gif", global::CharBox.Properties.Resources._117),
                new CharBox.EmotionItem("118.gif", global::CharBox.Properties.Resources._118),
                new CharBox.EmotionItem("119.gif", global::CharBox.Properties.Resources._119),
                new CharBox.EmotionItem("120.gif", global::CharBox.Properties.Resources._120),
                new CharBox.EmotionItem("121.gif", global::CharBox.Properties.Resources._121),
                new CharBox.EmotionItem("122.gif", global::CharBox.Properties.Resources._122),
                new CharBox.EmotionItem("123.gif", global::CharBox.Properties.Resources._123),
                new CharBox.EmotionItem("124.gif", global::CharBox.Properties.Resources._124),
                new CharBox.EmotionItem("125.gif", global::CharBox.Properties.Resources._125),
                new CharBox.EmotionItem("126.gif", global::CharBox.Properties.Resources._126),
                new CharBox.EmotionItem("127.gif", global::CharBox.Properties.Resources._127),
                new CharBox.EmotionItem("128.gif", global::CharBox.Properties.Resources._128),
                new CharBox.EmotionItem("129.gif", global::CharBox.Properties.Resources._129),
                new CharBox.EmotionItem("130.gif", global::CharBox.Properties.Resources._130),
                new CharBox.EmotionItem("131.gif", global::CharBox.Properties.Resources._131),
                new CharBox.EmotionItem("132.gif", global::CharBox.Properties.Resources._132),
                new CharBox.EmotionItem("133.gif", global::CharBox.Properties.Resources._133),
                new CharBox.EmotionItem("134.gif", global::CharBox.Properties.Resources._134)
            }); 


        }
        public EmotionDropdown()
        {
            InitializeComponent();
      
            AddRangex();
          
            _popup = new Popup(this);

            EmotionContainer.ItemClick +=
                new EmotionItemMouseEventHandler(EmotionContainerItemClick); 
        }
        /// <summary>
        ///  单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EmotionContainerItemClick( object sender, EmotionItemMouseClickEventArgs e)
        {
            _popup.Close();
        }
        /// <summary>
        /// 表情容器
        /// </summary>
        public EmotionContainer EmotionContainer
        {
            get { return emotionContainer1; }
        }

        public void Show(Control owner)
        {
            _popup.Show(owner, true);
        }

      
    }
}
