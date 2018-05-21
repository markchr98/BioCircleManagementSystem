using BioCircleManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                    SqlCommand createOrder = new SqlCommand("spCreateOrder", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    createOrder.Parameters.Add(new SqlParameter("@CustomerID", order.Customer.CustomerID));
                    createOrder.Parameters.Add(new SqlParameter("@MachineID", order.Machine.ID));

                    createOrder.ExecuteNonQuery();
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
                    SqlCommand createCustomer = new SqlCommand("spCreateCustomer", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    createCustomer.Parameters.Add(new SqlParameter("@Name", customer.CustomerName));
                    createCustomer.Parameters.Add(new SqlParameter("@EconomicCustomerNumber", customer.EconomicsCustomerNumber));
                    createCustomer.Parameters.Add(new SqlParameter("@BillingAddress", customer.BillingAddress));
                    createCustomer.Parameters.Add(new SqlParameter("@BillingZipcode", customer.BillingZipcode));
                    createCustomer.Parameters.Add(new SqlParameter("@BillingCity", customer.BillingCity));

                    Console.WriteLine("executing");
                    createCustomer.ExecuteNonQuery();
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
                            machine.ControlBoxNo = reader["ControlBoxNo"].ToString();
                            machine.Wheels = reader["Wheels"].ToString();
                            machine.Lid = reader["Lid"].ToString();
                            machine.InstallationDate = reader.GetDateTime(reader.GetOrdinal("InstallationDate"));
                            machine.InoxGrid = reader["InoxGrid"].ToString();
                            machine.ServiceInterval = Int32.Parse(reader["ServiceInterval"].ToString());
                            machine.ServiceContract = Boolean.Parse(reader["ServiceContract"].ToString());

                            int SteelTopID = Int32.Parse(reader["SteelTop_ID"].ToString());
                            int LiquidID = Int32.Parse(reader["Liquid_ID"].ToString());
                            int StatusID = Int32.Parse(reader["Status_ID"].ToString());
                            int BrushID = Int32.Parse(reader["Brush_ID"].ToString());
                            int FiltersID = Int32.Parse(reader["Filters_ID"].ToString());
                            int CustomerID = Int32.Parse(reader["Customer_ID"].ToString());

                            machine.Customer = GetCustomer(CustomerID);
                            machine.Brush = GetBrush(BrushID);
                            machine.Filters = GetFilter(FiltersID);
                            machine.SteelTop = GetSteeltop(SteelTopID);
                            machine.Liquid = GetLiquid(LiquidID);
                            machine.Status = GetStatusByID(StatusID);
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

                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@ID", machine.ID));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@MachineNo", machine.MachineNo));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@VesselType", machine.VesselType));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@VesselNo", machine.VesselNo));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@ControlBoxNo", machine.ControlBoxNo));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@InstallationDate", machine.InstallationDate));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Wheels", machine.Wheels));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@InoxGrid", machine.InoxGrid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Lid", machine.Lid));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@SteelTop_ID", machine.SteelTop.ID));
                    //UpdateOrderMachine.Parameters.Add(new SqlParameter("@Customer_ID", machine.Customer.CustomerID));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Filters_ID", machine.Filters.ID));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Brush_ID", machine.Brush.ID));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Liquid_ID", machine.Liquid.ID));
                    UpdateOrderMachine.Parameters.Add(new SqlParameter("@Status_ID", machine.Status.ID));

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

        public void CreateService(Service service)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand createService = new SqlCommand("spCreateService", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    createService.Parameters.Add(new SqlParameter("@Date", service.Date));
                    createService.Parameters.Add(new SqlParameter("@Arrival", service.Arrival));
                    createService.Parameters.Add(new SqlParameter("@Depature", service.Depature));
                    createService.Parameters.Add(new SqlParameter("@PHValue", service.PHValue));
                    createService.Parameters.Add(new SqlParameter("@Temperature", service.Temperature));
                    createService.Parameters.Add(new SqlParameter("@Smell", service.Smell));
                    createService.Parameters.Add(new SqlParameter("@WeekNumber", service.WeekNumber));
                    createService.Parameters.Add(new SqlParameter("@NextWeekNumber", service.NextWeekNumber));
                    createService.Parameters.Add(new SqlParameter("@Machine_ID", service.Machine.ID));
                    createService.Parameters.Add(new SqlParameter("@Technician_ID", service.Technician.ID));

                    createService.ExecuteNonQuery();
                }
                catch(SqlException e)
                {

                }
            }
        }

        public List<Service> GetServices(string keyword)
        {
            List<Service> serviceList = new List<Service>();
            Service service = new Service();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetServiceFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", keyword));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            service = new Service();
                            service.ID = Int32.Parse(reader["ID"].ToString());
                            service.Arrival = Int32.Parse(reader["Arrival"].ToString());
                            service.Depature = Int32.Parse(reader["Departure"].ToString());
                            service.CleaningEffect = reader["CleaningEffect"].ToString();
                            service.PHValue = Int32.Parse(reader["Arrival"].ToString());
                            service.Temperature = Int32.Parse(reader["Temperature"].ToString());
                            service.WeekNumber = Int32.Parse(reader["WeekNumber"].ToString());
                            service.Smell = reader["Smell"].ToString();

                            int MachineID = Int32.Parse(reader["Machine_ID"].ToString());
                            int TechnicianID = Int32.Parse(reader["Technician_ID"].ToString());

                            service.Machine = GetMachine(MachineID);
                            service.Technician = GetTechnician(TechnicianID);

                            serviceList.Add(service);
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return serviceList;
        }

        public Service GetService(int serviceID)
        {
            Service service = new Service();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetServiceFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", serviceID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            service = new Service();
                            service.ID = Int32.Parse(reader["ID"].ToString());
                            service.Arrival = Int32.Parse(reader["Arrival"].ToString());
                            service.Depature = Int32.Parse(reader["Departure"].ToString());
                            service.CleaningEffect = reader["CleaningEffect"].ToString();
                            service.PHValue = Int32.Parse(reader["Arrival"].ToString());
                            service.Temperature = Int32.Parse(reader["Temperature"].ToString());
                            service.WeekNumber = Int32.Parse(reader["WeekNumber"].ToString());
                            service.Smell = reader["Smell"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return service;
        }

        public void UpdateService(Service service)
        {
            throw new NotImplementedException();
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
                    SqlCommand createDepartment = new SqlCommand("spCreateDepartment", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    createDepartment.Parameters.Add(new SqlParameter("@InstallationAddress", department.InstallationAddress));
                    createDepartment.Parameters.Add(new SqlParameter("@InstallationCity", department.InstallationCity));
                    createDepartment.Parameters.Add(new SqlParameter("@InstallationZipcode", department.InstallationZipcode));
                    createDepartment.Parameters.Add(new SqlParameter("@CanBringLiquid", department.CanBringLiquid));
                    createDepartment.Parameters.Add(new SqlParameter("@Customer_ID", department.CustomerID));

                    createDepartment.ExecuteNonQuery();
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

        public Brush GetBrush(int brushID)
        {
            Brush brush = new Brush();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetBrushFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", brushID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            brush = new Brush();
                            brush.ID = Int32.Parse(reader["ID"].ToString());
                            brush.Type = reader["Type"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return brush;
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

        public Liquid GetLiquid(int liquidID)
        {
            Liquid liquid = new Liquid();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetLiquidFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", liquidID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            liquid = new Liquid();
                            liquid.ID = Int32.Parse(reader["ID"].ToString());
                            liquid.Type = reader["Type"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return liquid;
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

        public Filters GetFilter(int filterID)
        {
            Filters filter = new Filters();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetFilterFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", filterID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            filter = new Filters();
                            filter.ID = Int32.Parse(reader["ID"].ToString());
                            filter.Type = reader["Type"].ToString();
                            filter.House = reader["House"].ToString();
                            filter.TypeHouse = reader["TypeHouse"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return filter;
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

        public Steeltop GetSteeltop(int steelTopID)
        {
            Steeltop steelTop = new Steeltop();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetSteelTopFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", steelTop));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            steelTop = new Steeltop();
                            steelTop.ID = Int32.Parse(reader["ID"].ToString());
                            steelTop.Type = reader["Type"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return steelTop;
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

        public Status GetStatusByID(int StatusID)
        {
            Status status = new Status();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetStatusFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", status));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            status = new Status();
                            status.ID = Int32.Parse(reader["ID"].ToString());
                            status.CurrentStatus = reader["Status"].ToString();
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return status;
        }
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

        #region Technician
        public void CreateTechnician()
        {

        }

        public Technician GetTechnician(int technicianID)
        {
            Technician technician = new Technician();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand SearchKeyword = new SqlCommand("spGetTechnicianFromID", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SearchKeyword.Parameters.Add(new SqlParameter("@Keyword", technicianID));

                    SqlDataReader reader = SearchKeyword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            technician = new Technician();
                            technician.ID = Int32.Parse(reader["ID"].ToString());
                            technician.FirstName = reader["FirstName"].ToString();
                            technician.LastName = reader["LastName"].ToString();
                            technician.Email = reader["Email"].ToString();
                            technician.MobilePhone = Int32.Parse(reader["MobilePhone"].ToString());
                        }
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    //Implement exception
                }
            }
            return technician;
        }

        public void GetTechnicians()
        {

        }

        public void UpdateTechnician()
        {

        }

        public void DeleteTechnician()
        {

        }
        #endregion 
    }
}
