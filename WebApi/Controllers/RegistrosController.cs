using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private RegistrosDAO registrosDao = new RegistrosDAO();
        [HttpGet("registros")]
        public List<registroyotros> getRegistrosTodos() { 
            return registrosDao.seleccionarTodos();
        }

        [HttpGet("registrosPorConferencia")]
        public List<registroyotros> getRegistrosPorConferencia(string nombre) {
            return registrosDao.seleccionarPorConferencia(nombre);
        }

        [HttpGet("registrosPorID")]
        public Registro getRegistrosPorId(int id) {
            return registrosDao.seleccionarporID(id);
        }

        [HttpPost("insertarRegistros")]
        public bool insertarRegistro([FromBody] Registro registro) {
            return registrosDao.insertarRegistro((int)registro.IdConference, (int)registro.IdParticipante, (int)registro.Confirmacion);
        }

        [HttpPut("actualizarRegistros")]
        public bool actualizarRegistro([FromBody] Registro registro) {
            return registrosDao.actualizarRegistro(registro.Id, (int)registro.IdConference, (int)registro.IdParticipante, (int)registro.Confirmacion);
        }

        [HttpDelete("eliminarRegistros")]
        public bool eliminarRegistro(int id) {
            return registrosDao.eliminarRegistro(id);
        }
    }
}
