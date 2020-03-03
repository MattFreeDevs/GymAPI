using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;
using GymAPI.Utils;

namespace GymAPI.Services
{
    public class StaffService
    {
        private readonly List<Staff> _staff;
        DataUtils dataUtils = new DataUtils();

        public StaffService(){
            _staff = dataUtils.ReadStaffJson();
        }

        public IEnumerable<Staff> GetAll() =>
            _staff.OrderBy(x=>x.Id);

        public Staff GetStaff(int id){
            return _staff.Where(x=>x.Id == id).FirstOrDefault();
        }
        
        public Staff CreateStaff(Staff staff){
            _staff.Add(staff);
            dataUtils.WriteStaffJson(_staff);
            return staff;
        }

        public Staff UpdateStaff(int id, Staff staff){
            _staff.Remove(_staff.Where(x=> x.Id == id).FirstOrDefault());
            staff.Id = id;
            _staff.Add(staff);
            List<Staff> orderedList = new List<Staff>(_staff.OrderBy(x=>x.Id));
            dataUtils.WriteStaffJson(orderedList);
            return staff;
        }

        public bool DeleteStaff(int id){
            _staff.Remove(_staff.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteStaffJson(_staff);
            return true;
        }
    }
}