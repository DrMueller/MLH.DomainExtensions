﻿using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainModeling
{
    public abstract class Entity : Entity<object>
    {
        protected Entity(object id) : base(id)
        {
        }
    }

    [SuppressMessage("Microsoft.Maintainability", "SA1402:FileMayOnlyContainASingleType", Justification = "Makes sense to keep generic and non-generic together")]
    public abstract class Entity<TId>
    {
        public TId Id { get; }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        [SuppressMessage("", "IDE0041", Justification = "Actualy we must not simplify the ReferenceEquals")]
        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(obj is Entity<TId> compareTo))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id.ToString()).GetHashCode(System.StringComparison.Ordinal);
        }

        protected Entity(TId id)
        {
            Id = id;
        }
    }
}