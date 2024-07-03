namespace MarketPeruCore.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public decimal? PrecioProveedor { get; set; }
        public short StockActual { get; set; }
        public short StockMinimo { get; set; }
        public bool Descontinuado { get; set; }
        public bool Estado { get; set; }
    }
}
