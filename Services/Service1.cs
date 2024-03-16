using hw_attributes.Attributes;

namespace hw_attributes.Services
{
    [Help]
    [IgicService]
    public class Service1 : IService1
    {
        public string GetHelloWorld()
        {
            return "Hello World From IService1";
        }
    }
    public interface IService1
    {
        public string GetHelloWorld();
    }
}
