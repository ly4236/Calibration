using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C.Core.Domain.Users;

namespace C.Core
{
    public abstract partial class BaseEntity : IEquatable<BaseEntity>
    {
        public int Id { get; set; }

        public Type GetUnproxiedType()
        {
            var t = GetType();
            if (t.AssemblyQualifiedName.StartsWith("System.Data.Entity."))
            {
                // it's a proxied type
                t = t.BaseType;
            }
            return t;
        }
        /// <summary>
        /// 是否是暂时记录
        /// 比如，一个的用户Id为0，那么这个实体是未保存的，是暂时的。
        /// </summary>
        /// <returns></returns>
        public virtual bool IsTransientRecord()
        {
            return Id == 0;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BaseEntity);
        }

        bool IEquatable<BaseEntity>.Equals(BaseEntity other)
        {
            return this.Equals(other);
        }
        protected virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (HasSameNonDefaultIds(other))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.Equals(otherType);
            }

            return false;
        }


        public override int GetHashCode()
        {
            if (IsTransientRecord())
            {
                return base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    // It's possible for two objects to return the same hash code based on
                    // identically valued properties, even if they're of two different types,
                    // so we include the object's type in the hash calculation
                    var hashCode = GetUnproxiedType().GetHashCode();
                    return (hashCode * 31) ^ Id.GetHashCode();
                }
            }
        }

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }

        /// <summary>
        /// 所有实体数据皆有创建人、创建时间、最后一次人为修改的修改人和修改时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public User CreateUser { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public User LastUpdateUser { get; set; }



        private bool HasSameNonDefaultIds(BaseEntity other)
        {
            return !this.IsTransientRecord() && !other.IsTransientRecord() && this.Id == other.Id;
        }

    }
}
