
namespace AwsAPI
{
    public interface IAwsHandler
    {
        Task<Root?> GetOrderByGuid(string guid);
        Task<string?> SaveOrder(Root orderPayload);
    }
}