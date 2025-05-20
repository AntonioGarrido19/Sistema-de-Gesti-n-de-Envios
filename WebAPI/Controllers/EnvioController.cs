using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private IListadoEnvios _listadoEnvioCU { get; set; }

        private IEnvioPorTracking _envioPorTrackingCU { get; set; }

        public EnvioController(IListadoEnvios listadoEnvios, IEnvioPorTracking envio) {

            _listadoEnvioCU = listadoEnvios;

            _envioPorTrackingCU = envio;
        }

        // GET: api/<EnvioController>
        [HttpGet]
        public IActionResult Get()
        {
            //FindAll
            try 
            {
                return Ok(_listadoEnvioCU.Ejecutar());
            }
            catch(Exception ex) 
            { 
                return StatusCode(500, "Error interno");
            }
          
        }

        // GET api/<EnvioController>/5
        [HttpGet("{tracking}")]
        public IActionResult Get(int tracking)
        {
            try
            {
                if (tracking <= 0)
                {
                    return BadRequest("El tracking recibido no es correcto");
                }
                return Ok(_envioPorTrackingCU.Ejecutar(tracking));
            }
            catch (EnvioComunException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<EnvioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EnvioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Update
        }

        // DELETE api/<EnvioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Delete
        }
    }
}
