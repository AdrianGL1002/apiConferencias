using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Registro
{
    public int Id { get; set; }

    public int? IdConference { get; set; }

    public int? IdParticipante { get; set; }

    public int? Confirmacion { get; set; }

    public virtual Conferencia? IdConferenceNavigation { get; set; }

    public virtual Participante? IdParticipanteNavigation { get; set; }
}
