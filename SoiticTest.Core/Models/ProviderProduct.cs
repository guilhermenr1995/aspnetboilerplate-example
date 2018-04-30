using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoiticTest.Models
{
    [Table("tblProviderProduct")]
    public class ProviderProduct : FullAuditedEntity
    {
        public virtual int Provider_Id { get; set; }
        public virtual int Product_Id { get; set; }

        public ProviderProduct(int Provider_Id, int Product_Id)
        {

        }
    }
}
