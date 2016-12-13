using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// 连续的数据流 ISequentialStream 接口支持简化顺序访问的流对象。
    /// IStream接口继承了ISequentialStream的读和写的方法。
/// 当执行一般而言，使用者应将创建 SQL Server Native Client OLE DB 访问接口存储对象的代码与处理未通过 ISequentialStream 接口指针引用的数据的其他代码分开。
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
    Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
    public interface ISequentialStream
    {
        /// <summary>
        /// 读取指定的数目的字节从流对象读入内存起价当前查找指针。
        /// </summary>
        /// <param name="pv"></param>
        /// <param name="cb"></param>
        /// <param name="pcbRead"></param>
        /// <returns></returns>
        int Read(
            /* [length_is][size_is][out] */ IntPtr pv,
            /* [in] */ uint cb,
            /* [out] */ out uint pcbRead);

        /// <summary>
        /// 写入指定的开始在当前的流对象的字节数查找指针。
        /// </summary>
        /// <param name="pv"></param>
        /// <param name="cb"></param>
        /// <param name="pcbWritten"></param>
        /// <returns></returns>
        int Write(
            /* [size_is][in] */ IntPtr pv,
            /* [in] */ uint cb,
            /* [out] */ out uint pcbWritten);

    };
}
