using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2_P2Tarea2_4.Models
{
    public class Videos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string descripcion { get; set; }
        public string url { get; set; }
        public DateTime fecha { get; set; }
    }
}
