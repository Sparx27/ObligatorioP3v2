using Compartido.DTOs.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.Validadores
{
    public static class ValidarEvento
    {
        public static void CantidadAtletas(EventoInsertDTO dto)
        {
            if (dto.AtletasId != null ? dto.AtletasId.Count() < 3 : true) 
                throw new EventoException("Se requieren al menos 3 Atletas");
        }

        public static void AtletasRegistradosEnDisciplina(List<Atleta> atletas, int[] dtoIds)
        {
            int verificador = atletas.Where(a => dtoIds.Any(id => id == a.Id)).Count();
            if (verificador != dtoIds.Length) throw new EventoException("Hay atletas no registrados en esta Disciplina");
        }

        public static void Fechas(EventoInsertDTO dto)
        {
            if (dto.FchInicio > dto.FchFin)
                throw new EventoException("Fechas incorrectas");
        }

        public static void Puntajes(EventoUpdatePuntajesDTO eventoUpdatePuntajesDTO)
        {
            if (eventoUpdatePuntajesDTO.LiAtletas.Any(p => p.Puntaje < 0))
                throw new EventoException("Los puntajes no pueden ser menores a 0");
        }
    }
}
