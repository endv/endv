using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
	[Guid("FBDB6CDF-8F51-4C8B-A8E9-AD653F70D118"), TypeLibType(4096)]//4096 4288 )]
    [ComImport]
	public interface IReDynamicGif
	{
		[DispId(-502)]
		int BackStyle
		{
			[DispId(-502), TypeLibFunc(12)]
			[MethodImpl(4096)]
			get;
			[DispId(-502), TypeLibFunc(12)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(-514)]
		bool Enabled
		{
			[DispId(-514), TypeLibFunc(12)]
			[MethodImpl(4096)]
			get;
			[DispId(-514), TypeLibFunc(12)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(-516)]
		bool TabStop
		{
			[DispId(-516), TypeLibFunc(12)]
			[MethodImpl(4096)]
			get;
			[DispId(-516), TypeLibFunc(12)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(-517)]
		string Text
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
		int DisplaySize
		{
			[DispId(6)]
			[MethodImpl(4096)]
			get;
			[DispId(6)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(7)]
		bool REMode
		{
			[DispId(7)]
			[MethodImpl(4096)]
			get;
			[DispId(7)]
			[MethodImpl(4096)]
			set;
		}

		[DispId(1)]
		[MethodImpl(4096)]
		void LoadFromFile([MarshalAs(19)] [In] string bstrFileName);

		[DispId(2)]
		[MethodImpl(4096)]
		void LoadFromResource([ComAliasName("stdole.OLE_HANDLE")] [In] int hResInst, [MarshalAs(21)] [In] string bstrResName, [MarshalAs(21)] [In] string bstrResType);

		[DispId(3)]
		[MethodImpl(4096)]
		void Play();

		[DispId(4)]
		[MethodImpl(4096)]
		void Stop();

		[DispId(5)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]
		string GetFilePath();

		[DispId(-552)]
		[MethodImpl(4096)]
		void AboutBox();

		[DispId(8)]
		[MethodImpl(4096)]
		void LoadFromStream([MarshalAs(25)] [In] object lpUnk);
	}
}
