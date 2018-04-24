using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    [Table("tblProviders")]
    public class Provider:FullAuditedEntity
    {
        public Provider()
        {
            this.Products = new HashSet<Product>();
        }

        public int ProviderId { get; set; }

        /* nome completo, endereço, telefone e CPF */

        [Required]
        [Display(Name = "Nome completo")]
        [StringLength(200, ErrorMessage = "No máximo 200 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(300, ErrorMessage = "No máximo 300 caracteres")]
        public string Address { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(15, ErrorMessage = "No máximo 15 caracteres")]
        public string Phone { get; set; }

        [Display(Name = "CPF")]
        [StringLength(14, ErrorMessage = "No máximo 14 caracteres")]
        public string CPF { get; set; }

        [Display(Name = "Produtos")]
        public ICollection<Product> Products { get; set; }
    }
}
