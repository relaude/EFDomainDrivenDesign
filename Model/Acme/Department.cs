using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Acme
{
    public class Department : IObjectWithState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public State State { get; set; }
    }
}
