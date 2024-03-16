using hw_attributes.Attributes;

namespace hw_attributes.Services
{
    [IgicService(ServiceType.CLASS)]
    public class Service2 : IService2
    {
    }

    [IgicService(ServiceType.INTERFACE)]
    public interface IService2
    {
    }
}
