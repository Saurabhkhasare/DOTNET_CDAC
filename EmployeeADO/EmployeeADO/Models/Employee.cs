using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeADO.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into emps values(@Name,@City,@Address)";



                
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@City", obj.City);
                cmdInsert.Parameters.AddWithValue("@Address", obj.Address);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void Update(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update emps set Name=@Name, City=@City, Address=@Address where Id =@Id";

                cmdInsert.Parameters.AddWithValue("@Id", obj.Id);

                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@City", obj.City);
                cmdInsert.Parameters.AddWithValue("@Address", obj.Address);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void Delete(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from emps where Id =@Id";
                cmdInsert.Parameters.AddWithValue("@Id", id);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
            public static Employee GetSingleEmployee(int Id)
        {
            Employee obj = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from emps where Id=@Id";
                cmdInsert.Parameters.AddWithValue("@Id", Id);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    obj.Id = dr.GetInt32("Id");
                    obj.Name = dr.GetString("Name");
                    obj.City = dr.GetString("City");
                    obj.Address = dr.GetString("Address");
                }
                else
                {
                    obj = null;
                    //record not present
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }
        public static List<Employee> GetAllEmployees()
            {
                List<Employee> lstEmps = new List<Employee>();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = cn;
                    cmdInsert.CommandType = System.Data.CommandType.Text;
                    cmdInsert.CommandText = "select * from emps";
                    SqlDataReader dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                        lstEmps.Add(new Employee { Id = dr.GetInt32(0), Name = dr.GetString(1), City = dr.GetString(2), Address = dr.GetString(3) });
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    cn.Close();
                }
                return lstEmps;
            
        }
        
    }
}
