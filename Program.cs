using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AwsAPI;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
builder.Services.AddScoped<IAwsHandler, AwsHandler>();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGet("/getOrder", async (IAwsHandler awsHandler) =>
{
    Root? result = await awsHandler.GetOrderByGuid("3dc65668-4f8a-40ac-abc7-fe62cc0cf11f");
    if (result == null)
        return Results.BadRequest();
    return Results.Ok(result.orderId);
});

app.MapPost("/saveOrder", async (IAwsHandler awsHandler) =>
{
    Root payload = new()
    {
        brandId = "",
        cancelMessage = "",
        cancelReason = "",
        chainId = "",
        courier = "",
        createdDate = DateTime.Now,
        customerId =  36699,
        integrationCompleted = false,
        isScheduled = false,
        order = new Order
        {
            courier = "Restraunt",
            customer = new Customer
            {
                city = "Breezanddijk",
                companyName = "",
                extraAddressInfo = "",
                name = "vehbi emiroglu",
                phoneNumber = "12212121212121",
                postalCode = "8766 TS",
                street = "A7",
                streetNumber = "9"
            },
            deliveryCosts = 0,
            discounts = new List<object>(),
            id = "3dc65668-4f8a-40ac-abc7-fe62cc0cf11f",
            isPaid = false,
            orderDate = DateTime.Now,
            orderKey = "8106D37EC882E84F354C17F6B1D9D9FD",
            orderType = "delivery",
            paymentMethod = "cash",
            paysWith = 35,
            platform = "Thuisbezorgd.nl",
            products = new List<Product>()
            {
                new Product()
                {
                    category = "Mixed grill",
                    count = 1,
                    id = "31",
                    name = "Grill plateau 2",
                    price = 30,
                    remark = "",
                    sideDishes = new()
                    {
                        new()
                        {
                            count = 1,
                            name = "Geen saus",
                            price = 0
                        },
                        new()
                        {
                            count = 1,
                            name = "Friet",
                            price = 0
                        }
                    }
                },
                new()
                {
                    category = "Broodjes",
                    count = 1,
                    id = "1",
                    name = "Durum",
                    price = 5,
                    remark = "",
                    sideDishes = new()
                    {
                        new()
                        {
                            count = 1,
                            name = "Broodjes",
                            price = 0
                        },
                        new()
                        {
                            count = 1,
                            name = "Green saus",
                            price = 0
                        },
                        new()
                        {
                            count = 1,
                            name = "Green saus",
                            price = 0
                        }
                    }
                }
            },
            publicReference = "83TB6C",
            remark = "",
            requestedDeliveryTime = "ASAP",
            restaurantId = "3807440",
            serviceFee = 0,
            totalDiscount = 0,
            totalPrice = 35,
            version = "1.1"
        },
        orderId = Guid.NewGuid().ToString(),
        orderKey = "8106D37EC882E84F354C17F6B1D9D9FD",
        preOrder = false,
        provider = "Takeaway",
        restaurantId = "3807440",
        scheduledDate = DateTime.Now,
        status = 100,
        updatedDate = DateTime.Now,
    };
    string? Id = await awsHandler.SaveOrder(payload);
    if (Id != null)
        return Results.Ok(Id);
    return Results.BadRequest(Id);
});


app.Run();