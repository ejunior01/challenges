namespace ParkingFlow.WebApi.Common.Abstracts;
public abstract class Entity : IEquatable<Entity>
{
    protected Entity() => Id = Guid.NewGuid();
    public Guid Id { get; private set; }

    public override bool Equals(object obj) => Equals(obj as Entity);

    public bool Equals(Entity? other)
    {
        if (other is not Entity entity)
            return false;

        return Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

}