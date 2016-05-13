using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Client
{
    public class CustomerClient : BaseClient
    {
        public int Create(CustomerDto customer)
        {
            param.Clear();
            param["customer"] = customer;
            var response = Post<int>("Customer/Create");
            return response.Data;
        }

        public void Update(CustomerDto customer)
        {
            param.Clear();
            param["customer"] = customer;
            Post("Customer/Update");
        }

        public void Delete(int id)
        {
            param.Clear();
            param["id"] = id;
            Post("Customer/Delete");
        }

        public CustomerDto GetById(int id)
        {
            param.Clear();
            param["id"] = id;
            var response = Get<CustomerDto>("Customer/GetById");
            return response.Data;
        }

        public List<CustomerDto> GetCustomers(string name)
        {
            param.Clear();
            param["name"] = name;
            var response = Post<List<CustomerDto>>("Customer/GetCustomers");
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                return new List<CustomerDto>();
            }
        }
    }
}
