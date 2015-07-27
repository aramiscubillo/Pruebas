using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPP.Model
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Por favor introduzca el nombre")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Por favor introduzca el apellido")]
        public String Apellidos { get; set; }

        [Required(ErrorMessage = "Por favor introduzca la fecha de nacimiento")]
        public DateTime FechaNac { get; set; }

        [Required(ErrorMessage = "Por favor introduzca al menos un rol")]
        public String Roles { get; set; }

        [Required(ErrorMessage = "Por favor introduzca el correo")]
        [EmailAddress(ErrorMessage = "Por favor introduzca un correo válido")]
        [StringLength(80, ErrorMessage = "El correo no puede ser mayor a 80 caracteres")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Por favor introduzca la contraseña")]
        [StringLength(50, ErrorMessage = "Password can't be more than 50 digits long")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Por favor confirme la contraseña")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public int Edad
        {
            get
            {

                DateTime today = DateTime.Today;
                int edad = today.Year - FechaNac.Year;
                if (FechaNac > today.AddYears(-edad)) edad--;
                return edad;

            }
        }

    }
}
