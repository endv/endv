using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// 嵌入对象接口 如果需要往ole容器内嵌入一个嵌入对象(embedded object )
    /// 则可以利用这个接口获取嵌入对象在容器内的定位信息，和嵌入对象的别名(moniker)，显示的范围，
    /// 和用户界面以及容器提供的其他信息。被嵌入的对象必须通过调用IOleClientSite来获得
    /// 容器所提供的服务。容器会对每个它包含的复合文档(compound-document)提供一个IOleClientSite实例.
    /// 
    /// IOleClientSite接口提过如下比较常用的借口：
    /// 
    /// SaveObject:当用户更新或退出时，嵌入对象通过此方法请求容器把嵌入对象保存到persistent storage，此调用是同步的。
    /// GetMoniker:请求对象的moniker.容器用此Moniker来维持与object的联系。
    /// GetContainer:返回一个指向对象的容器的指针，利用这个指针可以遍历容器里的所有object。
    /// ShowObject:请求容器显示对象。
    /// OnShowWindow:通知容器当对象变的可见或不可见。
    /// RequestNewObjectLayout:请求容器改变对象显示的位置。 
    /// </summary>
    [ComVisible(true),
    Guid("00000118-0000-0000-C000-000000000046"), 
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleClientSite
    {
        /// <summary>
        /// 当用户更新或退出时，嵌入对象通过此方法请求容器把嵌入对象保存到 persistent storage，
        /// 此调用是同步的。
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveObject();

        /// <summary>
        /// 请求对象的 moniker.容器用此 Moniker 来维持与object的联系。
        /// </summary>
        /// <param name="dwAssign"></param>
        /// <param name="dwWhichMoniker"></param>
        /// <param name="ppmk"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)]          int dwAssign,
            [In, MarshalAs(UnmanagedType.U4)]          int dwWhichMoniker,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppmk);

        /// <summary>
        /// 返回一个指向对象的容器的指针，利用这个指针可以遍历容器里的所有object。
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetContainer([MarshalAs(UnmanagedType.Interface)] out IOleContainer container);

        /// <summary>
        /// 请求容器显示对象。
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowObject();

        /// <summary>
        /// 通知容器当对象变的可见或不可见。
        /// </summary>
        /// <param name="fShow"></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnShowWindow(
            [In, MarshalAs(UnmanagedType.I4)] int fShow);

        /// <summary>
        /// 请求容器改变对象显示的位置。 
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestNewObjectLayout();
    }
}
