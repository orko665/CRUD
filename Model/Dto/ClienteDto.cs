namespace CRUD.Model.Dto
{
    public class ClienteDto
    {
        public int id { get; set; }
        public int id_banco { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }

        public string mail { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }
    }
}
