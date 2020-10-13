# gRPCFarstMVC 
![Hex.pm](https://img.shields.io/hexpm/l/grpc) ![GitHub release (latest by date)](https://img.shields.io/github/v/release/faridpermana7/gRPCFarstMVC) ![GitHub issues](https://img.shields.io/github/issues/faridpermana7/grpcfarstmvc)

### AUTHOR : FARID PERMANA
 
## Preview: 
![alt text](https://github.com/faridpermana7/gRPCFarstMVC/blob/master/img/list_employee_4.PNG "SC")

## What's new
What's new in version 0.1.5
  1. add service reference with gRPC service
  2. pagination with pageSize

## Configuration: 
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
