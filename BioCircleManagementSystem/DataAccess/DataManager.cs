﻿using BioCircleManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioCircleManagementSystem.DataAccess
{
    class DataManager
    {
        #region DataManager
        //private instance
        private static DataManager _instance;
        private string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A18; User id=USER_A18; Password=SesamLukOp_18;";

        private DataManager()
        {

        }        

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
        public int GetNewestCustomerID()
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
            List<Customer> CustomerList = new List<Customer>();
            Customer customer;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spSearchKeyword", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", keyword));
                    
                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer = new Customer();
                            customer.CustomerID = Int32.Parse(reader["ID"].ToString());
                            customer.CustomerName = reader["Name"].ToString();
                            customer.EconomicsCustomerNumber = reader["EconomicsCustomerNO"].ToString();
                            customer.InstallationAddress = reader["InstallationAddress"].ToString();
                            customer.InstallationCity = reader["InstallationCity"].ToString();
                            customer.InstallationZipcode = reader["InstallationZipcode"].ToString();

                            customer.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(GetContacts(customer));
                            CustomerList.Add(customer);
                        }                        
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return CustomerList;
        }
  

        public void UpdateCustomer(Customer customer)
        {
            using(SqlConnection con = new SqlConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand EditCustomer = new SqlCommand("spUpdateCustomer", con);
                    EditCustomer.CommandType = CommandType.StoredProcedure;
                    EditCustomer.Parameters.Add(new SqlParameter("@Name", customer.CustomerName));
                    EditCustomer.Parameters.Add(new SqlParameter("@EconomicCustomerNumber", customer.EconomicsCustomerNumber));
                    EditCustomer.Parameters.Add(new SqlParameter("@BillingAddress", customer.BillingAddress));
                    EditCustomer.Parameters.Add(new SqlParameter("@BillingZipcode", customer.BillingZipcode));
                    EditCustomer.Parameters.Add(new SqlParameter("@BillingCity", customer.BillingCity));
                    EditCustomer.Parameters.Add(new SqlParameter("@InstallationAddress", customer.InstallationAddress));
                    EditCustomer.Parameters.Add(new SqlParameter("@InstallationZipcode", customer.InstallationZipcode));
                    EditCustomer.Parameters.Add(new SqlParameter("@InstallationCity", customer.InstallationCity));
                    EditCustomer.ExecuteNonQuery();                   
                }
                catch(SqlException e)
                {

                }
            }
        }
        public void DeleteCustomer(string customerID)
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

        public List<Contact> GetContacts(Customer customer)
        {
            List<Contact> contactList = new List<Contact>();
            Contact contact;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchContact= new SqlCommand("spGetContacts ", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchContact.Parameters.Add(new SqlParameter("@CustomerID", customer.CustomerID));

                    SqlDataReader reader = SearchContact.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contact = new Contact
                            {
                                ID = Int32.Parse(reader["ID"].ToString()),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Mobilephone = (reader["Mobilephone"].ToString()),
                                Landline = reader["Landline"].ToString(),
                                CustomerID = Int32.Parse(reader["Customer_ID"].ToString())
                            };
                            //customer.AddContact(contact);
                            contactList.Add(contact);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return contactList;
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateMachine = new SqlCommand("spCreateMachine", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateMachine.Parameters.Add(new SqlParameter("@VesselNo", machine.VesselNo));
                    CreateMachine.Parameters.Add(new SqlParameter("@VesselType", machine.VesselType));
                    CreateMachine.Parameters.Add(new SqlParameter("@MachineNo", machine.MachineNo));

                    Console.WriteLine("executing");
                    CreateMachine.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Machine GetMachine(string machineID)
        {
            throw new NotImplementedException();
        }

        public List<Machine> GetMachines(string keyword)
        {
            List<Machine> MachineList = new List<Machine>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {   
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spSearchMachines", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", keyword));
                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ID = reader["ID"].ToString();
                            string machineNo = reader["MachineNo"].ToString();
                            string vesselNo = reader["VesselNo"].ToString();
                            string vesselType = reader["VesselType"].ToString();

                            MachineList.Add(new Machine()
                            {
                                MachineNo = machineNo,
                                VesselNo = vesselNo,
                                VesselType = vesselType,
                            });
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return MachineList;
        }
        

        public void UpdateMachine(string machineID)
        {
            throw new NotImplementedException();
        }
        #endregion Machine
    }
}
