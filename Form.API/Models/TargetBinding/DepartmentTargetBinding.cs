using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Form.API.Models.TargetBinding
{
    public class DepartmentTargetBinding
    {
        [Column(TypeName = "char(5)")]
        [Required(ErrorMessage = "Código requerido.")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Nombre de departamento es requerido.")]
        public string Name { get; set; }

        public Department ToDepartment()
        {
            return new Department
            {
                Code = this.Code,
                Name = this.Name
            };
        }
    }
}
