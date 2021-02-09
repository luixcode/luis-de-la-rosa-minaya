using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Form.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Form.API.Models
{
    public enum Genders
    {
        [Description("Masculino")]
        Male,
        [Description("Femenino")]
        Female
    }
    public class User : ModelBase
    {
        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Nombre es requerido.")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Apellido es requerido.")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(9)")]
        [Required(ErrorMessage = "Género es requerido.")]
        public Genders Gender { get; set; }

        [Column(TypeName = "char(11)")]
        [Required(ErrorMessage = "Cédula es requerida.")]
        public string Document { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Fecha de nacimiento es requerida.")]
        public DateTime DoB { get; set; }

        [Column(TypeName = "varchar(40)")]
        [Required(ErrorMessage = "Cargo es requerido.")]
        public string Position { get; set; }

        [Column(TypeName = "varchar(61)")]
        [Required(ErrorMessage = "Supervisor es requerido.")]
        public string Supervisor { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
