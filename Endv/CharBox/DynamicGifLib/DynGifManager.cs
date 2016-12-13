using System;
using System.Runtime.InteropServices;

namespace CharBox
{
	[CoClass(typeof(DynGifManagerClass)), Guid("C51DA89C-924D-4AE7-B740-09CC68192E09")]
	[ComImport]
	public interface DynGifManager : IDynGifManager
	{
	}
}
