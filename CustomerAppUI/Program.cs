using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using System;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bLLFacade = new BLLFacade();

        static void Main(string[] args)
        {
            var cust1 = new CustomerBO()
            {
                FirstName = "Aldrin",
                LastName = "Diaz",
                Address = "123 Address"
            };

            bLLFacade.CustomerService.Create(cust1);

            bLLFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = "Aldrin2",
                LastName = "Diaz2",
                Address = "123 Address2"
            });

            //Console.WriteLine($"Name: {cust1.FirstName} {cust1.LastName}");

            string[] menuItems =
            {
                "List All Custormers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomers();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");
            Console.ReadLine();
        }

        private static void EditCustomers()
        {
            var customer = FindCustomerById();

            if(customer != null)
            { 
                Console.WriteLine("FirstName: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("LastName: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                customer.Address = Console.ReadLine();
                bLLFacade.CustomerService.Update(customer);
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }
        }

        private static CustomerBO FindCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bLLFacade.CustomerService.Get(id);
        }

        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerById();

            if(customerFound != null)
            { 
                bLLFacade.CustomerService.Delete(customerFound.Id);
            }

            var response = 
                customerFound == null ? "Customer not Found" : "Customer was Deleted";

            Console.WriteLine(response);

        }

        private static void AddCustomers()
        {
            Console.WriteLine("Firstname: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Lastname: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            bLLFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in bLLFacade.CustomerService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} " +
                    $"Name: {customer.FullName} " +
                    $"Address: {customer.Address}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            //Console.Clear();

            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                //OR
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("You need to select a number between 1-5");
            }

            return selection;
        }
    }
}
