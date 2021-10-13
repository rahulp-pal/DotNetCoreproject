using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Domain.Entities
{
    public class Employee
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(Order = 1), Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Column(Order = 2), MaxLength(100)]
        public string MiddleName { get; set; }
        [Column(Order = 3), Required, MaxLength(100)]
        public string LastName { get; set; }
        [Column(Order = 4), Required]
        public int DesignationId { get; set; }
        [Required, MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CreatedBy { get; set; }
        [Required, MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreatedDate { get; set; }
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent Designation pointed by [Employee].([DesignationId]) (FK_Employee_Designation)
        /// </summary>
        public Designation Designation { get; set; }
    }
}
