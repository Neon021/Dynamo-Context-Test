using Amazon.DynamoDBv2.DataModel;

namespace AwsAPI
{
    public class Customer
    {
        public string city { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string postalCode { get; set; }
        public string street { get; set; }
        public string streetNumber { get; set; }
        public string companyName { get; set; }
        public string extraAddressInfo { get; set; }
    }

    public class SideDish
    {
        public int count { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }

    public class Product
    {
        public string category { get; set; }
        public int count { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string id { get; set; }
        public string remark { get; set; }
        public List<SideDish> sideDishes { get; set; }
    }

    public class Order
    {
        public Customer customer { get; set; }
        public List<object> discounts { get; set; }
        public string id { get; set; }
        public bool isPaid { get; set; }
        public DateTime orderDate { get; set; }
        public string orderKey { get; set; }
        public string orderType { get; set; }
        public string paymentMethod { get; set; }
        public string platform { get; set; }
        public List<Product> products { get; set; }
        public string publicReference { get; set; }
        public string restaurantId { get; set; }
        public double totalDiscount { get; set; }
        public double totalPrice { get; set; }
        public string version { get; set; }
        public string courier { get; set; }
        public double deliveryCosts { get; set; }
        public double paysWith { get; set; }
        public string remark { get; set; }
        public string requestedDeliveryTime { get; set; }
        public double serviceFee { get; set; }
    }

    [DynamoDBTable("GoOrderTAGFOrders")]
    public class Root
    {
        public string brandId { get; set; }
        public string cancelMessage { get; set; }
        public string cancelReason { get; set; }
        public string chainId { get; set; }
        public string courier { get; set; }
        public DateTime createdDate { get; set; }
        public int customerId { get; set; }
        public bool integrationCompleted { get; set; }
        public bool isScheduled { get; set; }
        public Order order { get; set; }
        public string orderKey { get; set; }
        public string orderId { get; set; }
        public bool preOrder { get; set; }
        public string provider { get; set; }
        public string restaurantId { get; set; }
        public DateTime scheduledDate { get; set; }
        public int status { get; set; }
        public DateTime updatedDate { get; set; }
    }
}
