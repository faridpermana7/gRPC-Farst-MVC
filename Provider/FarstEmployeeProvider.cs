using Grpc.Net.Client;
using GrpcEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFarstMvc.Provider
{
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

        public async Task<EmployeeResponse> GetEmployeeByID(long empID)
        {
            //port of services
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var employeeProvider = new EmployeeProvider.EmployeeProviderClient(channel); 

                return await employeeProvider.GetEmployeeByEmpIDAsync(new EmployeeRequest
                {
                    EmployeeID = empID
                });
            };
        }
    }
}
