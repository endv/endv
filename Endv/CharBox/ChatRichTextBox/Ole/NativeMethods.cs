using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// 本地方法
    /// </summary>
    internal class NativeMethods
    {
        public const int WM_USER = 0x0400;
        public const int EM_GETOLEINTERFACE = WM_USER + 60;//得到OLE接口
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="message"></param>
        /// <param name="wParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", 
            CharSet = CharSet.Auto, 
            PreserveSig = false)]
        public static extern IRichEditOle SendMessage(
            IntPtr hWnd, int message, int wParam);
        /// <summary>
        /// 创建H全局上的锁字节
        /// </summary>
        /// <param name="hGlobal"></param>
        /// <param name="fDeleteOnRelease">删除释放</param>
        /// <param name="ppLkbyt"></param>
        /// <returns></returns>
        [DllImport("ole32.dll")]
        public static extern int CreateILockBytesOnHGlobal(
            IntPtr hGlobal, bool fDeleteOnRelease, out ILockBytes ppLkbyt);

        /// <summary>
        /// STG创建文件锁定字节
        /// </summary>
        /// <param name="plkbyt"></param>
        /// <param name="grfMode"></param>
        /// <param name="reserved"></param>
        /// <param name="ppstgOpen"></param>
        /// <returns></returns>
        [DllImport("ole32.dll")]
        public static extern int StgCreateDocfileOnILockBytes(
            ILockBytes plkbyt, uint grfMode, uint reserved, out IStorage ppstgOpen);

        [DllImport("ole32.dll")]
        public static extern int OleCreateFromFile([In] ref Guid rclsid,
            [MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, 
            [In] ref Guid riid,
            uint renderopt, 
            ref FORMATETC pFormatEtc, 
            IOleClientSite pClientSite,
            IStorage pStg, 
            [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

        [DllImport("ole32.dll")]
        public static extern int OleSetContainedObject(
            [MarshalAs(UnmanagedType.IUnknown)] object pUnk, bool fContained);
    }
}
