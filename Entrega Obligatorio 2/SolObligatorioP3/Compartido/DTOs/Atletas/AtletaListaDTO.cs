using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Atletas
{
    public class AtletaListaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public string NombrePais { get; set; }
    }
    //RF2 – Listado de Atletas por Disciplina(API Web + HttpClient) – Sin autenticación
    //- Crear un listado de atletas filtrado por disciplina.Este endpoint permitirá consultar todos los atletas
    //que están registrados en una disciplina dado su Id.El listado se retornará ordenado alfabéticamente
    //por nombre completo de atleta.Se incluirán como mínimo su Id (o número, según haya utilizado), su
    //nombre completo y el nombre de su país.

}
