using PersonnelTrackingApplication.DataAccessLayer.Abstract;
using PersonnelTrackingApplication.EntitesLayer.Concreate;
using PersonnelTrackingApplication.ToolsLayer.Connection.SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTrackingApplication.DataAccessLayer.Concrete.SQLite
{
    public class SQLiteEmployeeDAL : IEmployeeDAL
    {
        public List<Employee> ListEmployees(string condition)
        {
            List<Employee> Employees = new List<Employee>();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Employees {condition}", SqliteConnection.Connection))  
                {
                    SqliteConnection.ConnectionOpen(); 
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            Employee _employee = new Employee   
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                LastName = reader["Lastname"].ToString(),
                                TCno = reader["TCno"].ToString(),
                                PersonnelNo = reader["PersonnelNo"].ToString(),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Department = reader["Department"].ToString(),
                                Title = reader["Title"].ToString(),
                                Status = reader["Status"].ToString()
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
                SqliteConnection.ConnectionClose(); //In the finally block, we close the open connection.
            }
        }

        public Employee GetEmployee(string condition)
        {
            Employee _employee = null;   
            try
            {
                int _result = 0;

                using (SQLiteCommand command = new SQLiteCommand($"SELECT COUNT (*) FROM Employees {condition}",SqliteConnection.Connection))  
                {
                    SqliteConnection.ConnectionOpen();
                    _result = Convert.ToInt32(command.ExecuteScalar()); 
                }
                if (_result > 1) 
                    MessageBox.Show("As a result of the query, more than 1 record was found...\nPlease search with more criteria.");

                else if (_result == 1) 
                {
                    using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Employees {condition}",SqliteConnection.Connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
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
                SqliteConnection.ConnectionClose();
            }     
        }

        public bool Save(Employee employee)
        {
            //we will transfer the values we get from the user to the relevant properties of the personnel entity we created.
            string query = "INSERT INTO Employees (Name, LastName, TCNo, PersonnelNo, BirthDate, Department, Title, Status ) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7,@p8)";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query,SqliteConnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", employee.Name);
                    command.Parameters.AddWithValue("@p2", employee.LastName);
                    command.Parameters.AddWithValue("@p3", employee.TCno);
                    command.Parameters.AddWithValue("@p4", employee.PersonnelNo);
                    command.Parameters.AddWithValue("@p5", employee.BirthDate.ToString("yyyy.MM.dd")); //birthdate DateTime type --> we need to make a string.
                    command.Parameters.AddWithValue("@p6", employee.Department);
                    command.Parameters.AddWithValue("@p7", employee.Title);
                    command.Parameters.AddWithValue("@p8", employee.Status);
                    
                    SqliteConnection.ConnectionOpen();
                    command.ExecuteNonQuery();
                }
                return true;  //return true if saving to the database is complete

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;  //Check that the operation has failed and show it in the presentation layer
            }
            finally 
            { 
                SqliteConnection.ConnectionClose(); 
            }
        }

        public bool Update(Employee employee)
        {
            //we will transfer the values we get from the user to the related properties of the related personnel entity.
            string query = "UPDATE Employees SET Name = @p1, LastName = @p2, TCNo = @p3, PersonnelNo = @p4, BirthDate = @p5, Department = @p6, Title = @p7, Status = @p8 WHERE Id = @p9";

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, SqliteConnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1", employee.Name);
                    command.Parameters.AddWithValue("@p2", employee.LastName);
                    command.Parameters.AddWithValue("@p3", employee.TCno);
                    command.Parameters.AddWithValue("@p4", employee.PersonnelNo);
                    command.Parameters.AddWithValue("@p5", employee.BirthDate.ToString()); //birthdate DateTime type --> we need to make a string.
                    command.Parameters.AddWithValue("@p6", employee.Department);
                    command.Parameters.AddWithValue("@p7", employee.Title);
                    command.Parameters.AddWithValue("@p8", employee.Status);
                    command.Parameters.AddWithValue("@p9", employee.Id);

                    SqliteConnection.ConnectionOpen();
                    command.ExecuteNonQuery();
                }
                return true;  //return true if the update to the database is complete
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;  //Check that the operation has failed and show it in the presentation layer
            }
            finally
            {
                SqliteConnection.ConnectionClose();
            }
        }

        public bool Delete(string condition)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM EMployees {condition}", SqliteConnection.Connection))
                {
                    SqliteConnection.ConnectionOpen();
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
                SqliteConnection.ConnectionClose();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM EMployees WHERE Id = @p1", SqliteConnection.Connection))
                {
                    command.Parameters.AddWithValue("@p1",id);
                    SqliteConnection.ConnectionOpen();
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
                SqliteConnection.ConnectionClose();
            }
        }
    }
}
