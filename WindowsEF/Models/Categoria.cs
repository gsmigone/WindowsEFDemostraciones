using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        //EF convension: Id, ID o CategoriaID
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]// tipo de datos de sql server
        [StringLength(50)]
        public string Nombre { get; set; }

        #region propiedades de navegacion
        public List<Producto> Productos { get; set; }

        #endregion
    }
}
