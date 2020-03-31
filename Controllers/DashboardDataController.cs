using System;
using LoginBC.Models;
using LoginBC.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginBC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardDataController : ControllerBase {
        private readonly DashboardDataService _serviceDBData;

        public DashboardDataController(DashboardDataService serviceDB) {
            _serviceDBData = serviceDB;
        }

        // GET: api/DashboardData
        public ActionResult<DashboardData> Get() {
            try {
                var data = _serviceDBData.Get();
                return Ok(data);
            } catch (Exception err) {
                return BadRequest(err);
            }
        }

        // POST: api/DashboardData
        [HttpPost]
        public ActionResult Post([FromBody]Data test) {
            try {
                _serviceDBData.Create(test);
                return Ok();
            } catch (Exception err) {
                return BadRequest(err);
            }
        }
    }
}
