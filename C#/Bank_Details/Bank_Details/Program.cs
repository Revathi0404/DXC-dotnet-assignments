using System;
using System.Collections.Generic;
using System.Linq;
namespace Bank_Details
{
    class Program
    {
        static int IdCounter = 1;
        static HashSet<string> UsedIds = new HashSet<string>();

        class Customer
        {
            public string Id { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public string PhoneNumber { get; }
            public string Address { get; }
            public string Taluk { get; }
            public string Village { get; }

            public Customer(string firstName, string lastName, string phone, string address, string taluk, string village)
            {
                Id = GenerateCustomerId();
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phone;
                Address = address;
                Taluk = taluk;
                Village = village;
            }
            private string GenerateCustomerId()
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string id;
                do
                {
                    id = new string(Enumerable.Repeat(chars, 6)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                } while (UsedIds.Contains(id));
                UsedIds.Add(id);
                return id;
            }


            public override string ToString()
            {
                return string.Format("{0,-5} | {1,-15} | {2,-15} | {3,-12} | {4,-20} | {5,-15} | {6,-15}", Id, FirstName, LastName, PhoneNumber, Address, Taluk, Village);
            }
        }

        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();

            while (true)
            {
                Console.WriteLine("Enter a choice:");
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Display all customers");
                Console.WriteLine("3. Search by last name");

                string choice = Console.ReadLine();
                Console.WriteLine();


                switch (choice)
                {
                    case "1":

                        Console.WriteLine("Enter customer details:");
                        Console.Write("First name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Phone number: ");
                        string phone = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Taluk: ");
                        string taluk = Console.ReadLine();
                        Console.Write("Village: ");
                        string village = Console.ReadLine();


                        if (phone.Length != 10 || !phone.All(char.IsDigit) || !phone.Substring(0, 3).All(char.IsDigit) || !phone.Substring(3).All(char.IsDigit))
                        {
                            Console.WriteLine("Invalid phone number. Please enter a 10-digit number with 3-digit state code and 7-digit phone number.");
                            break;
                        }



                        Customer customer = new Customer(firstName, lastName, phone, address, taluk, village);
                        customers.Add(customer);

                        Console.WriteLine("Customer added successfully with ID {0}\n", customer.Id);
                        break;

                    case "2":
                        if (customers.Count == 0)
                        {
                            Console.WriteLine("No customers to display.\n");
                        }
                        else
                        {
                            Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-12} | {4,-20} | {5,-15} | {6,-15}", "ID", "First Name", "Last Name", "Phone", "Address", "Taluk", "Village");
                            Console.WriteLine(new string('-', 97));
                            foreach (Customer c in customers)
                            {
                                Console.WriteLine(c);
                            }
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        Console.Write("Enter last name to search: ");
                        string lastNameToSearch = Console.ReadLine();

                        List<Customer> customersByLastName = customers.Where(c => c.LastName.ToLower() == lastNameToSearch.ToLower()).ToList();

                        if (customersByLastName.Count == 0)
                        {
                            Console.WriteLine("No customers found with last name '{0}'.\n", lastNameToSearch);
                        }
                        else
                        {
                            Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-12} {4,-20} {5,-15} {6,-15}", "ID", "First Name", "Last Name", "Phone", "Address", "Taluk", "Village");
                            foreach (Customer c in customersByLastName)
                            {
                                Console.WriteLine(c);
                            }
                            Console.WriteLine();
                        }

                        break;

                    case "4":
                        Console.Write("Enter taluk to search: ");
                        string talukToSearch = Console.ReadLine();

                        List<Customer> customersByTaluk = customers.Where(c => c.Taluk.ToLower() == talukToSearch.ToLower()).ToList();

                        if (customersByTaluk.Count == 0)
                        {
                            Console.WriteLine("No customers found in taluk '{0}'.\n", talukToSearch);
                        }
                        else
                        {
                            Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-12} {4,-20} {5,-15} {6,-15}", "ID", "First Name", "Last Name", "Phone", "Address", "Taluk", "Village");
                            foreach (Customer c in customersByTaluk)
                            {
                                Console.WriteLine(c);
                            }
                            Console.WriteLine();
                        }

                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.\n");
                        break;
                }
            }
        }
    }
}
