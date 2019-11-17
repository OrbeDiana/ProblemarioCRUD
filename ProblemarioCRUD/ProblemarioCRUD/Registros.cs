using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemarioCRUD
{
    class Registros
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        public string Grupo { get; set; }
        public decimal Calificacion { get; set; }

    }
}