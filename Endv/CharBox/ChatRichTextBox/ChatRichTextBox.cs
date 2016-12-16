using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace CharBox
{

    public class ChatRichTextBox : RichTextBox, IDisposable//, IDisposable
    {
        #region 构造函数 
        /// <summary>
        /// 初始化文本颜色，创建RTF的颜色和字体家庭词典，和商店的水平和垂直分辨率RichTextBox的图形上下文。
        /// </summary>
        public ChatRichTextBox() : base()
        {
            this.DetectUrls = false;
            // 初始化默认文本和背景颜色
            textColor = RtfColor.Black;
            highlightColor = RtfColor.White;

            // 初始化字典映射颜色代码到定义
            rtfColor = new HybridDictionary();
            rtfColor.Add(RtfColor.Aqua, RtfColorDef.Aqua);
            rtfColor.Add(RtfColor.Black, RtfColorDef.Black);
            rtfColor.Add(RtfColor.Blue, RtfColorDef.Blue);
            rtfColor.Add(RtfColor.Fuchsia, RtfColorDef.Fuchsia);
            rtfColor.Add(RtfColor.Gray, RtfColorDef.Gray);
            rtfColor.Add(RtfColor.Green, RtfColorDef.Green);
            rtfColor.Add(RtfColor.Lime, RtfColorDef.Lime);
            rtfColor.Add(RtfColor.Maroon, RtfColorDef.Maroon);
            rtfColor.Add(RtfColor.Navy, RtfColorDef.Navy);
            rtfColor.Add(RtfColor.Olive, RtfColorDef.Olive);
            rtfColor.Add(RtfColor.Purple, RtfColorDef.Purple);
            rtfColor.Add(RtfColor.Red, RtfColorDef.Red);
            rtfColor.Add(RtfColor.Silver, RtfColorDef.Silver);
            rtfColor.Add(RtfColor.Teal, RtfColorDef.Teal);
            rtfColor.Add(RtfColor.White, RtfColorDef.White);
            rtfColor.Add(RtfColor.Yellow, RtfColorDef.Yellow);

            // 初始化字典映射默认框架字体家庭RTF格式字体
            rtfFontFamily = new HybridDictionary();
            rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern);
            rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss);
            rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman);
            rtfFontFamily.Add(FF_UNKNOWN, RtfFontFamilyDef.Unknown);

            // 获取正在显示的对象的水平和垂直分辨率
            using (Graphics _graphics = this.CreateGraphics())
            {
                xDpi = _graphics.DpiX;
                yDpi = _graphics.DpiY;
            }
            //this.ReleaseRichEditOleInterface();
        }
 
        #endregion


        #region My Privates
        /// <summary>
        /// 富编辑 OLE 对象连接与嵌入
        /// </summary>
        private RichEditOle _richEditOle;
        internal RichEditOle RichEditOle
        {
            get
            {
                if (_richEditOle == null)
                {
                    if (base.IsHandleCreated)
                    {
                        _richEditOle = new RichEditOle(this);
                    }
                }

                return _richEditOle;
            }
        }

        /// <summary>
        /// _ OLE对象列表
        /// </summary>
        private Dictionary<int, REOBJECT> _oleObjectList;
        public Dictionary<int, REOBJECT> OleObjectList
        {
            get
            {
                if (_oleObjectList == null)
                {
                    _oleObjectList = new Dictionary<int, REOBJECT>(10);
                }
                return _oleObjectList;
            }
        }

        /// <summary>
        /// 列表中的对象数量
        /// </summary>
        //private int _index;

        // 默认文本颜色

            //2
        private RtfColor textColor;

        // 默认文本背景颜色
        private RtfColor highlightColor;

        // 混合字典，颜色地图枚举为 RTF 颜色代码
        private HybridDictionary rtfColor;

        // 混合字典，字体家族 RTF 格式
        private HybridDictionary rtfFontFamily;

        // 正在显示控件的水平分辨率
        private float xDpi;

        // 正在显示控件的垂直分辨率
        private float yDpi;

        #region RTF文档元素

        /* RTF格式的头
		 * ----------
		 * 
		 * \rtf[N]		-文本被认为是RTF格式，它必须用这个标签。因为rtf1使用RichTextBox符合RTF规范1
		 * \ansi		- 字符集。.
		 * \ansicpg[N]	- 指定的Unicode字符可能被嵌入。ansicpg1252采用Windows默认。
		 *				  .
		 * \deff[N]		- The default font. \deff0 means the default font is the first font
		 *				  found.
		 * \deflang[N]	- The default language. \deflang1033 specifies US English.
		 * */
        private const string RTF_HEADER = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033";

        /* RTF文档区域
		 * -----------------
		 * 
		 * \viewkind[N]	- 这类型的视图或缩放级别。 \viewkind4 指定正常视图。
		 * \uc[N]		- 对应于一个Unicode字符的字节数。
		 * \pard		- 重置为默认段落属性
		 * \cf[N]		- 前景颜色。 \cf1 是指颜色表中索引1的颜色
		 *				   
		 * \f[N]		- Font number. \f0 是指在字体表索引为0的字体
		 *				  
		 * \fs[N]		- 字体大小 在 half-points.
		 * */
        private const string RTF_DOCUMENT_PRE = @"\viewkind4\uc1\pard\cf1\f0\fs20";
        private const string RTF_DOCUMENT_POST = @"\cf0\fs17}";
        private string RTF_IMAGE_POST = @"}";

        #endregion
        /// <summary>
        /// 检测URL
        /// </summary>
        [DefaultValue(false)]
        public new bool DetectUrls
        {
            get { return base.DetectUrls; }
            set { base.DetectUrls = value; }
        }
        #endregion

        #region 互操作定义
        /// <summary>
        /// 包含在富编辑控件中的字符格式设置的信息。
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT
        {
            public UInt32 cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;//正文
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public UInt16 wWeight;
            public UInt16 sSpacing;
            public int crBackColor; // Color.ToArgb() -> int
            public int lcid;
            public int dwReserved;
            public int dwCookie;
            public Int16 sStyle;// SHORT 
            public Int16 wKerning;//WORD
            public byte bUnderlineType;
            public byte bAnimation;//文本动画类型
            public byte bRevAuthor;
            public byte bReserved1;// public byte bUnderlineColor; 
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region 设置 RichTextBox 控件中的字符格式
        private const int WM_USER = 0x0400;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;
        private const int SCF_SELECTION = 0x0001;//将格式应用于当前所选内容。如果选择为空，字符格式应用于插入点，和新的字符格式实际上是只直到插入点的变化。
        private const int SCF_WORD = 0x0002;//将格式应用于所选的字或词。如果选择为空，但插入点是在文字内，格式应用于 word。结合 SCF_SELECTION 值，必须使用 SCF_WORD 值。
        private const int SCF_ALL = 0x0004;//将格式应用于控件中的所有文本。

        private const UInt32 CFE_BOLD = 0x0001;
        private const UInt32 CFE_ITALIC = 0x0002;
        private const UInt32 CFE_UNDERLINE = 0x0004;
        private const UInt32 CFE_STRIKEOUT = 0x0008;
        private const UInt32 CFE_PROTECTED = 0x0010;
        private const UInt32 CFE_LINK = 0x0020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;
        private const UInt32 CFE_SUBSCRIPT = 0x00010000;		/*上标和下标*/
        private const UInt32 CFE_SUPERSCRIPT = 0x00020000;		/*  互斥			 */

        private const int CFM_SMALLCAPS = 0x0040;			/* (*)	*/
        private const int CFM_ALLCAPS = 0x0080;			/* Displayed by 3.0	*/
        private const int CFM_HIDDEN = 0x0100;			/* Hidden by 3.0 */
        private const int CFM_OUTLINE = 0x0200;			/* (*)	*/
        private const int CFM_SHADOW = 0x0400;			/* (*)	*/
        private const int CFM_EMBOSS = 0x0800;			/* (*)	*/
        private const int CFM_IMPRINT = 0x1000;			/* (*)	*/
        private const int CFM_DISABLED = 0x2000;
        private const int CFM_REVISED = 0x4000;

        private const int CFM_BACKCOLOR = 0x04000000;
        private const int CFM_LCID = 0x02000000;
        private const int CFM_UNDERLINETYPE = 0x00800000;		/* Many displayed by 3.0 */
        private const int CFM_WEIGHT = 0x00400000;
        private const int CFM_SPACING = 0x00200000;		/* Displayed by 3.0	*/
        private const int CFM_KERNING = 0x00100000;		/* (*)	*/
        private const int CFM_STYLE = 0x00080000;		/* (*)	*/
        private const int CFM_ANIMATION = 0x00040000;		/* (*)	*/
        private const int CFM_REVAUTHOR = 0x00008000;


        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;//正文
        private const UInt32 CFM_CHARSET = 0x08000000;
        private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;

        private const byte CFU_UNDERLINENONE = 0x00000000;
        private const byte CFU_UNDERLINE = 0x00000001;
        private const byte CFU_UNDERLINEWORD = 0x00000002; /* (*) displayed as ordinary underline	*/
        private const byte CFU_UNDERLINEDOUBLE = 0x00000003; /* (*) displayed as ordinary underline	*/
        private const byte CFU_UNDERLINEDOTTED = 0x00000004;
        private const byte CFU_UNDERLINEDASH = 0x00000005;
        private const byte CFU_UNDERLINEDASHDOT = 0x00000006;
        private const byte CFU_UNDERLINEDASHDOTDOT = 0x00000007;
        private const byte CFU_UNDERLINEWAVE = 0x00000008;
        private const byte CFU_UNDERLINETHICK = 0x00000009;
        private const byte CFU_UNDERLINEHAIRLINE = 0x0000000A; /* (*)显示为普通下划线	*/

        #region   常量

        //不使用此应用程序。描述可以发现Windows GDI函数设置指定设备场景的映射模式的文件
        private const int MM_TEXT = 1;
        private const int MM_LOMETRIC = 2;
        private const int MM_HIMETRIC = 3;
        private const int MM_LOENGLISH = 4;
        private const int MM_HIENGLISH = 5;
        private const int MM_TWIPS = 6;

        // 确保文件保持1:1的纵横比
        private const int MM_ISOTROPIC = 7;

        // 让x坐标和y坐标的图元进行调整
        private const int MM_ANISOTROPIC = 8;

        // 表示一个未知的字体族
        private const string FF_UNKNOWN = "UNKNOWN";

        // 数的百分之毫米 (0.01 mm) 毫米 在更多信息一寸，看getimageprefix()方法。  
        private const int HMM_PER_INCH = 2540;

        // 为更多的信息一寸缇数，看到 getimageprefix()方 法。
        private const int TWIPS_PER_INCH = 1440;

        #endregion
        #endregion

        #region 属性


        // 重写 RTF 格式的默认实现。这可以省略和删除坏字符 RemoveBadCharacters
        // 这是因为控制最初是运行在一个即时通讯，使用基于XML的  Jabber XML-based 协议。
        // 该框架将抛出一个异常，当XML包含空字符，所以我过滤掉了。
        //public new string Rtf
        //{
        //    get { return RemoveBadChars(base.Rtf); }
        //    set { base.Rtf = value; }
        //}

        // 文本的颜色
        public RtfColor TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        // 突出的颜色
        public RtfColor HiglightColor
        {
            get { return highlightColor; }
            set { highlightColor = value; }
        }

        #endregion
        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case 0x0100:
        //            if (this.ReadOnly)
        //                return;
        //            break;
        //        case 0X0102:
        //            if (this.ReadOnly)
        //                return;
        //            break;
        //        default:
        //            break;
        //    }
        //    base.WndProc(ref m);
        //}
        #region 方法 InsertImage

        public bool InsertImageUseGifBox(Image image)
        {
            try
            {
                GifBox gif = new GifBox();
                gif.BackColor = base.BackColor;
                gif.Image = image;
                RichEditOle.InsertControl(gif);
#warning 调试
                AppendRtf(gif.Name);
                gif = null;
                image = null;
#warning 调试
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

   
        #endregion InsertImage


        #region 方法 添加文本 

        public void AppendRtf(string _rtf)
        {
            if (_rtf != null)
                // 插入到文本尾
                this.Select(this.TextLength, 0);

            // 由于SelectedRtf是空的，这会追加字符串的RTF结束  
            this.SelectedRtf = _rtf;
        }

       
        /// {\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{[FONTS]}{\colortbl ;[COLORS]}}
        /// \viewkind4\uc1\pard\cf1\f0\fs20 [DOCUMENT AREA] }
        public void InsertTextAsRtf(string _text, Font _font, RtfColor _textColor, RtfColor _backColor)
        {
            if (_font == null) _font = this.Font; if (_textColor == 0) _textColor = textColor; if (_backColor == 0) _backColor = highlightColor;

            StringBuilder _rtf = new StringBuilder();
            this.Select(this.TextLength, 0);

            // 追加的RTF头
            _rtf.Append(RTF_HEADER);

            //从创建的字体通过在字体表追加到RTF格式字符串
            _rtf.Append(GetFontTable(_font));

            // 创建通过在颜色表追加到RTF格式字符串
            _rtf.Append(GetColorTable(_textColor, _backColor));

            // 从添加文本为RTF和追加到RTF格式字符串创建文档区。
            _rtf.Append(GetDocumentArea(_text, _font));

            this.SelectedRtf = _rtf.ToString();
            _rtf = null;
        }

        /// <summary>
        /// 创建文档区域
        /// 
        /// \viewkind4\uc1\pard\cf1\f0\fs20 [DOCUMENT AREA] } 
        /// 
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_font"></param>
        /// <returns>
        /// 文件区作为一个字符串
        /// </returns>
        private string GetDocumentArea(string _text, Font _font)
        {

            StringBuilder _doc = new StringBuilder();

            // 附加标准的RTF文档区域控制字符串
            _doc.Append(RTF_DOCUMENT_PRE);

            // 将突出的颜色（文本后面的颜色）设置为颜色表中的第三个颜色。更多细节见 getcolortable。
            _doc.Append(@"\highlight2");

            // 如果字体为黑体，则附加相应的标记
            if (_font.Bold)
                _doc.Append(@"\b");

            // 如果字体为斜体，附上相应的标签
            if (_font.Italic)
                _doc.Append(@"\i");

            // 如果字体是删除线，附上相应的标签
            if (_font.Strikeout)
                _doc.Append(@"\strike");

            // 如果字体是下划线的，则附加相应的标签
            if (_font.Underline)
                _doc.Append(@"\ul");

            //将字体设置为字体表中的第一个字体。更多细节见 getfonttable。
            _doc.Append(@"\f0");

            // 设置字体的大小。在RTF格式，字体大小是半点测量，所以字体大小的值的两倍了

            // Font.SizeInPoints
            _doc.Append(@"\fs");
            _doc.Append((int)Math.Round((2 * _font.SizeInPoints)));

            // apppend空间开始之前实际文本（清晰）
            _doc.Append(@" ");

            // 在实际文本，然而，用 RTF \par.替换换行符。
            // 任何其他的特殊文本应在这里处理（例如）标签 tabs, etc. 等。 
            _doc.Append(_text.Replace("\n", @"\par "));

            // RTF格式不严格的时候，关闭控制字，但到底什么…

            // 删除突出 highlight 
            _doc.Append(@"\highlight0");

            // 如果字体为粗体，关闭标签
            if (_font.Bold)
                _doc.Append(@"\b0");

            // 如果字体为斜体的关闭标签
            if (_font.Italic)
                _doc.Append(@"\i0");

            //如果字体删除线、关闭标签
            if (_font.Strikeout)
                _doc.Append(@"\strike0");

            // 如果字体下划线，风格的标签
            if (_font.Underline)
                _doc.Append(@"\ulnone");

            // 还原回默认的字体和大小
            _doc.Append(@"\f0");
            _doc.Append(@"\fs20");

            // 关闭文档区域控制字符串
            _doc.Append(RTF_DOCUMENT_POST);

            return _doc.ToString();
        }

        #endregion

        #region 方法 插入图像

        /// <summary>
        /// 插入一个图像到RichTextBox。图像被包裹在一个窗口中格式图元文件，因为虽然微软不鼓励使用一个WMF，
        /// 
        /// RichTextBox（甚至是MS Word），将一个图像在WMF之前插入将图像转化为文档。WMF附着的HEX格式（字符串 十六进制数）。
        /// 
        /// RTF规范v1.6说你应该能够插入位图，JPEG，GIF，PNG，。。，和增强型图元文件（。EMF）直接进入一个RTF
        /// 
        /// 没有WMF的包装文件。这工作正常的MS Word
        /// 
        /// 然而，当你不把图像中的WMF，写字板和richtextboxes视而不见。使用 riched20.dll or msfted.dll.
        /// </summary>
        /// <remarks>
        /// 注：图片插入到插入时，如果选择了任何文本，则该文本被替换。 
        /// </remarks>
        /// <param name="_image"></param>
        public void InsertImage(Image _image)
        {

            StringBuilder _rtf = new StringBuilder();

            //     追加的RTF头   
            // @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033"; 
            _rtf.Append(RTF_HEADER);

            // 创建字体表使用RichTextBox的当前字体和追加到RTF格式字符串
            // {\fonttbl{\f0\[FAMILY]\fcharset0 [FONT_NAME];}
            _rtf.Append(GetFontTable(this.Font));

            // 创建图像控件的字符串追加到RTF格式字符串  
            //  {\pict\wmetafile8\picw[A]\pich[B]\picwgoal[C]\pichgoal[D]
            _rtf.Append(GetImagePrefix(_image));

            // 创建Windows图元文件，hex 格式附加的字节 Create the Windows Metafile and append its bytes in HEX format
            // {0:X2}
            _rtf.Append(GetRtfImage(_image));
#warning 调试    上面要增加图片压缩，否则消息太大   
            _image = null;
            //关闭RTF格式图像控制字符串
            //  @"}"
            _rtf.Append(RTF_IMAGE_POST);

            this.SelectedRtf = _rtf.ToString();

#warning 调试       
            _rtf = null;


        }

        /// <summary>
        /// 获取图像的前缀 创建的字符串，describes RFT控制的图像被插。
        /// 这个描述（在这个案例specifies），图像的岩石
        /// 毫米_ anisotropic图元文件，意思都是X和Y轴可以标度
        /// independently。字符串也给出了控制流的图像尺寸，
        /// 和它的目标维度，所以如果你想控制的size of the
        /// 被插的图像，这将是做它的地方。“要字头
        /// 的形式……
        ///  
        /// {\pict\wmetafile8\picw[A]\pich[B]\picwgoal[C]\pichgoal[D]
        /// 
        /// where ...
        /// 
        /// A	= 图元文件的当前宽度以百分之一毫米(0.01mm)
        ///        图像宽度的英寸数×每英寸（0.01mm）
        ///     =（像素宽的图像/图形上下文的水平分辨率×2540）
        ///     =（图像的像素宽度/ graphics.dpix 2540×）
        ///		= Image Width in Inches * Number of (0.01mm) per inch
        ///		= (Image Width in Pixels / Graphics Context's Horizontal Resolution) * 2540
        ///		= (Image Width in Pixels / Graphics.DpiX) * 2540
        /// 
        /// B	= current height of the metafile in hundredths of millimeters (0.01mm)
        ///		= Image Height in Inches * Number of (0.01mm) per inch
        ///		= (Image Height in Pixels / Graphics Context's Vertical Resolution) * 2540
        ///		= (Image Height in Pixels / Graphics.DpiX) * 2540
        ///  
        /// B =高电流的图元文件（在hundredths毫米（0.01mm）
        ///   图像高度的英寸数×每英寸（0.01mm）
        ///   =（高像素的图像/图形上下文的垂直分辨率×2540）
        ///   =（图像的像素/高graphics.dpix 2540×） 
        /// 
        /// C	= target width of the metafile in twips
        ///		= Image Width in Inches * Number of twips per inch
        ///		= (Image Width in Pixels / Graphics Context's Horizontal Resolution) * 1440
        ///		= (Image Width in Pixels / Graphics.DpiX) * 1440
        /// 
        ///   C =目标宽度的图元文件在缇
        ///   图像宽度的英寸数×缇每英寸
        ///   =（像素宽的图像/图形上下文的水平分辨率×1440）
        ///   =（图像的像素宽度/ graphics.dpix×1440）
        /// D	= target height of the metafile in twips
        ///		= Image Height in Inches * Number of twips per inch
        ///		= (Image Height in Pixels / Graphics Context's Horizontal Resolution) * 1440
        ///		= (Image Height in Pixels / Graphics.DpiX) * 1440
        ///   D =目标高度的图元文件在缇
        ///   图像高度的缇数英寸×每英寸
        ///   =（高像素的图像/图形上下文的水平分辨率×1440）
        ///   =（图像的像素/高graphics.dpix×1440）
        ///	
        /// </summary>
        /// <remarks>
        ///   图形上下文的分辨率只是显示正在显示窗口的当前分辨率。
        ///   一般是 96 dpi，但是不要假设我刚添加的代码。
        ///   
        ///   根据pbdr.com肯豪”缇是屏幕无关的单位
        ///   确保使用的布局和比例，屏幕元素在大学
        ///   你的应用程序是一样的屏幕上所有显示系统。”
        /// The Graphics Context's resolution is simply the current resolution at which windows is being displayed.  Normally it's 96 dpi, but instead of assuming
        /// I just added the code.
        /// 
        /// 根据Ken Howe在pbdr.com，”缇是屏幕独立单元用来确保你的屏幕应用程序的位置和屏幕元素的比例是相同的在所有的显示系统。”
        /// 
        /// 使用单位
        /// ----------
        /// 1 Twip = 1/20 Point 点
        /// 1 Point = 1/72 Inch 英寸
        /// 1 Twip = 1/1440 Inch
        /// 
        /// 1 Inch = 2.54 cm
        /// 1 Inch = 25.4 mm
        /// 1 Inch = 2540 (0.01)mm
        /// </remarks>
        /// <param name="_image"></param>
        /// <returns></returns>
        private string GetImagePrefix(Image _image)
        {

            StringBuilder _rtf = new StringBuilder();

            // 计算图像的宽度（0.01）mm
            int picw = (int)Math.Round((_image.Width / xDpi) * HMM_PER_INCH);

            // 计算图像的当前高度在（0.01）mm
            int pich = (int)Math.Round((_image.Height / yDpi) * HMM_PER_INCH);

            // 计算图像的目标宽度            // （0.01）mm
            int picwgoal = (int)Math.Round((_image.Width / xDpi) * TWIPS_PER_INCH);

            // 计算图像的目标高度  twips
            int pichgoal = (int)Math.Round((_image.Height / yDpi) * TWIPS_PER_INCH);
            _image = null;
            // 以RTF格式字符串附加值
            _rtf.Append(@"{\pict\wmetafile8");
            _rtf.Append(@"\picw");
            _rtf.Append(picw);              // （0.01）mm
            _rtf.Append(@"\pich");
            _rtf.Append(pich);              // （0.01）mm
            _rtf.Append(@"\picwgoal");
            _rtf.Append(picwgoal);          // twips 图像的目标宽度  
            _rtf.Append(@"\pichgoal");
            _rtf.Append(pichgoal);          // twips 图像的目标高度
            _rtf.Append(" ");
            picw = 0;
            pich = 0;
            picwgoal = 0;
            pichgoal = 0;

            return _rtf.ToString();
        }

        /// <summary>
        /// 使用GDI+规范emftowmfbits函数将增强型图元文件到Windows图元文件
        /// </summary>
        /// <param name="_hEmf">
        /// 处理的增强型图元文件要转换
        /// </param>
        /// <param name="_bufferSize">
        /// 用于存储Windows图元文件位返回的缓冲区大小
        /// </param>
        /// <param name="_buffer">
        /// An array of bytes 西安阵列使用两个字节的位返回Windows图元文件
        /// </param>
        /// <param name="_mappingMode">
        /// 图像的映射模式。本控制系统采用 MM_ANISOTROPIC。
        /// </param>
        /// <param name="_flags">
        /// 标记用于指定Windows图元文件的格式返回
        /// </param>
        [DllImportAttribute("gdiplus.dll")]
        private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize, byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);


        /// <summary>
        ///把图像的增强型图元文件绘制的图像在图形上下文，然后将增强型图元文件到Windows图元文件，
        ///最后追加的Windows图元文件的位进制字符串并返回字符串。
        /// </summary>
        /// <param name="_image"></param>
        /// <returns>
        /// 一个字符串包含一个Windows图元文件的位进制
        /// </returns>
        private string GetRtfImage(Image _image)
        {

            StringBuilder _rtf = null;

            // 用于存储的增强型图元文件
            MemoryStream _stream = null;

            // 用于创建和绘制图像文件
            Graphics _graphics = null;

            // 增强型图元文件
            Metafile _metaFile = null;

            //  柄用于创建图元文件设备上下文
            IntPtr _hdc;

            try
            {
                _rtf = new StringBuilder();
                _stream = new MemoryStream();

                //从直接得到图形上下文
                using (_graphics = this.CreateGraphics())
                {

                    // 从图形上下文获取设备上下文
                    _hdc = _graphics.GetHdc();

                    // 创建一个新的增强型图元文件从设备上下文
                    _metaFile = new Metafile(_stream, _hdc);
                    //InsertImageUseGifBox(_metaFile);
                    // 释放设备上下文
                    _graphics.ReleaseHdc(_hdc);
                }

                // 从增强型图元文件得到图形上下文
                using (_graphics = Graphics.FromImage(_metaFile))
                {

                    // 在增强型图元文件绘制图像
                    _graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height));

                }

                // 得到增强的图元文件的句柄
                IntPtr _hEmf = _metaFile.GetHenhmetafile();

                // A打电话给EmfToWmfBits一个空缓冲区返回的缓冲区的大小需要存储的WMF位。使用此来获取缓冲区大小。
                uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);

                // 创建一个数组来保持位
                byte[] _buffer = new byte[_bufferSize];

                //一个叫EmfToWmfBits与一个有效的缓冲区拷贝比特为回报的WMF的比特数的缓冲。
                uint _convertedSize = GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);

                // 到rtf字符串附加位
                for (int i = 0; i < _buffer.Length; ++i)
                {
                    _rtf.Append(String.Format("{0:X2}", _buffer[i]));//十六进制
                }


                if (_graphics != null)
                    _graphics.Dispose();
                if (_metaFile != null)
                    _metaFile.Dispose();
                if (_stream != null)
                    _stream.Close();
                return _rtf.ToString();
            }
            finally
            {
                if (_graphics != null)
                    _graphics.Dispose();
                if (_metaFile != null)
                    _metaFile.Dispose();
                if (_stream != null)
                    _stream.Close();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(_graphics);//_graphics
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(_metaFile);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(_stream);
            }
        }

        #endregion

        #region 方法 RTF的帮手

        /// <summary>
        /// 创建字体表使用RichTextBox的当前字体和追加到RTF格式字符串 
        /// 从一个字体对象创建一个字体表。当插入或附加
        /// /操作是使用一个字体，或者是指定的或默认的字体使用。
        /// 在任何情况下，在任何插入或附加，只有一个字体使用，
        /// 因此，字体表将始终包含一个单一的字体。字体表应具有的形式
        ///   
        /// {\fonttbl{\f0\[FAMILY]\fcharset0 [FONT_NAME];}
        /// </summary>
        /// <param name="_font"></param>
        /// <returns></returns>
        private string GetFontTable(Font _font)
        {

            StringBuilder _fontTable = new StringBuilder();

            // 附加表控制字符串
            _fontTable.Append(@"{\fonttbl{\f0");
            _fontTable.Append(@"\");

            // 如果字体的家庭对应一个RTF格式的家庭， RTF家族名字 else,  追加RTF未知字体.
            if (rtfFontFamily.Contains(_font.FontFamily.Name))
                _fontTable.Append(rtfFontFamily[_font.FontFamily.Name]);
            else
                _fontTable.Append(rtfFontFamily[FF_UNKNOWN]);

            // \fcharset 指定在字体表中的字体的字符集。
            // 0 is for ANSI.
            _fontTable.Append(@"\fcharset0 ");

            // 附加字体的名称
            _fontTable.Append(_font.Name);

            // 关闭控制字符串
            _fontTable.Append(@";}}");

            return _fontTable.ToString();
        }

        /// <summary>
        ///  
        /// 从rtfcolor结构创建字体表。当插入或追加被执行的操作，
        /// _textcolor和_backcolor要么指定或默认使用。
        /// 在任何情况下，在任何插入或附加，只有三种颜色被使用。
        /// 在RichTextBox的默认颜色（用分号（；）表示没有定义），
        /// 总是第一个颜色（指数0）颜色表中。
        /// 第二个颜色总是文本颜色，
        /// 第三个是总是突出的颜色（后面的文本的颜色）。颜色表
        /// /应该有形式…
        /// {\colortbl ;[TEXT_COLOR];[HIGHLIGHT_COLOR];}
        /// 
        /// </summary>
        /// <param name="_textColor"></param>
        /// <param name="_backColor"></param>
        /// <returns></returns>
        private string GetColorTable(RtfColor _textColor, RtfColor _backColor)
        {

            StringBuilder _colorTable = new StringBuilder();

            // 添加颜色表控件字符串和默认字体 (;)
            _colorTable.Append(@"{\colortbl ;");

            // 附加文本颜色
            _colorTable.Append(rtfColor[_textColor]);
            _colorTable.Append(@";");

            // 添加高亮颜色
            _colorTable.Append(rtfColor[_backColor]);
            _colorTable.Append(@";}\n");

            return _colorTable.ToString();
        }

        /// <summary>
        /// 删除空字符
        /// </summary>
        /// <param name="_originalRtf"></param>
        /// <returns>RTF无空字符</returns>
        private string RemoveBadChars(string _originalRtf)
        {
            return _originalRtf.Replace("\0", "");
        }

        #endregion
 
        #region struct enum 
        // 在RTF文档的颜色定义
        private struct RtfColorDef
        {
            public const string Black = @"\red0\green0\blue0";
            public const string Maroon = @"\red128\green0\blue0";
            public const string Green = @"\red0\green128\blue0";
            public const string Olive = @"\red128\green128\blue0";
            public const string Navy = @"\red0\green0\blue128";
            public const string Purple = @"\red128\green0\blue128";
            public const string Teal = @"\red0\green128\blue128";
            public const string Gray = @"\red128\green128\blue128";
            public const string Silver = @"\red192\green192\blue192";
            public const string Red = @"\red255\green0\blue0";
            public const string Lime = @"\red0\green255\blue0";
            public const string Yellow = @"\red255\green255\blue0";
            public const string Blue = @"\red0\green0\blue255";
            public const string Fuchsia = @"\red255\green0\blue255";
            public const string Aqua = @"\red0\green255\blue255";
            public const string White = @"\red255\green255\blue255";
        }

        // RTF格式字体的控制字
        private struct RtfFontFamilyDef
        {
            public const string Unknown = @"\fnil";
            public const string Roman = @"\froman";
            public const string Swiss = @"\fswiss";
            public const string Modern = @"\fmodern";
            public const string Script = @"\fscript";
            public const string Decor = @"\fdecor";
            public const string Technical = @"\ftech";
            public const string BiDirect = @"\fbidi";
        }
         
        // 指定的 标志/选项 对GDI+方法的非托管调用 Metafile.EmfToWmfBits(). 图元文件。 
        private enum EmfToWmfBitsFlags
        {

            // 使用默认的转换
            EmfToWmfBitsFlagsDefault = 0x00000000,

            // 嵌入式的EMF metafiel源在导出的WMF图元文件
            EmfToWmfBitsFlagsEmbedEmf = 0x00000001,

            // P花边22字节的头在产生的WMF文件。标题是图元文件被认为可放置的要求。
            EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,

            //不要模拟裁剪用异或操作。
            EmfToWmfBitsFlagsNoXORClip = 0x00000004
        };

        #endregion
    }
    public enum RtfColor
    {
        Black, Maroon, Green, Olive, Navy, Purple, Teal, Gray, Silver,
        Red, Lime, Yellow, Blue, Fuchsia, Aqua, White
    }
}
