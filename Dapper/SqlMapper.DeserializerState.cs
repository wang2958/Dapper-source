using System;
using System.Data;
using System.Data.Common;

namespace Dapper
{
    public static partial class SqlMapper
    {
        /// <summary>
        /// 反序列化过程中的状态信息的类
        /// </summary>
        private readonly struct DeserializerState
        {
            public readonly int Hash;
            public readonly Func<DbDataReader, object> Func;

            public DeserializerState(int hash, Func<DbDataReader, object> func)
            {
                Hash = hash;
                Func = func;
            }
        }
    }
}
