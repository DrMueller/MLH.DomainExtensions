namespace Mmu.Mlh.DomainExtensions.Areas.DomainModeling
{
    public abstract class Entity : Entity<object>
    {
        protected Entity(object id) : base(id)
        {
        }
    }

    public abstract class Entity<TId>
    {
        public TId Id { get; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TId>;

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

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id.ToString()).GetHashCode();
        }

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

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }
    }
}