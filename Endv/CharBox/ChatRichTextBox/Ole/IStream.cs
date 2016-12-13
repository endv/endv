using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// IStream接口允许您读取和写入 stream 对象的数据。
    /// 流对象包含结构化的存储对象，存贮在哪里提供结构中的数据。
    /// 简单的数据可以直接写入流，最常见的，streams 流 是元素嵌套在一个存储对象。
    /// 他们是类似于标准的文件。
    /// </summary>
    [ComImport]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStream : ISequentialStream
    {
        /// <summary>
        /// 将查找指针更改到新的位置相对于开始的流，流或当前查找指针的结尾
        /// </summary>
        /// <param name="dlibMove"></param>
        /// <param name="dwOrigin"></param>
        /// <param name="plibNewPosition"></param>
        /// <returns></returns>
        int Seek(
            /* [in] */ ulong dlibMove,
            /* [in] */ uint dwOrigin,
            /* [out] */ out ulong plibNewPosition);

        /// <summary>
        ///   更改流对象的大小。
        /// </summary>
        /// <param name="libNewSize"></param>
        /// <returns></returns>
        int SetSize(
            /* [in] */ ulong libNewSize);

        /// <summary>
        ///   复制指定的数目的字节从当前查找指针在当前流寻求另一个流中的指针
        /// </summary>
        /// <param name="pstm"></param>
        /// <param name="cb"></param>
        /// <param name="pcbRead"></param>
        /// <param name="pcbWritten"></param>
        /// <returns></returns>
        int CopyTo(
            /* [unique][in] */ [In] IStream pstm,
            /* [in] */ ulong cb,
            /* [out] */ out ulong pcbRead,
            /* [out] */ out ulong pcbWritten);

        int Commit(
            /* [in] */ uint grfCommitFlags);

        int Revert();

        int LockRegion(
            /* [in] */ ulong libOffset,
            /* [in] */ ulong cb,
            /* [in] */ uint dwLockType);

        int UnlockRegion(
            /* [in] */ ulong libOffset,
            /* [in] */ ulong cb,
            /* [in] */ uint dwLockType);

        /// <summary>
        ///      检索此流的 STATSTG 结构。
        /// </summary>
        /// <param name="pstatstg"></param>
        /// <param name="grfStatFlag"></param>
        /// <returns></returns>
        int Stat(
            /* [out] */ out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg,
            /* [in] */ uint grfStatFlag);

        int Clone(
            /* [out] */ out IStream ppstm);

    };
}
