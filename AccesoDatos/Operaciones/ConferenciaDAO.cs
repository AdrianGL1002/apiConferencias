using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class ConferenciaDAO
    {
        public TicConferenciasContext contexto = new TicConferenciasContext();
        public List<Conferencia> seleccionarConferencias() {
            var conferencias = contexto.Conferencias.ToList<Conferencia>();
            return conferencias;
        }

        public Conferencia seleccionarPorNombre(string nombre) {
            var conferencias = contexto.Conferencias.Where(c => c.Nombre == nombre).FirstOrDefault();
            return conferencias;
        }

        public Conferencia seleccionarPorID(int id) {
            var conferencias = contexto.Conferencias.Where(c => c.IdConference == id).FirstOrDefault();
            return conferencias;
        }

        
        
    }
}
