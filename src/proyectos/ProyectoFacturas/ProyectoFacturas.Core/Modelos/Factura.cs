using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturas.Core.Modelos
{
    public class Factura
    {
        [Key]
        [Display(Name = "Núm. de Factura")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Cliente")]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Concepto { get; set; }

        [MaxLength(300)]
        public string Detalles { get; set; }
        
        [Range(1, 100000000)]
        public decimal Monto { get; set; }

        [Display(Name = "Porcentaje de Impuesto")]
        public decimal PorcentajeImpuesto { get; set; }

        [Display(Name = "Exenta de Impuesto?")]
        public bool ExentaImpuesto { get; set; }

        [Display(Name = "Fecha de Emisión")]
        public DateTime FechaEmision { get; set; }

        [ForeignKey("Identificacion")]
        public virtual Cliente Cliente { get; set; }

        [NotMapped]
        [Display(Name = "Núm. de Factura")]
        public string IdFormato
        {
            get
            {
                return Id.ToString("000000");
            }
        }

        [NotMapped]
        [Display(Name = "Monto Total")]
        public decimal MontoTotal
        {
            get
            {
                return Monto + (Monto * PorcentajeImpuesto / 100);
            }
        }
    }
}
