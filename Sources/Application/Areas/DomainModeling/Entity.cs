using System;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainModeling
{
    public abstract class Entity
    {
        protected Entity(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(compareTo, null))
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

            return Id == compareTo.Id;
        }

        public override int GetHashCode() => (GetType() + Id).GetHashCode();

        public static bool operator ==(Entity a, Entity b)
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

        public static bool operator !=(Entity a, Entity b) => !(a == b);
    }
}