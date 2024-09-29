using Compartido.DTOs.Atletas;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public static class AtletaMapper
    {
        public static IEnumerable<AtletaListaDTO> AtletasToListaDTO(List<Atleta> atletas)
        {
            return atletas.Select(a => new AtletaListaDTO
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                NombrePais = a.Pais.Nombre,
                Sexo = a.Sexo.ToString(),
            });
        }
    }
}
