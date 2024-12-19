using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ML
{
    public class Usuario
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        [StringLength(50, ErrorMessage = "El Nombre no puede exceder los 50 caracteres")]
        [Display(Name = "*Nombre de pila")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El formato de nombre solo puede contener letras y espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es Obligatorio")]
        [StringLength(50, ErrorMessage = "El Apellido Paterno no puede exceder los 50 caracteres")]
        [Display(Name = "*Apellido Paterno")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ]*$", ErrorMessage = "El apellido paterno solo puede contener letras")]
        public string ApellidoPaterno { get; set; }

        [StringLength(50, ErrorMessage = "El Apellido Materno no puede exceder los 50 caracteres")]
        [Display(Name = "Apellido Materno")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ]*$", ErrorMessage = "El apellido materno solo puede contener letras")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El Campo Sexo es Obligatorio")]
        [Display(Name = "*Sexo")]
        [RegularExpression(@"[H-M]", ErrorMessage = "El campo Sexo solo puede contener la letra 'H' o 'M'")]
        [XmlElement(DataType = "string")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El Campo UserName es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo UserName no puede exceder los 50 caracteres")]
        [Display(Name = "*Nombre de Usuario")]
        [RegularExpression(@"^[^\s]*$", ErrorMessage = "El campo UserName no puede contener espacios")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Campo Email es Obligatorio")]
        [StringLength(254, ErrorMessage = "El campo Email no puede exceder los 254 caracteres")]
        [Display(Name = "*Correo Electronico")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El Campo Email no coincide con el formato aceptado")]

        public string Email { get; set; }
        [Required(ErrorMessage = "El Campo Password es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo Password no puede exceder los 50 caracteres")]
        [Display(Name = "*Contraseña")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?"":{}|<>])[A-Za-z0-9!@#$%^&*(),.?"":{}|<>]{8,}$", ErrorMessage = "El Campo Contraseña no coincide con el formato aceptado")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Telefono es Obligatorio")]
        [StringLength(20, ErrorMessage = "El campo Telefono no puede exceder los 20 caracteres")]
        [Display(Name = "*Telefono")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Campo Telefono solo puede contener numeros")]
        public string Telefono { get; set; }

        [StringLength(50, ErrorMessage = "El campo Celular no puede exceder los 20 caracteres")]
        [Display(Name = "Celular")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Campo Celular solo puede contener numeros")]
        public string Celular { get; set; }

        [StringLength(10, MinimumLength =10 , ErrorMessage = "La fecha debe contener exactamente 10 caracteres")]
        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        [StringLength(18, MinimumLength = 18, ErrorMessage = "El CURP debe contener exactamente 18 caracteres")]
        [Display(Name = "CURP")]
        [RegularExpression(@"^(|[A-Z]{4}\d{6}[HM]{1}[A-Z]{5}[0-9]{2})$", ErrorMessage = "El CURP no coincide con el formato establecido")]
        public string CURP { get; set; }
        
        public ML.Rol Rol { get; set; }

        public List<object> Usuarios { get; set; }

        public ML.Direccion Direccion { get; set; }

        public string ImagenMime { get; set; }

        public byte[] Imagen { get; set; }

        public bool Status { get; set; }
    }
}
