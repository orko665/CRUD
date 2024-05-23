namespace CRUD.Model.Dto
{
    public class FacturaDto
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public string nro_factura { get; set; }
        public DateTime fecha_hora { get; set; }
        public double total { get; set; }
        public double total_iva5 { get; set; }
        public double total_iva10 { get; set; }
        public double total_iva { get; set; }
        public int total_letras { get; set; }
        public string sucursal { get; set; }

    }
}
