using PersonnelTrackingApplication.DataAccessLayer.Concrete.SQLite;
using PersonnelTrackingApplication.DataAccessLayer.Concrete.SqlServer;
using PersonnelTrackingApplication.EntitesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelTrackingApplication.EntitesLayer.Concreate
{
    public class Employee : IBaseEntity
    {
        public int Id { get; set; }     //BaseEntity also contains the employee class with its props.
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TCno { get; set; }
        public string PersonnelNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        public static implicit operator Employee(SQLiteEmployeeDAL v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Employee(SqlServerDAL v)
        {
            throw new NotImplementedException();
        }
    }
}
