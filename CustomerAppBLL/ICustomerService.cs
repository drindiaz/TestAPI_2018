using CustomerAppBLL.BusinessObjects;
using System.Collections.Generic;

namespace CustomerAppBLL
{
    /// <summary>
    /// Customer Service
    /// </summary>
    public interface ICustomerService
    {
        //Create
        CustomerBO Create(CustomerBO cust);

        //Read
        IEnumerable<CustomerBO> GetAll();
        CustomerBO Get(int Id);

        //U
        CustomerBO Update(CustomerBO cust);

        //D
        CustomerBO Delete(int Id);

    }
}
