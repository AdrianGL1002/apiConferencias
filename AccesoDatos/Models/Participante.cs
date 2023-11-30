using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Participante
{
    public int IdParticipante { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public string? Twitter { get; set; }

    public int? Avatar { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
