# gRPCFarstMVC 
### AUTHOR : FARID PERMANA

This is a web application MVC .NET Core which uses gRHCP as the service.

## TO DO: 
 -  Add Connected Service with (gRPC)
 -  Choose file (browse with proto file on gRPC service)
 -  Make Provider to connecting controller with service
 -  Show on Employee Page


## Example Provider :

     public class FarstEmployeeProvider
    {

        public async Task<EmployeeResponse> GetEmployee(long memberID)
        {
            //port of services
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var employeeProvider = new EmployeeProvider.EmployeeProviderClient(channel);

                var response = employeeProvider.GetEmployee(new EmployeeRequest { 
                    MemberID = memberID 
                });

                return response;
            };
        } 
    }
 

**EXPLAIN**
> **GrpcChannel** : Represents a gRPC channel. Channel are an abstraction of long-live connections to remote service.  
> **Grpc.Net.Client** : Don't forget to add this package to set up package on client.   
