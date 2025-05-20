using Compartido.DTOs.Agencias;
using Compartido.DTOs.Envios;
using Compartido.DTOs.Usuarios;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAgencia;
using LogicaAplicacion.InterfacesCasosUso.InterfacesEnvio;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Presentacion.Models.Agencias;
using Presentacion.Models.Envios;
using Presentacion.Models.Usuarios;

namespace Presentacion.Controllers
{
    public class EnvioController : Controller
    {

        private IAltaEnvioComun _altaEnvioComun { get; set; }
        private IAltaEnvioUrgente _altaEnvioUrgente { get; set; }
        private IListadoClientes _listadoClientesCU { get; set; }
        private IListadoAgencias _listadoAgenciasCU { get; set; }
        private IListadoEnvios _listadoEnvioCU {  get; set; }
        private IFinalizarEnvio _finalizarEnvioCU { get; set; }
        private IBuscarEnvio _buscarEnvioCU { get; set; }

        private IAgregarComentario _agregarComentarioCU { get; set; }

        public EnvioController(IAgregarComentario agregarComentario ,IBuscarEnvio buscarEnvio,IFinalizarEnvio finalizarEnvio, IListadoEnvios listadoEnvios,  IAltaEnvioComun altaEnvioComun,IAltaEnvioUrgente altaEnvioUrgente, IListadoClientes listadoClientesCU, IListadoAgencias listadoAgencias) {
            _altaEnvioComun = altaEnvioComun;

            _listadoClientesCU = listadoClientesCU;

            _listadoAgenciasCU = listadoAgencias;
            
            _altaEnvioUrgente = altaEnvioUrgente;

            _listadoEnvioCU = listadoEnvios;

            _finalizarEnvioCU = finalizarEnvio;

            _buscarEnvioCU = buscarEnvio;

            _agregarComentarioCU = agregarComentario;

        }

        // GET: EnvioComunController
        public ActionResult Index()
        {
            int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            if (rolUsuario == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            List<EnvioDTO> listEnviosDTO = _listadoEnvioCU.Ejecutar().ToList();
            List<EnvioListadoViewModel> enviosVM = new List<EnvioListadoViewModel>();
            foreach (EnvioDTO envioDTO in listEnviosDTO)
            {
                enviosVM.Add(new EnvioListadoViewModel()
                {
                    EmailCliente = envioDTO.EmailCliente,
                    EmailEmpleado = envioDTO.EmailEmpleado,
                    Tracking = envioDTO.Tracking,
                    Peso = envioDTO.Peso,
                    Fecha = envioDTO.Fecha,
                  
                });
            }
            ViewBag.RolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            return View(enviosVM);
        }

        // GET: EnvioComunController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnvioComunController/Create
        public ActionResult Create()
        {
            EnvioViewModel envioComunVM = new EnvioViewModel();
            envioComunVM.Usuarios = ObtenerClientes();
            envioComunVM.Agencias = ObtenerAgencias(); 
            return View(envioComunVM);
        }

        // POST: EnvioComunController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnvioViewModel envioComunVM)
        {
            int idEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId");
            try
            {

                if (ModelState.IsValid)
                {
                   
                    EnvioComunDTO envioComunDTO = new EnvioComunDTO()
                    { 
                        EmailCliente = envioComunVM.EmailCliente,
                        idEmpleado = idEmpleado,
                        Peso = envioComunVM.Peso,
                        Tracking = envioComunVM.Tracking,
                        AgenciaId = envioComunVM.AgenciaId
                    };
                    if (envioComunVM.Tracking == 0)
                    {
                        throw new EnvioComunException("El numero de tracking debe ser mayor a 0");
                    }

                    _altaEnvioComun.Ejecutar(envioComunDTO);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new EnvioComunException("Error en los datos");
                }
            }
            catch (UsuarioException ex)
            {

                ViewBag.Mensaje = ex.Message;
            }
            catch (EnvioComunException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }



            envioComunVM.Usuarios = ObtenerClientes();  
            return View(envioComunVM);
        }

        public ActionResult CreateUrgente()
        {
            EnvioUrgenteViewModel envioUrgenteVM = new EnvioUrgenteViewModel();
            envioUrgenteVM.Usuarios = ObtenerClientes();
            return View(envioUrgenteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUrgente(EnvioUrgenteViewModel envioUrgenteVM)
        {
            int idEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId");
            try
            {

                if (ModelState.IsValid)
                {

                    EnvioUrgenteDTO envioUrgenteDTO = new EnvioUrgenteDTO()
                    {
                        EmailCliente = envioUrgenteVM.EmailCliente,
                        idEmpleado = idEmpleado,
                        Peso = envioUrgenteVM.Peso,
                        Tracking = envioUrgenteVM.Tracking,
                        DireccionPostal = envioUrgenteVM.DireccionPostal
                    };
                    if (envioUrgenteVM.Tracking == 0)
                    {
                        throw new EnvioUrgenteException("El numero de tracking debe ser mayor a 0");
                    }

                    _altaEnvioUrgente.Ejecutar(envioUrgenteDTO);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new EnvioUrgenteException("Error en los datos");
                }
            }
            catch (UsuarioException ex)
            {

                ViewBag.Mensaje = ex.Message;
            }
            catch(EnvioUrgenteException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }

            envioUrgenteVM.Usuarios = ObtenerClientes();
            return View(envioUrgenteVM);
        }

        // GET: EnvioComunController/Edit/5
        public ActionResult Edit(int tracking)
        {
            int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            if (rolUsuario != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            FinalizarEnvioViewModel envioVM = new FinalizarEnvioViewModel();

            try
            {
                if (tracking <= 0)
                {
                    throw new Exception("El tracking no es correcto");
                }

                FinalizarEnvioDTO envioDTO = _buscarEnvioCU.Ejecutar(tracking);
                envioVM = new FinalizarEnvioViewModel()
                {
                    EmailCliente = envioDTO.EmailCliente,
                    EmailEmpleado = envioDTO.EmailEmpleado,
                    Tracking = envioDTO.Tracking,
                    Fecha = envioDTO.Fecha,
                    Estado = envioDTO.Estado,
                };
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
            return View(envioVM);
        }

        // POST: EnvioComunController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int tracking, FinalizarEnvioViewModel envioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FinalizarEnvioDTO envioDTO = new FinalizarEnvioDTO()
                    {
                        EmailCliente = envioVM.EmailCliente,
                        EmailEmpleado = envioVM.EmailEmpleado,
                        Tracking = envioVM.Tracking,
                        Fecha = envioVM.Fecha,
                        Estado = envioVM.Estado,
                    };
                    _finalizarEnvioCU.Ejecutar(envioDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new EnvioComunException("Error en los datos"); ;
                }

            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Datos incorrectos";
            }
            return View(envioVM);
        }


        // GET: EnvioComunController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnvioComunController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<UsuarioEmailViewModel> ObtenerClientes()
        {
            IEnumerable<EmailUsuarioDTO> emailUsuarioDtos = _listadoClientesCU.Ejecutar();
            return emailUsuarioDtos.Select(u =>
                new Models.Usuarios.UsuarioEmailViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,

                });
        }

        private IEnumerable<AgenciaViewModel> ObtenerAgencias()
        {
            IEnumerable<AgenciaDTO> agencias = _listadoAgenciasCU.Ejecutar();
            return agencias.Select(a =>
                new Models.Agencias.AgenciaViewModel()
                {
                    Id = a.Id,
                    Nombre = a.Nombre
                });
        }



        public IActionResult AgregarComentario(int tracking) {
            int idEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId");
            ComentarioViewModel comentarioVM = new ComentarioViewModel();
            try
            {
                if (tracking > 0)
                {
                    comentarioVM.TrackingEnvio = tracking;
                    comentarioVM.EmpleadoId = idEmpleado;
                }
                else
                {
                    ViewBag.Mensaje = "Tracking incorrecto";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
            return View(comentarioVM);
        }

        [HttpPost]
        public IActionResult AgregarComentario(ComentarioViewModel comentarioVM) {

            int idEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId");

            try
            {
                if (ModelState.IsValid)
                {
                    ComentarioDTO comentarioDTO = new ComentarioDTO()
                    {
                        TrackingEnvio = comentarioVM.TrackingEnvio,
                        EmpleadoId = idEmpleado,
                        Fecha = comentarioVM.Fecha,
                        Contenido = comentarioVM.Contenido
                    };
                    _agregarComentarioCU.Ejecutar(comentarioDTO);
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Mensaje = "Error en los datos";
                }
            }
            catch (EnvioComunException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex) 
            {
                ViewBag.Mensaje = "Error interno";
            
            }
            return View(comentarioVM);
        
        }

    }
}
