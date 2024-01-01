using System;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace Dapper
{
    public static partial class SqlMapper
    {
        /// <summary>
        /// 缓存信息.
        /// 缓存反序列化读取器
        /// </summary>
        private class CacheInfo
        {
            /// <summary>
            /// 反序列化状态
            /// </summary>
            public DeserializerState Deserializer { get; set; }
            public Func<DbDataReader, object>[]? OtherDeserializers { get; set; }
            public Action<IDbCommand, object?>? ParamReader { get; set; }

            /// <summary>
            /// 缓存命中次数
            /// </summary>
            private int hitCount;

            /// <summary>
            /// 返回缓存命中次数
            /// </summary>
            /// <returns></returns>
            public int GetHitCount()
            {
                return Interlocked.CompareExchange(ref hitCount, 0, 0);
            }

            // 记录命中次数
            public void RecordHit()
            {
                Interlocked.Increment(ref hitCount);
            }
        }
    }
}
