using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Form.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Form.API.Models
{
    public class Department : ModelBase
    {
        [Column(TypeName = "char(5)")]
        [Required(ErrorMessage = "Código requerido.")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Nombre de departamento es requerido.")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
