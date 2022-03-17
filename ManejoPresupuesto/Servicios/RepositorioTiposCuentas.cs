using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public interface IRepositorioTiposCuentas
    {
        void Crear(TipoCuenta tipoCuenta);
    }

    public class RepositorioTiposCuentas:IRepositorioTiposCuentas
    {
        private readonly string connectionstring;
        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public void Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionstring);
            var id = connection.QuerySingle<int>($@"Insert into tiposcuentas(Nombre, UsuarioId, Orden)
                                               values(@Nombre, @UsuarioId, 0);
                                               SELECT SCOPE_IDENTITY();", tipoCuenta);
        }
    }

}
