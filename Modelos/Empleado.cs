using System.ComponentModel.DataAnnotations;
namespace DavidAppCrud.Modelos
{
    public class Empleado
    {
        [Key]
        public int idEmpleado { get; set; }
        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public decimal Sueldo { get; set; }

        public DateTime FechaContrato { get; set; }

    }
}
