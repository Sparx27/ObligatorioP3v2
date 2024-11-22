using Compartido.DTOs.Atletas;
using Compartido.Mappers;
using LogicaAplicacion.ICasosDeUso.Atletas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Atletas
{
    public class SelectByDisciplinaId : ISelectByDisciplinaId
    {
        private readonly IRepositorioAtleta _repo;
        public SelectByDisciplinaId(IRepositorioAtleta repo)
        {
            _repo = repo;
        }

        public IEnumerable<AtletaListaDTO> Ejecutar(int disciplinaId)
        {
            if (disciplinaId <= 0) throw new AtletaException("Id incorrecto");

            List<Atleta>? resdb = _repo.SelectByDisciplinaId(disciplinaId);

            return resdb == null
                ? null
                : AtletaMapper.AtletasToListaDTO(resdb).OrderBy(a => a.NombreCompleto);
        }

        //RF2 – Listado de Atletas por Disciplina(API Web + HttpClient) – Sin autenticación
        //- Crear un listado de atletas filtrado por disciplina.Este endpoint permitirá consultar todos los atletas
        //que están registrados en una disciplina dado su Id.El listado se retornará ordenado alfabéticamente
        //por nombre completo de atleta.Se incluirán como mínimo su Id (o número, según haya utilizado), su
        //nombre completo y el nombre de su país.
    }
}
