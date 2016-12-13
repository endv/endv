using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
	[Guid("C51DA89C-924D-4AE7-B740-09CC68192E09"), TypeLibType(4096)]//4096 4288 )]
    [ComImport]
	public interface IDynGifManager
	{
		[DispId(1)]
		[MethodImpl(4096)]
		[return: MarshalAs(26)]
		object InsertImage([ComAliasName("stdole.OLE_HANDLE")] [In] int hwnd, [MarshalAs(19)] [In] string bstrImagePath, [In] int ulWidth, [In] int ulHeight);

		[DispId(2)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]
		string GetObjectsInfo([ComAliasName("stdole.OLE_HANDLE")] [In] int hwnd);

		[DispId(3)]
		[MethodImpl(4096)]
		[return: ComAliasName("stdole.OLE_HANDLE")]
		int ShowFlash([ComAliasName("stdole.OLE_HANDLE")] [In] int hParent, [MarshalAs(19)] [In] string bstrFlash, [In] uint ulTimeOut);
	}
}
