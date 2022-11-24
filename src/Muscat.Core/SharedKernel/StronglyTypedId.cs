namespace Muscat.Core.SharedKernel;

public abstract class StronglyTypedId : IEquatable<StronglyTypedId>
{
    protected StronglyTypedId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("A strongly-typed ID cannot be an empty value.", nameof(value));
        }

        Value = value;
    }

    public Guid Value { get; }

    public static bool operator ==(StronglyTypedId a, StronglyTypedId b)
    {
        if (a is null)
        {
            return b is null;
        }

        return a.Equals(b);
    }

    public static bool operator !=(StronglyTypedId a, StronglyTypedId b)
        => !(a == b);

    public override bool Equals(object? obj)
        => Equals(obj as StronglyTypedId);

    public bool Equals(StronglyTypedId? other)
    {
        if (other is null)
        {
            return false;
        }

        return Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
