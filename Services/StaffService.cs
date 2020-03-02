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
            _staff;

        public Staff GetStaff(int id){
            return _staff.Where(x=>x.Id == id).FirstOrDefault();
        }
        
        public IEnumerable<Staff> CreateStaff(Staff staff){
            _staff.Add(staff);
            dataUtils.WriteStaffJson(_staff);
            return _staff;
        }

        public IEnumerable<Staff> UpdateStaff(int id, Staff staff){
            _staff.Remove(_staff.Where(x=> x.Id == id).FirstOrDefault());
            staff.Id = id;
            _staff.Add(staff);
            _staff.OrderBy(x=>x.Id);
            dataUtils.WriteStaffJson(_staff);
            return _staff;
        }

        public IEnumerable<Staff> DeleteStaff(int id){
            _staff.Remove(_staff.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteStaffJson(_staff);
            return _staff;
        }
    }
}