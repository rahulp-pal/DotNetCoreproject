using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Domain.Common
{
    public abstract class AuditableEntity
    {
        [Required, MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CreatedBy { get; set; }
        [Required, MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreatedDate { get; set; }
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        protected AuditableEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
