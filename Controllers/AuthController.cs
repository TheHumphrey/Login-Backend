using LoginBC.Models;
using LoginBC.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoginBC.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly UsuarioService _serviceDB;

        public AuthController(UsuarioService serviceDB) {
            _serviceDB = serviceDB;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Auth auth) {
            try {
                TypeAuth typeAuth = _serviceDB.ValidateLogin(auth.Username, auth.Password);
                
                if (typeAuth == TypeAuth.Ok) {
                    return Ok();
                } else if(typeAuth == TypeAuth.Unauthorized) {
                    return Unauthorized();
                } else {
                    return NotFound();
                }
            } catch(Exception err) {
                return BadRequest();
            }
        }
    }
}
