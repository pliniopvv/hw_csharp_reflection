using hw_attributes.Attributes;

namespace hw_attributes.Services
{
    [IgicService]
    public class Service7 : GenericService<int>, IService7
    {
    }
    public interface IService7 : IGenericService<int>
    {
    }
}
