using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MerchandiseService.Domain.Models
{
    public abstract class Enumeration : IComparable, IEquatable<Enumeration>
    {
        protected Enumeration(int id, string name)
        {
            (Id, Name) = (id, name);
        }

        public string Name { get; }
        public int Id { get; }

        public int CompareTo(object? other)
        {
            return Id.CompareTo(((Enumeration?)other)?.Id);
        }

        public bool Equals(Enumeration? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Id == other.Id;
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(BindingFlags.Public |
                                       BindingFlags.Static |
                                       BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Enumeration)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }

        public static bool operator ==(Enumeration? left, Enumeration? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration? left, Enumeration? right)
        {
            return !Equals(left, right);
        }
    }
}