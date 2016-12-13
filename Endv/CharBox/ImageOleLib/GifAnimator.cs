using System;
using System.Runtime.InteropServices;

namespace CharBox
{
	[CoClass(typeof(GifAnimatorClass)), Guid("0C1CF2DF-05A3-4FEF-8CD4-F5CFC4355A16")]
	[ComImport]
	public interface GifAnimator : IGifAnimator
	{
	}
}
