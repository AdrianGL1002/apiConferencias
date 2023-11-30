using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenciasController : ControllerBase
    {
        private ConferenciaDAO conferenciaDao = new ConferenciaDAO();

        [HttpGet("todasLasConferencias")]
        public List<Conferencia> getConferencia(){ 
            return conferenciaDao.seleccionarConferencias();
        }

        [HttpGet("conferenciasPorNombre")]
        public Conferencia getConferenciaPorNombre(string nombre)
        {
            return conferenciaDao.seleccionarPorNombre(nombre);
        }

        [HttpGet("conferenciasPorID")]
        public Conferencia getConferenciaId(int id) {
            return conferenciaDao.seleccionarPorID(id);
        }

    }
}
