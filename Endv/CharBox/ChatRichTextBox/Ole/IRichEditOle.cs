using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// 如需向 CRichEditCtrl 里面插入Ole对象，需要调用 GetIRichEditOle 获得此 CRichEditCtrl 的 IRichEditOle 接口
    /// </summary>
    [ComImport, 
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
    Guid("00020D00-0000-0000-c000-000000000046")]
    public interface IRichEditOle
    {
        //   接口下面几个重要的方法
        //   InsertObject：插入一个对象到CRichEditCtrl
        //   GetObject：返回一个CRichEditCtrl里面的 REOBJECT 对象
        //   ImportDataObject: 导入一个剪切板对象并替换当前选中内容
        //   GetClientSite：返回IOleClientSite接口用于创建新的对象。
        //   GetClipboardData：返回一个Clipboard对象。 


        /// <summary>
        /// 返回 IOleClientSite 接口用于创建新的对象。
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClientSite(out IOleClientSite site);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetObjectCount();


        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetLinkCount();

        /// <summary>
        /// 返回一个 CRichEditCtrl里面的 REOBJECT 对象
        /// </summary>
        /// <param name="iob"></param>
        /// <param name="lpreobject"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetObject(int iob, [In, Out] REOBJECT lpreobject, [MarshalAs(UnmanagedType.U4)] GETOBJECTOPTIONS flags);

        /// <summary>
        /// 插入一个对象到 CRichEditCtrl
        /// </summary>
        /// <param name="lpreobject"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertObject(REOBJECT lpreobject);
   
        /// <summary>
        /// 转换对象
        /// </summary>
        /// <param name="iob"></param>
        /// <param name="rclsidNew"></param>
        /// <param name="lpstrUserTypeNew"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)] 
        [PreserveSig]
        int ConvertObject(int iob, Guid rclsidNew, string lpstrUserTypeNew);
        
        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="rclsid"></param>
        /// <param name="rclsidAs"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ActivateAs(Guid rclsid, Guid rclsidAs);

        /// <summary>
        /// 设置主机名
        /// </summary>
        /// <param name="lpstrContainerApp"></param>
        /// <param name="lpstrContainerObj"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetHostNames(string lpstrContainerApp, string lpstrContainerObj);

        /// <summary>
        /// 设置链接可用
        /// </summary>
        /// <param name="iob"></param>
        /// <param name="fAvailable"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetLinkAvailable(int iob, bool fAvailable);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetDvaspect(int iob, uint dvaspect);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int HandsOffStorage(int iob);

        /// <summary>
        /// 保存完毕
        /// </summary>
        /// <param name="iob"></param>
        /// <param name="lpstg"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveCompleted(int iob, IStorage lpstg);

        /// <summary>
        /// 在关闭
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InPlaceDeactivate();

        /// <summary>
        /// 上下文相关的帮助
        /// </summary>
        /// <param name="fEnterMode"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp(bool fEnterMode);

        /// <summary>
        /// 获取剪贴板数据 返回一个 Clipboard 对象
        /// </summary>
        /// <param name="lpchrg"></param>
        /// <param name="reco"></param>
        /// <param name="lplpdataobj"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClipboardData([In, Out] ref CHARRANGE lpchrg, [MarshalAs(UnmanagedType.U4)] GETCLIPBOARDDATAFLAGS reco, out IDataObject lplpdataobj);

        /// <summary>
        /// 导入数据对象 导入一个剪切板对象并替换当前选中内容
        /// </summary>
        /// <param name="lpdataobj"></param>
        /// <param name="cf"></param>
        /// <param name="hMetaPict"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ImportDataObject(IDataObject lpdataobj, int cf, IntPtr hMetaPict);
    }
}
