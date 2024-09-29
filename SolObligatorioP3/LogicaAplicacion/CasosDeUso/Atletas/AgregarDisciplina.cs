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
    public class AgregarDisciplina : IAgregarDisciplina
    {
        private readonly IRepositorioAtleta _repositorioAtleta;
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        public AgregarDisciplina(IRepositorioAtleta repositorioAtleta, IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioAtleta = repositorioAtleta;
            _repositorioDisciplina = repositorioDisciplina;
        }

        public void Ejecutar(int id, int? idDisciplina)
        {
            if (id == 0)
            {
                throw new AtletaException("Id de atleta incorrecto");
            }
            if (idDisciplina == null || idDisciplina == 0)
            {
                throw new AtletaException("Id de disciplina incorrecto");
            }

            Atleta atleta = _repositorioAtleta.GetById(id);

            Disciplina tieneDisciplina = atleta.LiDisciplinas.FirstOrDefault(d => d.Id == idDisciplina);

            if (tieneDisciplina != null)
            {
                throw new AtletaException("El atleta ya está registrado en esta disciplina");
            };

            Disciplina disciplinaAgregar = _repositorioDisciplina.GetById(idDisciplina.Value);

            atleta.LiDisciplinas.Add(disciplinaAgregar);
            _repositorioAtleta.GuardarCambios();
        }
    }
}
