using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Amazon;

namespace AwsAPI
{
    public class AwsHandler : IAwsHandler
    {
        private IDynamoDBContext dynamoDBContext { get; set; }
        public AwsHandler(IDynamoDBContext dynamoDBContext)
        {
            this.dynamoDBContext = dynamoDBContext;
        }
        public async Task<Root?> GetOrderByGuid(string guid)
        {
            var order = await dynamoDBContext.LoadAsync<Root>(guid);
            return order;
        }

        public async Task<string?> SaveOrder(Root orderPayload)
        {
            var order = await dynamoDBContext.LoadAsync<Root>(orderPayload.orderId);
            if (order != null)
                return "Order with given Id already exists";

            Task result = dynamoDBContext.SaveAsync(orderPayload);
            await result.WaitAsync(TimeSpan.FromSeconds(5.0));
            if (result.IsCompletedSuccessfully)
            {
                return orderPayload.orderId;
            }
            return "Order couldn't saved";
        }

        public async Task<string> UpdateOrderAttribute(Root orderPayload)
        {
            var student = await dynamoDBContext.LoadAsync<Root>(orderPayload.orderId);
            if (student != null)
                return "Order does not exist";
            Task result = dynamoDBContext.SaveAsync(orderPayload);
            await result.WaitAsync(TimeSpan.FromSeconds(5.0));
            if (result.IsCompletedSuccessfully)
            {
                return orderPayload.orderId;
            }
            return "Order couldn't updated";
        }
    }
}
