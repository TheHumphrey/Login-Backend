using System;
using LoginBC.Services;
using LoginBC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginBC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase {

        private readonly DashboardService _serviceDB;

        public DashboardController(DashboardService serviceDB) {
            _serviceDB = serviceDB;
        }

        [HttpGet]
        public ActionResult Get() {
            try {
                var data = _serviceDB.Get();
                return Ok(data);
            } catch (Exception err) {
                return BadRequest(err);
            }
        }

        //[HttpGet("{user}")]
        //public ActionResult Get(string user) {
        //    try {
        //        var data = _serviceDB.Get(user);
        //        return Ok(data);
        //    } catch (Exception err) {
        //        return BadRequest(err);
        //    }
        //}

        public ActionResult Post([FromBody]Dashboard dash) {
            try {
                _serviceDB.Create(dash);
                return Ok();
            } catch (Exception err) {
                return BadRequest(err);
            }
        }

        [HttpPut("{email}")]
        public ActionResult Put(string email, [FromBody]Dashboard user) {
            try {
                _serviceDB.Update(email, user);
                return Ok();
            } catch (Exception err) {
                return BadRequest(err);
            }
        }
    }
}
