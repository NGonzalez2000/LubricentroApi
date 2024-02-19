namespace Lubricentro.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (obj is ValueObject vo)
        {
            return GetEqualityComponents().SequenceEqual(vo.GetEqualityComponents());
        }
        return false;
    }
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return left.Equals(right);
    }
    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !left.Equals(right);
    }
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x,y) =>  x ^ y);
    }
    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}
