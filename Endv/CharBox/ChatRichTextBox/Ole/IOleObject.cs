using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace CharBox
{

    ////GetClientSite(IOleClientSite** ppClientSite);  //获取OLE包容器的站点对象
    ////SetHostNames(LPCOLESTR szContainerApp, LPCOLESTR szContainerObj);  //允许嵌入对象能够在其窗口标题上显示包容器程序名
    ////Close(DWORD dwSaveOption);  //终止嵌入对象的激活状态
    ////SetMoniker(DWORD dwWhichMoniker, IMoniker* pmk);
    ////GetMoniker(DWORD dwAssign, DWORD dwWhichMoniker, IMoniker** ppmk);
    ////InitFromData(IDataObject* pDataObject, BOOL fCreation, DWORD dwReserved);
    ////GetClipboardData(DWORD dwReserved, IDataObject** ppDataObject);
    ////DoVerb(LONG iVerb, LPMSG lpmsg, IOleClientSite* pActiveSite, LONG lindex, HWND hwndParent, LPCRECT lprcPosRect);//激活嵌入对象，并可通过使用不同的动词让嵌入对象执行相应的动作
    ////EnumVerbs(IEnumOLEVERB** ppEnumOleVerb);  //装入上下文菜单
    ////Update();
    ////IsUpToDate();
    ////GetUserClassID(CLSID* pClsid);
    ////GetUserType(DWORD dwFormOfType, LPOLESTR* pszUserType);
    ////SetExtent(DWORD dwDrawAspect, SIZEL* psizel);  //设置控件可使用的空间（控件在屏幕上使用的区域范围）
    ////GetExtent(DWORD dwDrawAspect, SIZEL* psizel);  //获取控件可使用的空间
    ////Advise(IAdviseSink* pAdvSink, DWORD* pdwConnection);
    ////Unadvise(DWORD dwConnection);
    ////EnumAdvise(IEnumSTATDATA** ppenumAdvise);
    ////GetMiscStatus(DWORD dwAspect, DWORD* pdwStatus);  //返回 OLEMISC 状态位
    /// SetColorScheme(LOGPALETTE* pLogpal);
    /// IOleObject接口通常与IDataObject 和 IPersistStorage 等接口共同使用，
    /// 虽然该接口提供了21种方法，但只有DoVerb（）、SetHostNames（）
    /// 和Close（）这三个方法是必须被实现的。调用IOleObject接口提供的方法将
    /// 能够使包容器程序与嵌入对象进行通信。任何包容器程序都必须调用DoVerb（）方法
    /// 以激活嵌入对象，并可通过使用不同的动词让嵌入对象执行相应的动作。
    /// SetHostNames（）方法则允许嵌入对象能够在其窗口标题上显示包容器程序名。
    /// 包容器程序调用Close（）方法，可以终止嵌入对象的激活状态




    /// <summary>
    /// 在REOBJECT里忙有个指向IOleObject的指针poleobj，下面来分析
    /// 其实IOleObject接口定义了一系列的方法，这些方法允许数据传输，和数据更改通知，这些用于数据传输的方法利用 STGMEDIUM 来指定数据格式FORMATETC。这些数据可以提供给特定的目标设备(target device),
    /// IOleObject还管理所有的与对象的连接用于通知数据的改变。
    /// </summary>
    [ComVisible(true), 
    ComImport(), 
    Guid("00000112-0000-0000-C000-000000000046"), 
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleObject
    {
        /// <summary>
        /// SetClientSite(IOleClientSite *pClientSite);    //设置OLE包容器的站点对象
        /// </summary>
        /// SetClientSite(IOleClientSite *pClientSite);    //设置OLE包容器的站点对象

        /// <param name="pClientSite"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetClientSite(
            [In, MarshalAs(UnmanagedType.Interface)]
			IOleClientSite pClientSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClientSite(out IOleClientSite site);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetHostNames(
            [In, MarshalAs(UnmanagedType.LPWStr)]
			string szContainerApp,
            [In, MarshalAs(UnmanagedType.LPWStr)]
			string szContainerObj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Close(
            [In, MarshalAs(UnmanagedType.I4)]
			int dwSaveOption);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetMoniker(
            [In, MarshalAs(UnmanagedType.U4)]
			int dwWhichMoniker,
            [In, MarshalAs(UnmanagedType.Interface)]
			object pmk);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)]
			int dwAssign,
            [In, MarshalAs(UnmanagedType.U4)]
			int dwWhichMoniker,
            out object moniker);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InitFromData(
            [In, MarshalAs(UnmanagedType.Interface)]
			IDataObject pDataObject,
            [In, MarshalAs(UnmanagedType.I4)]
			int fCreation,
            [In, MarshalAs(UnmanagedType.U4)]
			int dwReserved);

        int GetClipboardData(
            [In, MarshalAs(UnmanagedType.U4)]
			int dwReserved,
            out IDataObject data);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DoVerb(
            [In, MarshalAs(UnmanagedType.I4)]
			int iVerb,
            [In]
			IntPtr lpmsg,
            [In, MarshalAs(UnmanagedType.Interface)]
			IOleClientSite pActiveSite,
            [In, MarshalAs(UnmanagedType.I4)]
			int lindex,
            [In]
			IntPtr hwndParent,
            [In]
			COMRECT lprcPosRect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumVerbs(out IEnumOLEVERB e);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Update();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsUpToDate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetUserClassID(
            [In, Out]
			ref Guid pClsid);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetUserType(
            [In, MarshalAs(UnmanagedType.U4)]
			int dwFormOfType,
            [Out, MarshalAs(UnmanagedType.LPWStr)]
			out string userType);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetExtent(
            [In, MarshalAs(UnmanagedType.U4)]
			int dwDrawAspect,
            [In]
			Size pSizel);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetExtent(
            [In, MarshalAs(UnmanagedType.U4)]
			int dwDrawAspect,
            [Out]
			Size pSizel);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Advise([In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink, out int cookie);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Unadvise([In, MarshalAs(UnmanagedType.U4)] int dwConnection);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumAdvise(out IEnumSTATDATA e);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMiscStatus([In, MarshalAs(UnmanagedType.U4)] int dwAspect, out int misc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetColorScheme([In] tagLOGPALETTE pLogpal);
    }
}
