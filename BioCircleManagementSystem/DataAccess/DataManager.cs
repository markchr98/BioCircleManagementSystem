using BioCircleManagementSystem.Model;
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateOrder = new SqlCommand("spCreateOrder", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateOrder.Parameters.Add(new SqlParameter("@CustomerID", order.Customer.CustomerID));
                    CreateOrder.Parameters.Add(new SqlParameter("@MachineID", order.Machine.MachineNo));

                    CreateOrder.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public List<Order> GetOrders(string keyword)
        {
            List<Order> OrderList = new List<Order>();
            Order order = new Order();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spSearchOrders", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", keyword));
                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int ID = Int32.Parse(reader["ID"].ToString());
                            int customerID = Int32.Parse(reader["Customer_ID"].ToString());
                            int machineID = Int32.Parse(reader["Machine_ID"].ToString());

                            order.OrderID = ID;
                            order.Customer = GetCustomer(customerID);
                            order.Machine = GetMachine(machineID);
                            //

                            OrderList.Add(order);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return OrderList;
        }

        internal void CreateService(Service service)
        {
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

                    Console.WriteLine("executing");
                    CreateCustomer.ExecuteNonQuery();


                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Customer GetCustomer(int customerID)
        {
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetCustomerFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", customerID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer = new Customer();
                            customer.CustomerID = Int32.Parse(reader["ID"].ToString());
                            customer.CustomerName = reader["Name"].ToString();
                            customer.EconomicsCustomerNumber = reader["EconomicsCustomerNO"].ToString();
                            customer.BillingAddress = reader["BillingAddress"].ToString();
                            customer.BillingCity = reader["BillingCity"].ToString();
                            customer.BillingZipcode = reader["BillingZipcode"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return customer;
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
                            customer.BillingAddress = reader["BillingAddress"].ToString();
                            customer.BillingCity = reader["BillingCity"].ToString();
                            customer.BillingZipcode = reader["BillingZipcode"].ToString();

                            customer.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(GetContacts(customer));
                            //

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
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand EditCustomer = new SqlCommand("spUpdateCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    EditCustomer.Parameters.Add(new SqlParameter("@ID", customer.CustomerID));
                    EditCustomer.Parameters.Add(new SqlParameter("@Name", customer.CustomerName));
                    EditCustomer.Parameters.Add(new SqlParameter("@EconomicsCustomerNo", customer.EconomicsCustomerNumber));
                    EditCustomer.Parameters.Add(new SqlParameter("@BillingAddress", customer.BillingAddress));
                    EditCustomer.Parameters.Add(new SqlParameter("@BillingZipcode", customer.BillingZipcode));
                    EditCustomer.Parameters.Add(new SqlParameter("@BillingCity", customer.BillingCity));
                    EditCustomer.ExecuteNonQuery();                   
                }
                catch(SqlException e)
                {

                }
            }
        }
        public void DeleteCustomer(Customer customer)
        { 
            //Måske skal der laves noget vedd MachineID
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand DelCustomer = new SqlCommand("spDeleteCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DelCustomer.Parameters.Add(new SqlParameter("@CustomerID", customer.CustomerID));
           
                    Console.WriteLine("executing");
                    DelCustomer.ExecuteNonQuery();
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
                    CreateContact.Parameters.Add(new SqlParameter("@Customer_ID", contact.CustomerID));

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
                    CreateMachine.Parameters.Add(new SqlParameter("@ControlBoxNo", machine.ControlBoxNo));

                    Console.WriteLine("executing");
                    CreateMachine.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    
                }
            }
        }

        public void CreateVesselType(string vesselType)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateVesselType = new SqlCommand("spCreateVesselType", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateVesselType.Parameters.Add(new SqlParameter("@VesselType", vesselType));

                    CreateVesselType.ExecuteNonQuery();
                }
                catch(SqlException e)
                {

                }
            }
        }

        public void DeleteVesselType(int vesselType_ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateVesselType = new SqlCommand("spDeleteVesselType", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateVesselType.Parameters.Add(new SqlParameter("@VesselType_ID", vesselType_ID));

                    CreateVesselType.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                }
            }
        }

        public Machine GetMachine(int machineID)
        {
            Machine machine = new Machine();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetMachineFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", machineID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            machine = new Machine();
                            machine.MachineNo = reader["MachineNo"].ToString();
                            machine.VesselType = reader["VesselType"].ToString();
                            machine.VesselNo = reader["VesselNo"].ToString();
                            machine.CustomerID = Int32.Parse(reader["Customer_ID"].ToString());
                            machine.ControlBoxNo = reader["ControlBoxNo"].ToString();
                            machine.Brush = reader["Brush_ID"].ToString();
                            machine.Filters = reader["Filters_ID"].ToString();
                            machine.Wheels = reader["Wheels"].ToString();
                            machine.Lid = reader["Lid"].ToString();
                            machine.InstallationDate = reader["InstallationDate"].ToString();
                            machine.InoxGrid = reader["InoxGrid"].ToString();
                            machine.SteelTop = reader["SteelTop_ID"].ToString();
                            machine.Liquid = reader["Liquid_ID"].ToString();
                            machine.Status = reader["Status_ID"].ToString();
                            machine.ServiceInterval = Int32.Parse(reader["ServiceInterval"].ToString());
                            machine.ServiceContract = Boolean.Parse(reader["ServiceContract"].ToString());
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return machine;
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
                            string controlBoxNo = reader["ControlBoxNo"].ToString();

                            MachineList.Add(new Machine()
                            {
                                MachineNo = machineNo,
                                VesselNo = vesselNo,
                                VesselType = vesselType,
                                ControlBoxNo = controlBoxNo,
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
        

        public void UpdateOrderMachine(Machine machine)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand UpdateOrderMachine = new SqlCommand("spUpdateMachine", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@InstallationDate", machine.InstallationDate));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Wheels", machine.Wheels));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@InoxGrid", machine.InoxGrid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Lid", machine.Lid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@SteelTop", machine.SteelTop));

                    UpdateOrderMachine.ExecuteNonQuery();


                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void UpdateMachine(Machine machine)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand UpdateOrderMachine = new SqlCommand("spUpdateMachine", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@MachineNo", machine.MachineNo));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@VesselType", machine.VesselType));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@VesselNo", machine.VesselNo));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@ControlBoxNo", machine.ControlBoxNo));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@InstallationDate", machine.InstallationDate));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Wheels", machine.Wheels));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@InoxGrid", machine.InoxGrid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Lid", machine.Lid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@SteelTop_ID", machine.SteelTop));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Customer_ID", machine.CustomerID));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Filters_ID", machine.Filters));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Brush_ID", machine.Brush));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Liquid_ID", machine.Liquid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Status_ID", machine.Status));

                    UpdateOrderMachine.ExecuteNonQuery();


                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        #endregion Machine

        #region Service

        public void CreateService()
        {

        }

        public void GetServices()
        {

        }

        public void GetService()
        {

        }

        #endregion

        #region Department

        public void CreateDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand CreateDepartment = new SqlCommand("spCreateDepartment", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    CreateDepartment.Parameters.Add(new SqlParameter("@InstallationAddress", department.InstallationAddress));
                    CreateDepartment.Parameters.Add(new SqlParameter("@InstallationCity", department.InstallationCity));
                    CreateDepartment.Parameters.Add(new SqlParameter("@InstallationZipcode", department.InstallationZipcode));
                    CreateDepartment.Parameters.Add(new SqlParameter("@CanBringLiquid", department.CanBringLiquid));
                    CreateDepartment.Parameters.Add(new SqlParameter("@Customer_ID", department.CustomerID));

                    CreateDepartment.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public List<Department> GetDepartments(string keyword)
        {
            List<Department> DepartmentList = new List<Department>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spSearchDepartment", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", keyword));
                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string installationAddress = reader["InstallationAddress"].ToString();
                            string installationCity = reader["InstallationCity"].ToString();
                            string installationZipcode = reader["InstallationZipcode"].ToString();
                            string canBringLiquid = reader["CanBringLiquid"].ToString();
                            string customerID = reader["Customer_ID"].ToString();



                            DepartmentList.Add(new Department()
                            {
                                InstallationAddress = installationAddress,
                                InstallationCity = installationCity,
                                InstallationZipcode = installationZipcode,                             
                                CanBringLiquid = canBringLiquid,
                                CustomerID = customerID,
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
            return DepartmentList;
        }

        public void GetDepartment()
        {

        }
        #endregion

        #region Brush

        public void CreateBrush(Brush brush)
        {
            throw new NotImplementedException();
        }

        public List<Brush> GetBrushes(string keyword)
        {
            //if key not null filter customers
            //return customers
            List<Brush> BrushList = new List<Brush>();
            Brush brush;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchBrush = new SqlCommand("spSearchBrush", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchBrush.Parameters.Add(new SqlParameter("@Keyword", keyword));

                    SqlDataReader reader = SearchBrush.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            brush = new Brush();
                            brush.Type = reader["Type"].ToString();
                            
                            BrushList.Add(brush);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
                return BrushList;
            }
        }
        #endregion

        #region Liquid

        public void CreateLiquid(Liquid liquid)
        {

        }

        public List<Liquid> GetLiquids(string keyword)
        {
            List<Liquid> LiquidList = new List<Liquid>();
            Liquid liquid;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchLiquid = new SqlCommand("spSearchLiquid", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchLiquid.Parameters.Add(new SqlParameter("@Keyword", keyword));

                    SqlDataReader reader = SearchLiquid.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            liquid = new Liquid();
                            liquid.Type = reader["Type"].ToString();

                            LiquidList.Add(liquid);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
                return LiquidList;
            }
        }

        #endregion

        #region Filters

        public void CreateFilters(Filters filters)
        {
            
        }

        public List<Filters> GetFilters(string keyword)
        {
            List<Filters> FiltersList = new List<Filters>();
            Filters filters;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchFilters = new SqlCommand("spSearchFilters", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchFilters.Parameters.Add(new SqlParameter("@Keyword", keyword));

                    SqlDataReader reader = SearchFilters.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            filters = new Filters();
                            filters.Type = reader["Type"].ToString();
                            filters.TypeHouse = reader["TypeHouse"].ToString();

                            FiltersList.Add(filters);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
                return FiltersList;
            }
        }

        #endregion

        #region SteelTop

        public void CreateSteeltop(Steeltop steeltop)
        {

        }

        public List<Steeltop> GetSteeltops(string keyword)
        {
            List<Steeltop> SteeltopList = new List<Steeltop>();
            Steeltop steeltop;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchSteeltop = new SqlCommand("spSearchSteeltop", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchSteeltop.Parameters.Add(new SqlParameter("@Keyword", keyword));

                    SqlDataReader reader = SearchSteeltop.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            steeltop = new Steeltop();
                            steeltop.Type = reader["Type"].ToString();

                            SteeltopList.Add(steeltop);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
                return SteeltopList;
            }
        }

        #endregion

        #region status
        public List<Status> GetStatus(string keyword)
        {
            List<Status> StatusList = new List<Status>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchStatus = new SqlCommand("spSearchStatus", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchStatus.Parameters.Add(new SqlParameter("@Keyword", keyword));
                    SqlDataReader reader = SearchStatus.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string status = reader["Status"].ToString();

                            StatusList.Add(new Status()
                            {
                                CurrentStatus = status
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
            return StatusList;
        }
        #endregion
    }
}
