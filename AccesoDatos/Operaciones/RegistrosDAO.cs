using AccesoDatos.Context;
using AccesoDatos.Models;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class RegistrosDAO
    {
        public TicConferenciasContext contexto = new TicConferenciasContext();

        public List<registroyotros> seleccionarTodos() {
            var query = from a in contexto.Registros
                        join p in contexto.Participantes on a.IdParticipante
                        equals p.IdParticipante
                        join c in contexto.Conferencias on a.IdConference
                        equals c.IdConference
                        select new registroyotros
                        {
                            Id = a.Id,
                            nombreConferencia = c.Nombre,
                            nombreParticipante = p.Nombre,
                            Confirmacion = a.Confirmacion
                        };
            return query.ToList();
        }

        public List<registroyotros> seleccionarPorConferencia(string nombreConferencia) { 
            var query = from a in contexto.Registros
                        join p in contexto.Participantes on a.IdParticipante
                        equals p.IdParticipante
                        join c in contexto.Conferencias on a.IdConference
                        equals c.IdConference
                        where (c.Nombre == nombreConferencia)
                        select new registroyotros
                        {
                            Id = a.Id,
                            nombreConferencia = c.Nombre,
                            nombreParticipante = p.Nombre,
                            Confirmacion = a.Confirmacion
                        };
            return query.ToList();
        }

        public Registro seleccionarporID(int id) {
            var registros = contexto.Registros.Where(a => a.Id == id).FirstOrDefault();
            return registros;
        }

        public bool insertarRegistro(int idconference, int idparticipante, int confirmacion)
        {
            try {
                Registro registro = new Registro();
                registro.IdConference = idconference;
                registro.IdParticipante = idparticipante;
                registro.Confirmacion = confirmacion;

                contexto.Registros.Add(registro);
                contexto.SaveChanges();
                return true;
            } 
            catch (Exception ex) { 
                return false;
            }
        }

        public bool actualizarRegistro(int id, int idconference, int idparticipante, int confirmacion) {
            try
            {
                var registro = seleccionarporID(id);
                if (registro == null)
                {
                    return false;
                }
                else
                {
                    registro.IdConference = idconference;
                    registro.IdParticipante = idparticipante;
                    registro.Confirmacion = confirmacion;

                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminarRegistro(int id) {
            try
            {
                var registro = seleccionarporID(id);
                if (registro == null)
                {
                    return false;
                }
                else { 
                    contexto.Registros.Remove(registro);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
