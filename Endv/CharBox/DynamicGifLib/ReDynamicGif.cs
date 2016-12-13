using System;
using System.Runtime.InteropServices;

namespace CharBox
{
	[CoClass(typeof(ReDynamicGifClass)), Guid("FBDB6CDF-8F51-4C8B-A8E9-AD653F70D118")]
	[ComImport]
	public interface ReDynamicGif : IReDynamicGif
	{
	}
}
