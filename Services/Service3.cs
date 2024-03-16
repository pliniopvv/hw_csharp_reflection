namespace hw_attributes.Services
{
    public class Service3 : IService3
    {
        public string GetWork()
        {
            return "Hello World From IService3";
        }
    }
    public interface IService3
    {
        string GetWork();
    }
}
