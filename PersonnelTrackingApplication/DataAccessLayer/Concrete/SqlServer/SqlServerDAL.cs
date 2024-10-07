using PersonnelTrackingApplication.DataAccessLayer.Abstract;
using PersonnelTrackingApplication.EntitesLayer.Concreate;
using PersonnelTrackingApplication.ToolsLayer.Connection.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTrackingApplication.DataAccessLayer.Concrete.SqlServer
{
    public class SqlServerDAL : IEmployeeDAL
    {
        public List<Employee> ListEmployees(string condition)
        {
            List<Employee> Employees = new List<Employee>();
            try
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM Employees {condition}", SqlServerConnection.Connection))
                {
                    SqlServerConnection.ConnectionOpen();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee _employee = new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                TCno = reader["TCno"].ToString(),
                                PersonnelNo = reader["PersonnelNo"].ToString(),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Department = reader["Department"].ToString(),
                                Title = reader["Title"].ToString(),
                                Status = reader["Status"].ToString(),
                            };
                            Employees.Add(_employee);
                        }
                    }
                }
                return Employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                SqlServerConnection.ConnectionClose();  
            }
        }

        public Employee GetEmployee(string condition)
        {
            Employee _employee = null;
            try
            {
                int _result = 0;

                using (SqlCommand command = new SqlCommand($"SELECT COUNT (*) FROM Employees {condition}", SqlServerConnection.Connection))
                {
                    SqlServerConnection.ConnectionOpen();
                    _result = Convert.ToInt32(command.ExecuteScalar());
                }
                if (_result > 1)
                    MessageBox.Show("As a result of the query, more than 1 record was found...\nPlease search with more criteria.");

                else if (_result == 1)
                {
                    using (SqlCommand command = new SqlCommand($"SELECT * FROM Employees {condition}", SqlServerConnection.Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _employee = new Employee
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    TCno = reader["TCno"].ToString(),
                                    PersonnelNo = reader["PersonnelNo"].ToString(),
                                    BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                    Department = reader["Department"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Status = reader["Status"].ToString(),
                                };
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("No record was found as a result of the query.");
                return _employee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                SqlServerConnection.ConnectionClose();
            }
        }

        public bool Save(Employee employee)
        {
            //we will transfer the values we get from the user to the relevant properties of the personnel entity we created.
            string query = "INSERT INTO Employees (Name, LastName, TCNo, PersonnelNo, BirthDate, Department, Title, Status ) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, SqlServerConnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", employee.Name);
                    command.Parameters.AddWithValue("@p2", employee.LastName);
                    command.Parameters.AddWithValue("@p3", employee.TCno);
                    command.Parameters.AddWithValue("@p4", employee.PersonnelNo);
                    command.Parameters.AddWithValue("@p5", employee.BirthDate); //sql server supports us to work with datetime
                    command.Parameters.AddWithValue("@p6", employee.Department);
                    command.Parameters.AddWithValue("@p7", employee.Title);
                    command.Parameters.AddWithValue("@p8", employee.Status);

                    SqlServerConnection.ConnectionOpen();
                    command.ExecuteNonQuery();
                }
                return true;  //return true if saving to the database is complete

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;  
            }
            finally
            {
                SqlServerConnection.ConnectionClose();
            }
        }

        public bool Update(Employee employee)
        {
            string query = "UPDATE Employees SET Name = @p1, LastName = @p2, TCNo = @p3, PersonnelNo = @p4, BirthDate = @p5, Department = @p6, Title = @p7, Status = @p8 WHERE Id = @p9";

            try
            {
                using (SqlCommand command = new SqlCommand(query, SqlServerConnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", employee.Name);
                    command.Parameters.AddWithValue("@p2", employee.LastName);
                    command.Parameters.AddWithValue("@p3", employee.TCno);
                    command.Parameters.AddWithValue("@p4", employee.PersonnelNo);
                    command.Parameters.AddWithValue("@p5", employee.BirthDate); 
                    command.Parameters.AddWithValue("@p6", employee.Department);
                    command.Parameters.AddWithValue("@p7", employee.Title);
                    command.Parameters.AddWithValue("@p8", employee.Status);
                    command.Parameters.AddWithValue("@p9", employee.Id);

                    SqlServerConnection.ConnectionOpen();
                    command.ExecuteNonQuery();
                }
                return true;  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;  
            }
            finally
            {
                SqlServerConnection.ConnectionClose();
            }
        }

        public bool Delete(string condition)
        {
            try
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM EMployees {condition}", SqlServerConnection.Connection))
                {
                    SqlServerConnection.ConnectionOpen();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                SqlServerConnection.ConnectionClose();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM EMployees WHERE Id = @p1", SqlServerConnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", id);
                    SqlServerConnection.ConnectionOpen();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                SqlServerConnection.ConnectionClose();
            }
        }
    }
}
