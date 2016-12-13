using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
	[Guid("0C1CF2DF-05A3-4FEF-8CD4-F5CFC4355A16"), TypeLibType(4096)]//4096 4288 )]//4096 4288 
    [ComImport]
	public interface IGifAnimator
	{
		[DispId(1)]
		[MethodImpl(4096)]
		void LoadFromFile([MarshalAs(19)] [In] string FileName);

		[DispId(2)]
		[MethodImpl(4096)]
		bool TriggerFrameChange();

		[DispId(3)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]
		string GetFilePath();

		[DispId(4)]
		[MethodImpl(4096)]
		void ShowText([MarshalAs(19)] [In] string Text);
	}
}
