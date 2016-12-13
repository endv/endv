using System;
using System.Runtime.InteropServices;

namespace CharBox
{
	[CoClass(typeof(DynamicGifClass)), Guid("9E6035ED-C26F-4798-AACA-22D793D6FED1")]
	[ComImport]
	public interface DynamicGif : IDynamicGif
	{
	}
}
