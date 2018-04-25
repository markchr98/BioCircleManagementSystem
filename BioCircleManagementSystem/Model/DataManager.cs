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
                    CreateCustomer.Parameters.Add(new SqlParameter("@EconomicsCustomerNumber", customer.EconomicsCustomerNumber));
                    CreateCustomer.Parameters.Add(new SqlParameter("@BillingAddress", customer.CustomerName));
                    CreateCustomer.Parameters.Add(new SqlParameter("@BillingZipcode", customer.CustomerName));
                    CreateCustomer.Parameters.Add(new SqlParameter("@BillingCity", customer.CustomerName));
                    CreateCustomer.Parameters.Add(new SqlParameter("@InstallationAddress", customer.CustomerName));
                    CreateCustomer.Parameters.Add(new SqlParameter("@InstallationZipcode", customer.CustomerName));
                    CreateCustomer.Parameters.Add(new SqlParameter("@InstallationCity", customer.CustomerName));

                    CreateCustomer.ExecuteNonQuery();


                }
                catch (SqlException e)
                {
                    //implement exception
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
                    SqlDataReader reader = LastID.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Int32.Parse(reader["ID"].ToString());                            
                        }                        
                    }
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
                    CreateContact.Parameters.Add(new SqlParameter("@Mobile_Phone", contact.Mobilephone));
                    CreateContact.Parameters.Add(new SqlParameter("@Email", contact.Email));
                    CreateContact.Parameters.Add(new SqlParameter("@Landline", contact.Landline));
                    CreateContact.Parameters.Add(new SqlParameter("@Customer_ID", contact.CustomerID));

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
    }
}
