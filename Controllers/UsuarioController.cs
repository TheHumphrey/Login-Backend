using LoginBC.Models;
using LoginBC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LoginBC.Controllers {
    [Route("api/[controller]")]
    public class UsuarioController : Controller {

        private readonly UsuarioService _serviceDB;

        public UsuarioController(UsuarioService serviceDB) {
            _serviceDB = serviceDB;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get() {
            var user = _serviceDB.Get();

            return Ok(user);
        }

        //[HttpGet("{params}")]
        //public ActionResult Get(string param) {

        //    return NotFound();
        //}

        [HttpPost]
        public ActionResult Post([FromBody]Usuario usuario) {
            try {
                var user = _serviceDB.Get(usuario.Email);

                if (user == null) {
                    _serviceDB.Create(usuario);
                    return Ok();
                } else {
                    return Conflict();
                }
            } catch(Exception err) {
                return BadRequest();
            }
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value) {
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id) {
        //}
    }
}
