namespace Muscat.Core.SharedKernel;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (left is null)
        {
            if (right is null)
            {
                return true;
            }

            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
        => !(left == right);

    public bool Equals(ValueObject? other)
    {
        if (other is null)
        {
            return false;
        }

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
        => Equals(obj as ValueObject);

    public override int GetHashCode()
        => GetEqualityComponents()
        .Select(component => component is not null ? component.GetHashCode() : 0)
        .Aggregate((x, y) => x ^ y);

    protected abstract IEnumerable<object> GetEqualityComponents();
}
