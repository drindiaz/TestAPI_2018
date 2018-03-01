using CustomerAppDAL.Entities;
using System.Collections.Generic;

namespace CustomerAppDAL
{
    public interface ICustomerRepository
    {
        //Create
        Customer Create(Customer cust);

        //Read
        IEnumerable<Customer> GetAll();
        Customer Get(int Id);

        //Delete
        Customer Delete(int Id);
    }
}
