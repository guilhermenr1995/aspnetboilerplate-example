using Abp.Domain.Entities.Auditing;
using SoiticTest.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    [Table("tblMovement")]
    public class Movement : FullAuditedEntity
    {
        public Movement()
        {

        }

        [Required]
        [Display(Name = "Produto")]
        public virtual Product Product { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public virtual User User { get; set; }

        [Required]
        [Display(Name = "Quantidade anterior")]
        public int PreviousQtd { get; set; }

        [Required]
        [Display(Name = "Quantidade atual")]
        public int CurrentQtd { get; set; }

        [Required]
        [Display(Name = "Indicador de estoque")]
        public string Signal { get; set; }
    }
}
