using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// GIF动画类
    /// </summary>
	[ClassInterface(ClassInterfaceType.None), Guid("06ADA938-0FB0-4BC0-B19B-0A38AB17F182"), TypeLibType(2)]// FCanCreate = 2, 可由 ITypeInfo::CreateInstance 创建该类型的实例。
    [ComImport]
	public class GifAnimatorClass : IGifAnimator, GifAnimator
	{
        //[MethodImpl(4096)]
        //public extern GifAnimatorClass();

        [DispId(1)]
		[MethodImpl(4096)]// InternalCall 调用是内部的，也就是说，它对公共语言运行时中执行的方法。
        public virtual extern void LoadFromFile([MarshalAs(19)] [In] string FileName);

        /// <summary>
        /// 触发帧变化
        /// </summary>
        /// <returns></returns>
		[DispId(2)]
		[MethodImpl(4096)]
		public virtual extern bool TriggerFrameChange();

		[DispId(3)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]// 长度前缀为双字节的 Unicode 字符串。可以在 System.String 数据类型上使用此成员（它是 COM 中的默认字符串）。
        public virtual extern string GetFilePath();

		[DispId(4)]
		[MethodImpl(4096)]// 调用是内部的，也就是说，它对公共语言运行时中执行的方法。
        public virtual extern void ShowText([MarshalAs(19)] [In] string Text);
	}
}
