using hw_attributes.Attributes;

namespace hw_attributes.Services
{
    [Help]
    [IgicService(ServiceType.CLASS)]
    public class Service1 : IService1
    {
    }
    
    [IgicService(ServiceType.INTERFACE)]
    public interface IService1
    {
    }
}
