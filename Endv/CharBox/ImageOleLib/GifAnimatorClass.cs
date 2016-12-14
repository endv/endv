using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CharBox
{
    /// <summary>
    /// GIF������
    /// </summary>
	[ClassInterface(ClassInterfaceType.None), Guid("06ADA938-0FB0-4BC0-B19B-0A38AB17F182"), TypeLibType(2)]// FCanCreate = 2, ���� ITypeInfo::CreateInstance ���������͵�ʵ����
    [ComImport]
	public class GifAnimatorClass : IGifAnimator, GifAnimator
	{
        //[MethodImpl(4096)]
        //public extern GifAnimatorClass();

        [DispId(1)]
		[MethodImpl(4096)]// InternalCall �������ڲ��ģ�Ҳ����˵�����Թ�����������ʱ��ִ�еķ�����
        public virtual extern void LoadFromFile([MarshalAs(19)] [In] string FileName);

        /// <summary>
        /// ����֡�仯
        /// </summary>
        /// <returns></returns>
		[DispId(2)]
		[MethodImpl(4096)]
		public virtual extern bool TriggerFrameChange();

		[DispId(3)]
		[MethodImpl(4096)]
		[return: MarshalAs(19)]// ����ǰ׺Ϊ˫�ֽڵ� Unicode �ַ����������� System.String ����������ʹ�ô˳�Ա������ COM �е�Ĭ���ַ�������
        public virtual extern string GetFilePath();

		[DispId(4)]
		[MethodImpl(4096)]// �������ڲ��ģ�Ҳ����˵�����Թ�����������ʱ��ִ�еķ�����
        public virtual extern void ShowText([MarshalAs(19)] [In] string Text);
	}
}
