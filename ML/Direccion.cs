using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "La calle es Obligatoria")]
        [StringLength(50, ErrorMessage = "La calle debe contener al menos 50 caracteres")]
        [Display(Name = "*Calle")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "La calle debe contener unicamente letras y espacios")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo Numero Interior es Obligatorio")]
        [StringLength(20, ErrorMessage = "El numero Interior debe contener al menos 20 caracteres")]
        [Display(Name = "*Numero Interior")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "El numero interior unicamente puede contener letras, numeros y espacios")]
        public string NumeroInterior  { get; set; }

        [Required(ErrorMessage = "El campo numero exterior es Obligatorio")]
        [StringLength(20, ErrorMessage = "El numero exterior debe contener al menos 20 caracteres")]
        [Display(Name = "*Numero exterior")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "El numero exterior unicamente puede contener letras, numeros y espacios")]
        public string NumeroExterior { get; set; }
        public ML.Colonia Colonia { get; set; }
        public List<object> Direcciones { get; set; }
    }
}
