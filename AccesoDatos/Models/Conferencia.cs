using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Conferencia
{
    public int IdConference { get; set; }

    public string? Horario { get; set; }

    public string? Nombre { get; set; }

    public string? Conferencista { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
