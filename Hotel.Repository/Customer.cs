using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public class Customer : BaseRepository<CustomerDto>
    {
        public int Create(CustomerDto customer)
        {
            return Execute<int>("spCreateCustomer", ParameterBuilder.BuildExclude(customer, "Id"));
        }

        public void Update(CustomerDto customer)
        {
            Execute("spUpdateCustomer", ParameterBuilder.BuildExclude(customer));
        }

        public void Delete(int id)
        {
            Execute("spDeleteCustomer", new { Id = id });
        }

        public CustomerDto GetById(int id)
        {
            return Get("spGetCustomerById", new { Id = id });
        }

        public IEnumerable<CustomerDto> GetAllByNameOrSurname(string name)
        {
            return GetAll("spGetCustomersByNameOrSurname", new { Name = name });
        }
    }
}
