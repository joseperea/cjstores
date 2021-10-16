using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cjstores.API.Data.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int Id_TD { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Display(Name = "Tipo de documento")]
        [Required (ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre_TD { get; set; }

        [MaxLength(4, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Display(Name = "Tipo de documento Abreviado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Abreviatura { get; set; }

    }
}
