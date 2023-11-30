using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class registroyotros
    {
        public int Id { get; set; }

        public string? nombreConferencia { get; set; }

        public string? nombreParticipante { get; set; }

        public int? Confirmacion { get; set; }
    }
}
