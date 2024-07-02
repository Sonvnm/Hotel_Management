using BusinessObject.DataAccess;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StaffRepository : IStaffRepository
    {
        public void AddNew(BusinessObject.DataAccess.staff staff) => StaffManagement.Instance.AddNew(staff);

        public BusinessObject.DataAccess.staff checkAdminLogin(string email, string password) => StaffManagement.Instance.checkAdminLogin(email, password);

        public int Count() => StaffManagement.Instance.Count();
      

        public List<BusinessObject.DataAccess.staff> GetAll(int currentPage, int pageSize) => StaffManagement.Instance.GetAll(currentPage, pageSize);
      




        //  public List<staff> GetAll(int currentPage, int pageSize) => StaffManagement.Instance.GetAll(currentPage, pageSize);


        public List<BusinessObject.DataAccess.staff> GetAllstaff() => StaffManagement.Instance.GetAllstaff();

       

        public BusinessObject.DataAccess.staff GetEmailStaffbyLogins(string Email, string Password) => StaffManagement.Instance.GetEmailStaffbyLogins(Email, Password);

     

        public BusinessObject.DataAccess.staff GetstaffbyId(string id) => StaffManagement.Instance.GetstaffbyId(id);


        public void Remove(BusinessObject.DataAccess.staff staff) => StaffManagement.Instance.Remove(staff);

        public List<BusinessObject.DataAccess.staff> Searchingstaff(string name) => StaffManagement.Instance.Searchingstaff(name);
   

        public void Updatestaff(BusinessObject.DataAccess.staff staff) => StaffManagement.Instance.Updatestaff(staff);
    }
}

       
