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
    [Table("tblProducts")]
    public class Product : FullAuditedEntity
    {
        public Product()
        {
            this.Providers = new HashSet<Provider>();
        }

        /* nome do produto, descrição, marca, fornecedores, 
         * data de entrada do produto no estoque, data de validade, 
         * valor do produto e quantidade em estoque.
        */

        [Display(Name = "Nome do produto")]
        [StringLength(100, ErrorMessage = "No máximo 100 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(300, ErrorMessage = "No máximo 300 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Marca")]
        [StringLength(60, ErrorMessage = "No máximo 60 caracteres")]
        public string Brand { get; set; }

        [Display(Name = "Fornecedores")]
        public virtual ICollection<Provider> Providers { get; set; }

        [Required]
        [Display(Name = "Data de entrada no estoque")]
        public string EntryDate { get; set; }

        [Required]
        [Display(Name = "Data de validade")]
        public string ExpirationDate { get; set; }

        [Required]
        [Display(Name = "Valor do produto")]
        [Column(TypeName = "Money")]
        public decimal Value { get; set; }

        [Required]
        [Display(Name = "Quantidade em estoque")]
        public int Stock { get; set; }
    }
}
