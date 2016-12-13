using System;
using System.Collections.Generic;
using System.Text;

namespace CharBox
{
    /// <summary>
    /// 获取对象的选项
    /// </summary>
    public enum GETOBJECTOPTIONS
    {
        /// <summary>
        /// 选举事务处得到obj没有接口
        /// </summary>
        REO_GETOBJ_NO_INTERFACES = 0x00000000,

        /// <summary>
        /// 选举事务处得到的obj poleobj
        /// </summary>
        REO_GETOBJ_POLEOBJ = 0x00000001,

        /// <summary>
        /// 研究
        /// </summary>
        REO_GETOBJ_PSTG = 0x00000002,

        /// <summary>
        /// 选举事务处得到的obj polesite
        /// </summary>
        REO_GETOBJ_POLESITE = 0x00000004,

        /// <summary>
        /// 选举事务处得到的obj所有的接口
        /// </summary>
        REO_GETOBJ_ALL_INTERFACES = 0x00000007,
    }
}
