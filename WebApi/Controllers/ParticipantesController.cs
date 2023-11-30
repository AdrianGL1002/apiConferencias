using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private ParticipantesDAO participanteDao = new ParticipantesDAO();

        [HttpGet("participantes")]
        public List<Participante> getParticipante()
        { 
            return participanteDao.seleccionarTodos();
        }

        [HttpGet("participantePorNombre")]
        public List<Participante> getParticipanteNombre(String nombre) {
            return participanteDao.seleccionarPorNombre(nombre);
        }

        [HttpGet("participantePorID")]
        public Participante getParticipanteID(int id) {
            return participanteDao.seleccionarPorID(id);
        }

        [HttpPost("insertarParticipantes")]
        public bool insertarParticipante([FromBody] Participante participante) {
            return participanteDao.insertarParticipante(participante.Nombre, participante.Apellidos, 
                participante.Email, participante.Twitter, (int)participante.Avatar);
        }

        [HttpPut("actualizarParticipantes")]
        public bool actualizarParticipantes([FromBody] Participante participante) {
            return participanteDao.actualizarParticipante(participante.IdParticipante, participante.Nombre,
                participante.Apellidos, participante.Email, participante.Twitter, (int)participante.Avatar);
        }

        [HttpDelete("eliminarParticipantes")]
        public bool eliminarParticipante(int id) {
            return participanteDao.eliminar(id);
        }
    }
}
