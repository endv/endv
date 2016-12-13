using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace CharBox
{
    /// <summary>
    /// REOBJECT结构体包含一个对象的下列信息：
    /// 
    /// cbStruct  - Structure size, in bytes. 
    /// cp        - Character position of the object. 
    /// clsid     - 对象的类标示符.
    /// poleobj   - 指向IOleObject interface的实例的指针.
    /// pstg - 指向IStorage interface的实例的指针. This is the storage object associated with the object. 
    /// polesite - 指向IOleClientSite interface的实例的指针. This is the object's client site in the rich edit control. 这个值必须通过IRichEditOle::GetClientSite方法来获得. 
    /// sizel - A SIZEL structure specifying the size of the object. A 0, 0 on insertion indicates that an object is free to determine its size until the modify flag is turned off. 
    /// dvaspect - 显示方面的使用.See DVASPECT for an explanation of possible values.
    /// dwFlags  - 标示是否对象是打开状态，是是允许改变大小，是否当前是选中状态.
    /// dwUser  - 为用户保留的用于定义用户自己的数据.
    ///  
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class REOBJECT
    {
        public int cbStruct = Marshal.SizeOf(typeof(REOBJECT));	//结构尺寸
        public int cp;											// 对象位置
        public Guid clsid;										//对象的类标识
        public IntPtr poleobj;								// OLE对象接口
        public IStorage pstg;									//相关的存储接口 IStorage接口的实例。这是与对象关联的存储对象。
        public IOleClientSite polesite;							// 相关的客户端接口
        public Size sizel;										//物体的大小（可能是0,0）,对象的大小。度量单位是 0.01 毫米，即 HIMETRIC 测量。更多的信息，请参阅函数GetMapMode。0 0 插入指示对象是自由地确定其大小，直到修改国旗处于关闭状态。
        public uint dvAspect;									// 显示方面使用
        public uint dwFlags;									// 对象状态标志
        public uint dwUser;										//对于用户使用 DWORD
    }
}
