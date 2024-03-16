namespace hw_attributes.Services
{
    public class Service5
    {
        string GetWork()
        {
            return "Hello World from IService5";
        }
    }

    public interface IService5
    {
        string GetWork();
    }
}
