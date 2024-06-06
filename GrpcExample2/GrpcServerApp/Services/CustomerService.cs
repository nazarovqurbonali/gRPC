using Grpc.Core;

namespace GrpcServerApp.Services;

public class CustomerService(ILogger<CustomerService> logger) : Customer.CustomerBase
{
    private readonly List<CustomerModel> _customers =
    [
        new CustomerModel()
        {
            FirstName = "John",
            LastName = "Doe",
            EmailAddress = "John@example.com",
            Age = 23,
            IsAlive = true,
            UserId = 1
        },

        new CustomerModel()
        {
            UserId = 2,
            FirstName = "Ammy",
            LastName = "Doe",
            EmailAddress = "John@example.com",
            Age = 23,
            IsAlive = true
        }

    ];
        
    public override Task<CustomerModel?> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
        var find = _customers.Find(c => c.UserId == request.UserId);
        return  Task.FromResult(find);
      
    }
}