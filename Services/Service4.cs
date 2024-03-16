using hw_attributes.Attributes;

namespace hw_attributes.Services
{
    [IgicService(ServiceType.CLASS)]
    public class Service4 : Service3, IService4
    {
    }

    [IgicService(ServiceType.INTERFACE)]
    public interface IService4
    {
    }
}
