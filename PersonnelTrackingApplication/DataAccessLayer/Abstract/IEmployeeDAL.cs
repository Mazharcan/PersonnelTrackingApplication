using PersonnelTrackingApplication.EntitesLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingApplication.DataAccessLayer.Abstract
{
    public interface IEmployeeDAL
    {
        List<Employee> ListEmployees(string condition);
        Employee GetEmployee(string condition); 
        bool Save(Employee employee); 
        bool Update(Employee employee);
        bool Delete(string condition);
        bool Delete(int id);  
    }
}
