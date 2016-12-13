using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// OleContainer是DELPHI中提供的一个OLE包容器部件。使用它，可方便地把WORD、EXCEL等功能集成到自己的软件中来
    /// </summary>
    [ComVisible(true), 
    Guid("0000011B-0000-0000-C000-000000000046"), 
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleContainer
    {
        /// <summary>
        /// 解析显示名称
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pszDisplayName"></param>
        /// <param name="pchEaten"></param>
        /// <param name="ppmkOut"></param>
        void ParseDisplayName(
            [In, MarshalAs(UnmanagedType.Interface)] object pbc,
            [In, MarshalAs(UnmanagedType.BStr)]      string pszDisplayName,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten,
            [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);
        /// <summary>
        /// 枚举对象
        /// </summary>
        /// <param name="grfFlags"></param>
        /// <param name="ppenum"></param>
        void EnumObjects(
            [In, MarshalAs(UnmanagedType.U4)]        int grfFlags,
            [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppenum);

        /// <summary>
        /// 锁定容器
        /// </summary>
        /// <param name="fLock"></param>
        void LockContainer(
            [In, MarshalAs(UnmanagedType.I4)] int fLock);
    }
}
