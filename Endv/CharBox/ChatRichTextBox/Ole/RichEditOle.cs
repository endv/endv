﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CharBox
{
    /// <summary>
    /// 富编辑 OLE 对象连接与嵌入
    /// </summary>
    internal class RichEditOle
    {
        private ChatRichTextBox _richEdit = null;
        private IRichEditOle _richEditOle = null;

        public RichEditOle(ChatRichTextBox richEdit)
        {
            _richEdit = richEdit;
        }

        public IRichEditOle IRichEditOle
        {
            get
            {
                if (_richEditOle == null)
                {
                    _richEditOle = NativeMethods.SendMessage(
                        _richEdit.Handle, NativeMethods.EM_GETOLEINTERFACE, 0);
                }
                return _richEditOle;
            }
        }

        public void InsertControl(Control control)
        {
            if (control != null)
            {
                ILockBytes bytes;
                IStorage storage;
                IOleClientSite site;
                Guid guid = Marshal.GenerateGuidForType(control.GetType());

                NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
                //STG创建文件锁定字节
                NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
                //返回 IOleClientSite 接口用于创建新的对象。
                IRichEditOle.GetClientSite(out site);

                REOBJECT lpreobject = new REOBJECT();
                lpreobject.cp = _richEdit.TextLength;  //     控件的文本中包含的字符数。
                lpreobject.clsid = guid; //     返回指定类型的全局唯一标识符 (GUID)，或使用类型库导出程序 (Tlbexp.exe) 所用的算法生成 GUID。
                lpreobject.pstg = storage;/// IStorage接口的实例。这是与对象关联的存储对象。
                lpreobject.poleobj = Marshal.GetIUnknownForObject(control); // OLE对象接口 从托管对象返回 IUnknown 接口。
                lpreobject.polesite = site;
                lpreobject.dvAspect = 1;
                lpreobject.dwFlags = 2;
                lpreobject.dwUser = 1;
                IRichEditOle.InsertObject(lpreobject);
                //Marshal.ReleaseComObject(bytes);
                //Marshal.ReleaseComObject(site);
                //Marshal.ReleaseComObject(storage);
                //Marshal.ReleaseComObject(lpreobject);
            }
        }

        //  GifBox gif = new GifBox();
     
        System.Collections.Generic.List<GifBox> gifList = new System.Collections.Generic.List<GifBox>();
        public string GetGIFInfo()
        {
            string imageInfo = "";
            REOBJECT reObject = new REOBJECT();
            for (int i = 0; i < _richEditOle.GetObjectCount(); i++)
            {
                
                this._richEditOle.GetObject(i, reObject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                GifBox gif = gifList.Find(p => p != null && p.Index == reObject.dwUser);
                if (gif != null)
                {
                    imageInfo += reObject.cp.ToString() + ":" + gif.Name + "|";
                }
            }
            return imageInfo;
        }
        public bool InsertImageFromFile(string strFilename)
        {
            ILockBytes bytes;
            IStorage storage;
            IOleClientSite site;
            object obj2;
            NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out bytes);
            NativeMethods.StgCreateDocfileOnILockBytes(bytes, 0x1012, 0, out storage);
            IRichEditOle.GetClientSite(out site);
            FORMATETC pFormatEtc = new FORMATETC();
            pFormatEtc.cfFormat = (CLIPFORMAT)0;
            pFormatEtc.ptd = IntPtr.Zero;
            pFormatEtc.dwAspect = DVASPECT.DVASPECT_CONTENT;
            pFormatEtc.lindex = -1;
            pFormatEtc.tymed = TYMED.TYMED_NULL;
            Guid riid = new Guid("{00000112-0000-0000-C000-000000000046}");
            Guid rclsid = new Guid("{00000000-0000-0000-0000-000000000000}");
            NativeMethods.OleCreateFromFile(ref rclsid, strFilename, ref riid, 1, ref pFormatEtc, site, storage, out obj2);
            if (obj2 == null)
            {
                Marshal.ReleaseComObject(bytes);
                Marshal.ReleaseComObject(site);
                Marshal.ReleaseComObject(storage);
                return false;
            }
            IOleObject pUnk = (IOleObject)obj2;
            Guid pClsid = new Guid();
            pUnk.GetUserClassID(ref pClsid);
            NativeMethods.OleSetContainedObject(pUnk, true);
            REOBJECT lpreobject = new REOBJECT();
            lpreobject.cp = _richEdit.TextLength;
            lpreobject.clsid = pClsid;
            lpreobject.pstg = storage;
            lpreobject.poleobj = Marshal.GetIUnknownForObject(pUnk);
            lpreobject.polesite = site;
            lpreobject.dvAspect = 1;
            lpreobject.dwFlags = 2;
            lpreobject.dwUser = 0;
            IRichEditOle.InsertObject(lpreobject);
            Marshal.ReleaseComObject(bytes);
            Marshal.ReleaseComObject(site);
            Marshal.ReleaseComObject(storage);
            Marshal.ReleaseComObject(pUnk);
            return true;
        }

        public REOBJECT InsertOleObject(IOleObject oleObject,int index)
        {
            if (oleObject == null)
            {
                return null;
            }

            ILockBytes pLockBytes;
            NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out pLockBytes);

            IStorage pStorage;
            NativeMethods.StgCreateDocfileOnILockBytes(
                pLockBytes, 
                (uint)(STGM.STGM_SHARE_EXCLUSIVE | STGM.STGM_CREATE | STGM.STGM_READWRITE),
                0, 
                out pStorage);

            IOleClientSite pOleClientSite;
            IRichEditOle.GetClientSite(out pOleClientSite);

            Guid guid = new Guid();

            oleObject.GetUserClassID(ref guid);
            NativeMethods.OleSetContainedObject(oleObject, true);

            REOBJECT reoObject = new REOBJECT();

            reoObject.cp = _richEdit.TextLength;
            reoObject.clsid = guid;
            reoObject.pstg = pStorage;
            reoObject.poleobj = Marshal.GetIUnknownForObject(oleObject);
            reoObject.polesite = pOleClientSite;
            reoObject.dvAspect = (uint)DVASPECT.DVASPECT_CONTENT;
            reoObject.dwFlags = (uint)REOOBJECTFLAGS.REO_BELOWBASELINE;
            reoObject.dwUser = (uint)index;

            IRichEditOle.InsertObject(reoObject);

            Marshal.ReleaseComObject(pLockBytes);
            Marshal.ReleaseComObject(pOleClientSite);
            Marshal.ReleaseComObject(pStorage);

            return reoObject;
        }

        public void UpdateObjects()
        {
            int objectCount = this.IRichEditOle.GetObjectCount();
            for (int i = 0; i < objectCount; i++)
            {
                REOBJECT lpreobject = new REOBJECT();
                IRichEditOle.GetObject(i, lpreobject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                Point positionFromCharIndex = this._richEdit.GetPositionFromCharIndex(lpreobject.cp);
                Rectangle rc = new Rectangle(positionFromCharIndex.X, positionFromCharIndex.Y, 50, 50);
                _richEdit.Invalidate(rc, false);
            }
        }

        public void UpdateObjects(int pos)
        {
            REOBJECT lpreobject = new REOBJECT();
            IRichEditOle.GetObject(
                pos,
                lpreobject,
                GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
            UpdateObjects(lpreobject);
        }

        public void UpdateObjects(REOBJECT reObj)
        {
            Point positionFromCharIndex = _richEdit.GetPositionFromCharIndex(
                    reObj.cp);
            Size size = GetSizeFromMillimeter(reObj);
            Rectangle rc = new Rectangle(positionFromCharIndex, size);
            _richEdit.Invalidate(rc, false);
        }

        private Size GetSizeFromMillimeter(REOBJECT lpreobject)
        {
            using (Graphics graphics = Graphics.FromHwnd(_richEdit.Handle))
            {
                Point[] pts = new Point[1];
                graphics.PageUnit = GraphicsUnit.Millimeter;

                pts[0] = new Point(
                    lpreobject.sizel.Width / 100,
                    lpreobject.sizel.Height / 100);
                graphics.TransformPoints(
                    CoordinateSpace.Device,
                    CoordinateSpace.Page,
                    pts);
                return new Size(pts[0]);
            }
        }

        private class MyGIF
        {
        public     MyGIF() { }
         public uint Index { get; internal set; }
            public string Name { get; internal set; }
        }
    }
}
