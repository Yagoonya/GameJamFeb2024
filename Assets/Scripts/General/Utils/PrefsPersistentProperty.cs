namespace Scripts.General.Utils
{
    public abstract class PrefsPersistentProperty<TPropertyType> : PersistantProperty<TPropertyType>
    {
        protected string Key;
        protected PrefsPersistentProperty(TPropertyType defaultValue, string key) : base(defaultValue)
        {
            Key = key;
        }
    }
}
