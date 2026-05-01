using System.ComponentModel.DataAnnotations;

namespace Tarea3_GestionEmpleados_C06978.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio")]
        [Range(400000, 10000000, ErrorMessage = "El salario debe estar entre 400,000 y 10,000,000")]
        public decimal Salario { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        // Propiedad calculada requerida en el punto 1 del documento
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}