using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolPeruano.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
    
    public Player? Player { get; set; }
        public Team? Team { get; set; }

        public string TeamNombre => Team?.Nombre ?? "Sin Asignar";
    }
}