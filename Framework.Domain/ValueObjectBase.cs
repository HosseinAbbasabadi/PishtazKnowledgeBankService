using Framework.Core;

namespace Framework.Domain
{
    public abstract class ValueObjectBase
    {
        public override bool Equals(object obj)
        {
            return obj != null && (obj.GetType() == this.GetType() && EqualsBuilder.ReflectionEquals(this, obj));
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode(this);
        }
    }
}