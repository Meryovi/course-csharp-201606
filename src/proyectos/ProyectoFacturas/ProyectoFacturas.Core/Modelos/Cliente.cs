using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturas.Core.Modelos
{
    public class Cliente
    {
        [Key, Required]
        [MaxLength(20)]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Display(Name = "Exento de Impuesto?")]
        public bool ExentoImpuesto { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
