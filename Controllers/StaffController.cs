using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GymAPI.Models;
using GymAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet]
        public IEnumerable<Staff> Get() =>
            _staffService.GetAll();

        [HttpGet("{Id}")]
        public Staff GetStaff(int id) => 
            _staffService.GetStaff(id);

        [HttpPost]
        public IEnumerable<Staff> CreateStaff(Staff staff){
            var tmpId = _staffService.GetAll().Last().Id;
            staff.Id = tmpId+1;
            return _staffService.CreateStaff(staff);
        }

        [HttpPut("{Id}")]
        public IEnumerable<Staff> UpdateStaff(int id, Staff staff) =>
            _staffService.UpdateStaff(id, staff);

        [HttpDelete("{Id}")]
        public IEnumerable<Staff> DeleteStaff(int id) =>
            _staffService.DeleteStaff(id);
    }
}