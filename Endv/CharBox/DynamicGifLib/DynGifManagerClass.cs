using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
	[ClassInterface(ClassInterfaceType.None), Guid("2974FD6C-372B-4020-A8D3-529D065F3BBA"), TypeLibType(2)]
	[ComImport]
	public class DynGifManagerClass : IDynGifManager, DynGifManager
	{
		//[MethodImpl(4096)]
		//public extern DynGifManagerClass();

		[DispId(1)]
		[MethodImpl(4096)]
		[return: MarshalAs(26)]
		public virtual extern object InsertImage([ComAliasName("stdole.OLE_HANDLE")] [In] int hwnd, [MarshalAs(19)] [In] string bstrImagePath, [In] int ulWidth, [In] int ulHeight);

		[DispId(2)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]
		public virtual extern string GetObjectsInfo([ComAliasName("stdole.OLE_HANDLE")] [In] int hwnd);

		[DispId(3)]
		[MethodImpl(4096)]
		[return: ComAliasName("stdole.OLE_HANDLE")]
		public virtual extern int ShowFlash([ComAliasName("stdole.OLE_HANDLE")] [In] int hParent, [MarshalAs(19)] [In] string bstrFlash, [In] uint ulTimeOut);
	}
}
