using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Domain.Entities
{
    public class Designation
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        [Column(Order = 1),Required, MaxLength(30)]
        public string Name { get; set; }
        [Column(Order = 2), MaxLength(50)]
        public string Rank { get; set; }        
        [Column(Order = 3), Required, MaxLength(30)]
        public string BasicSalary { get; set; }
        [Required, MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CreatedBy { get; set; }
        [Required, MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime CreatedDate { get; set; }
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Employees where [Employee].[DesignationId] point to this entity (FK_Employee_Designation)
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
        public Designation()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
