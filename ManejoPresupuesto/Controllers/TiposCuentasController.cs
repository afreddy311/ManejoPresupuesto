using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller    
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;
        //Se coloca la interfaz
        public TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas)
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
        }

        

        public IActionResult Crear()
        {  

           return View();
        }

        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }
            //Se coloca el repositorio y probamos con un usuario
            tipoCuenta.UsuarioId = 3;
            repositorioTiposCuentas.Crear(tipoCuenta);
            return View();
        }
        
    }
}
