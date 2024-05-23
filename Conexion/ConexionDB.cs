namespace CRUD.Conexion
{
    public class ConexionDB
    {
        private string conexion = string.Empty;
      

        public ConexionDB()
        {
            // Configura la carga de la configuración aquí
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            // Carga la cadena de conexión
            conexion = configuration.GetConnectionString("ConexionMaestra");
        }

        public string getCadena()
        {
            return conexion;
        }
    }
}
