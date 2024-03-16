namespace hw_attributes.Attributes
{
    public class IgicServiceAttribute : Attribute
    {
        public ServiceType serviceType;
        public IgicServiceAttribute(ServiceType type)
        {
            this.serviceType = type;
        }
    }

    public enum ServiceType
    {
        CLASS,
        INTERFACE
    }
}
