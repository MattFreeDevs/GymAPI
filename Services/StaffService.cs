using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;

namespace GymAPI.Services
{
    public class StaffService
    {
        private readonly List<Staff> _staff;

        public StaffService(){
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/staffData.json");
            _staff = JsonSerializer.Deserialize<List<Staff>>(jsonString);
        }

        public IEnumerable<Staff> GetAll() =>
            _staff;

        public Staff GetStaff(int id){
            return _staff.Where(x=>x.Id == id).FirstOrDefault();
        }
        
        public IEnumerable<Staff> CreateStaff(Staff staff){
            _staff.Add(staff);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_staff,options);
            System.IO.File.WriteAllText("../GymAPI/Data/staffData.json",jsonString);
            return _staff;
        }

        public IEnumerable<Staff> UpdateStaff(int id, Staff staff){
            _staff.Remove(_staff.Where(x=> x.Id == id).FirstOrDefault());
            _staff.Add(staff);
            _staff.OrderBy(x=>x.Id);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_staff,options);
            System.IO.File.WriteAllText("../GymAPI/Data/staffData.json",jsonString);

            return _staff;
        }

        public IEnumerable<Staff> DeleteStaff(int id){
            _staff.Remove(_staff.Where(x=> x.Id == id).FirstOrDefault());
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_staff,options);
            System.IO.File.WriteAllText("../GymAPI/Data/staffData.json",jsonString);

            return _staff;
        }
    }
}