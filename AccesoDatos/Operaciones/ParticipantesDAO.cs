using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class ParticipantesDAO
    {
        TicConferenciasContext contexto = new TicConferenciasContext();

        public List<Participante> seleccionarTodos() {
            var participantes = contexto.Participantes.ToList<Participante>();

            return participantes;
        }

        public List<Participante> seleccionarPorNombre(string nombre) { 
            var participantes = contexto.Participantes.Where(p => p.Nombre == nombre).ToList<Participante>();
            return participantes;
        }

        public Participante seleccionarPorID(int id)
        {
            var participante = contexto.Participantes.Where(p => p.IdParticipante == id).FirstOrDefault();
            return participante;
        }

        public bool insertarParticipante(string nombre, string apellidos, string email, string twitter, int avatar)
        {
            try
            {
                Participante participante = new Participante();
                participante.Nombre = nombre;
                participante.Apellidos = apellidos;
                participante.Email = email;
                participante.Twitter = twitter;
                participante.Avatar = avatar;

                contexto.Participantes.Add(participante);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public bool actualizarParticipante(int id, string nombre, string apellido, string email, string twitter, int avatar)
        {
            try
            {
                var participante = seleccionarPorID(id);
                if (participante == null)
                {
                    return false;
                }
                else
                {
                    participante.Nombre = nombre;
                    participante.Apellidos = apellido;
                    participante.Email = email;
                    participante.Twitter = twitter;
                    participante.Avatar = avatar;

                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try {
                var participante = seleccionarPorID(id);
                if (participante == null)
                {
                    return false;
                }
                else {
                    contexto.Participantes.Remove(participante);
                    contexto.SaveChanges();
                    return true;
                }
            } catch (Exception ex){ 
                return false; 
            }
        }
    }
}
