using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.Model
{
    class DataManager
    {
        #region DataManager
        //private instance
        private static DataManager _instance;
        private string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A18; User id=USER_A18; Password=SesamLukOp_18;";

        private DataManager() { }        

        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }
        #endregion DataManager

        #region Order
        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        
        public List<Order> GetOrders(string keyword)
        {
            //if key not null filter orders
            //return orders
            throw new NotImplementedException();
        }

        public void UpdateOrder(string orderID)
        {
            throw new NotImplementedException();
        }
        #endregion Order

        #region Customer
        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateCustomer = new SqlCommand("spCreateCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateCustomer.Parameters.Add(new SqlParameter("@Name", customer.CustomerName));
                    CreateCustomer.Parameters.Add(new SqlParameter("@EconomicCustomerNumber", customer.EconomicsCustomerNumber));
                    CreateCustomer.Parameters.Add(new SqlParameter("@BillingAddress", customer.BillingAddress));
                    CreateCustomer.Parameters.Add(new SqlParameter("@BillingZipcode", customer.BillingZipcode));
                    CreateCustomer.Parameters.Add(new SqlParameter("@BillingCity", customer.BillingCity));
                    CreateCustomer.Parameters.Add(new SqlParameter("@InstallationAddress", customer.InstallationAddress));
                    CreateCustomer.Parameters.Add(new SqlParameter("@InstallationZipcode", customer.InstallationZipcode));
                    CreateCustomer.Parameters.Add(new SqlParameter("@InstallationCity", customer.InstallationCity));
                    Console.WriteLine("executing");
                    CreateCustomer.ExecuteNonQuery();


                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Customer GetCustomer(string customerID)
        {
            throw new NotImplementedException();
        }

        //used when creating contacts for new customer
        public int GetLastCustomerID()
        {
            int result = -1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand LastID = new SqlCommand("spCustomerLastID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    result = (int)LastID.ExecuteScalar();
                    con.Close();
                }
                catch (SqlException e)
                {
                    //implement exception
                }
            }
            return result;
        }

        public List<Customer> GetCustomers(string keyword)
        {
            //if key not null filter customers
            //return customers
            throw new NotImplementedException();
        }

        public void UpdateCustomer(string customerID)
        {
            throw new NotImplementedException();
        }
        public void DeleteCustomer(string customerID, string machineID)
        {
            //Måske skal der laves noget vedd MachineID
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand DeleteCustomer = new SqlCommand("spDeleteCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DeleteCustomer.Parameters.Add(new SqlParameter("@Customerid", customerID));
                    DeleteCustomer.Parameters.Add(new SqlParameter("@Machineid", machineID));

                    Console.WriteLine("executing");
                    DeleteCustomer.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion Customer

        #region Contact
        public void CreateContact(Contact contact)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateContact = new SqlCommand("spCreateContact", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateContact.Parameters.Add(new SqlParameter("@Name", contact.Name));
                    CreateContact.Parameters.Add(new SqlParameter("@Mobilephone", contact.Mobilephone));
                    CreateContact.Parameters.Add(new SqlParameter("@Email", contact.Email));
                    CreateContact.Parameters.Add(new SqlParameter("@Landline", contact.Landline));
                    CreateContact.Parameters.Add(new SqlParameter("@CustomerID", contact.CustomerID));

                    CreateContact.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    //implement exception
                }
            }
        }

        public List<Contact> GetContacts(string keyword)
        {
            //if key not null filter contacts
            //return contacts
            throw new NotImplementedException();
        }

        public void UpdateContact(string contactMobilephone)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(string customerID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand DeleteContact = new SqlCommand("spDeleteCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DeleteContact.Parameters.Add(new SqlParameter("@Customerid", customerID));
                    

                    Console.WriteLine("executing");
                    DeleteContact.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion Contact

        #region Machine
        public void CreateMachine(Machine machine)
        {
            throw new NotImplementedException();
        }

        public Machine GetMachine(string machineID)
        {
            throw new NotImplementedException();
        }

        public List<Machine> GetMachines(string keyword)
        {           
            //if key not null filter machines
            //return machines
            throw new NotImplementedException();
        }
        

        public void UpdateMachine(string machineID)
        {
            throw new NotImplementedException();
        }
        #endregion Machine
    }
}
