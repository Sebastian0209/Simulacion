using System.ComponentModel.DataAnnotations;

namespace APIparcial.Models
{
    public enum TipoProducto
    {
        Bebible,
        Comestible,
        Liquido
    }

    public enum TipoEstado
    {
        Activo,
        Inactivo
    }


    public class Almacen
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]

        public string Nombre { get; set; }

        public double Precio { get; set; }

        [Required]
        public TipoProducto Producto { get; set; }

        [Required]
        public TipoEstado Estado { get; set; }

    }
}