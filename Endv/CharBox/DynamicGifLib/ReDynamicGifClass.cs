using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
	[ClassInterface(ClassInterfaceType.None), Guid("162A1EDD-CE3D-4D14-B7BC-35BCBA83320E"), TypeLibType(38)]
	[ComImport]
	public class ReDynamicGifClass : IReDynamicGif, ReDynamicGif
	{
		[DispId(-502)]
		public virtual extern int BackStyle
		{
			[DispId(-502), TypeLibFunc(12)]
			[MethodImpl(4096)]
			get;
			[DispId(-502), TypeLibFunc(12)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(-514)]
		public virtual extern bool Enabled
		{
			[DispId(-514), TypeLibFunc(12)]
			[MethodImpl(4096)]
			get;
			[DispId(-514), TypeLibFunc(12)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(-516)]
		public virtual extern bool TabStop
		{
			[DispId(-516), TypeLibFunc(12)]
			[MethodImpl(4096)]
			get;
			[DispId(-516), TypeLibFunc(12)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(-517)]
		public virtual extern string Text
		{
			[DispId(-517), TypeLibFunc(12)]
			[MethodImpl(4096)]
			[return: MarshalAs(19)]
			get;
			[DispId(-517), TypeLibFunc(12)]
			[MethodImpl(4096)]
			[param: MarshalAs(19)]
			set;
		}

		[DispId(6)]
		public virtual extern int DisplaySize
		{
			[DispId(6)]
			[MethodImpl(4096)]
			get;
			[DispId(6)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(7)]
		public virtual extern bool REMode
		{
			[DispId(7)]
			[MethodImpl(4096)]
			get;
			[DispId(7)]
			[MethodImpl(4096)]
			set;
		}

		//[MethodImpl(4096)]
		//public extern ReDynamicGifClass();

		[DispId(1)]
		[MethodImpl(4096)]
		public virtual extern void LoadFromFile([MarshalAs(19)] [In] string bstrFileName);

		[DispId(2)]
		[MethodImpl(4096)]
		public virtual extern void LoadFromResource([ComAliasName("stdole.OLE_HANDLE")] [In] int hResInst, [MarshalAs(21)] [In] string bstrResName, [MarshalAs(21)] [In] string bstrResType);

		[DispId(3)]
		[MethodImpl(4096)]
		public virtual extern void Play();

		[DispId(4)]
		[MethodImpl(4096)]
		public virtual extern void Stop();

		[DispId(5)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]
		public virtual extern string GetFilePath();

		[DispId(-552)]
		[MethodImpl(4096)]
		public virtual extern void AboutBox();

		[DispId(8)]
		[MethodImpl(4096)]
		public virtual extern void LoadFromStream([MarshalAs(25)] [In] object lpUnk);
	}
}
