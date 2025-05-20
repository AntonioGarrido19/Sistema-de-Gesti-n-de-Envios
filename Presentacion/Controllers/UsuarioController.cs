using Compartido.DTOs.Usuarios;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaAplicacion.InterfacesCasosUso.InterfacesUsuario;
using LogicaNegocio.ValueObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models.Usuarios;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LogicaAplicacion.InterfacesCasosUso.InterfacesAuditoria;
using Compartido.DTOs.Auditorias;

namespace Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        private IAltaUsuario CUAltaUsuario { get; set; }

        private IListadoUsuario _listadoUsuarioCU {  get; set; }
        private IEliminarUsuario _eliminarUsuarioCU { get; set; }
        private IBuscarUsuario _buscarUsuarioCU { get; set; }

        private IModificarUsuario _modificarUsuarioCU { get; set; }

        private IAltaAuditoria _altaAuditoria { get; set; }

        public UsuarioController( IAltaAuditoria altaAuditoriaCU, IAltaUsuario cUAltaUsuario, IListadoUsuario listadoUsuarioCU, IEliminarUsuario eliminarUsuarioCU,
            IBuscarUsuario buscarUsuario, IModificarUsuario modificarUsuario)
        {
            CUAltaUsuario = cUAltaUsuario;
            _listadoUsuarioCU = listadoUsuarioCU;
            _eliminarUsuarioCU = eliminarUsuarioCU;
            _buscarUsuarioCU = buscarUsuario;
            _modificarUsuarioCU = modificarUsuario;
            _altaAuditoria = altaAuditoriaCU;
        }


        // GET: /Usuario/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Usuario/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UsuarioLoginViewModel model)
        {

            try
            {
                if ( model.Email == null) 
                {
                    throw new Exception("El email no es correcto");
                }

                
                DatoUsuarioDTO usuarioDTO = _buscarUsuarioCU.EjecutarLogin(model.Email, model.Password);
                if (usuarioDTO.Rol == 0)
                {
                    throw new UsuarioException("Usuario no autorizado a loguearse");
                }



                    //Guardar en sesison
                HttpContext.Session.SetInt32("LogueadoId", usuarioDTO.Id);
                HttpContext.Session.SetInt32("LogueadoRol", (int)usuarioDTO.Rol);
                HttpContext.Session.SetString("LogueadoNombre", usuarioDTO.Nombre);
                //HttpContext.Session.SetString("LogueadoRol", usuarioDTO.Rol());

                int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
                string nombre = HttpContext.Session.GetString("LogueadoNombre");
                int id = (int)HttpContext.Session.GetInt32("LogueadoId");

                ViewBag.Mensaje = $"Usuario en sesión: {nombre} (ID: {id}), Rol:{rolUsuario}";
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
            return View("Login");
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            if (rolUsuario == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            List<DatoUsuarioDTO> usuariosDTO = _listadoUsuarioCU.Ejecutar().ToList();
            List<DatoUsuarioViewModel> usuariosVM = new List<DatoUsuarioViewModel>();
            foreach (DatoUsuarioDTO usuarioDTO in usuariosDTO)
            {
                usuariosVM.Add(new DatoUsuarioViewModel()
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    Cedula = usuarioDTO.Cedula,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    Rol = usuarioDTO.Rol,
                });
            }


            ViewBag.RolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            return View(usuariosVM);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            if (rolUsuario == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
             int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
                if (rolUsuario != 2)
                {
                    return RedirectToAction("Index", "Home");
                }
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioVM)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    UsuarioDTO usuarioDTO = new UsuarioDTO()
                    {
                        Nombre = usuarioVM.Nombre,
                        Apellido = usuarioVM.Apellido,
                        Cedula = usuarioVM.Cedula,
                        Email = usuarioVM.Email,
                        Password = usuarioVM.Password,
                        Rol = usuarioVM.Rol,

                    };
                    CUAltaUsuario.Ejecutar(usuarioDTO);
                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                    {
                        Fecha = DateTime.Today,
                        Accion = "Alta",
                        IdUsuario = (int)HttpContext.Session.GetInt32("LogueadoId"),
                    };
                    _altaAuditoria.Ejecutar(auditoriaDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new UsuarioException("Error en los datos");
                }
            }
            catch (UsuarioException ex){ 
            
            ViewBag.Mensaje = ex.Message;
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            if (rolUsuario != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            DatoUsuarioViewModel usuarioVM = new DatoUsuarioViewModel();

            try
            {
                if (id <= 0)
                {
                    throw new Exception("El id no es correcto");
                }

                DatoUsuarioDTO usuarioDTO = _buscarUsuarioCU.Ejecutar(id);
                usuarioVM = new DatoUsuarioViewModel()
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    Cedula = usuarioDTO.Cedula,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    Rol = usuarioDTO.Rol,
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
            return View(usuarioVM);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DatoUsuarioViewModel usuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DatoUsuarioDTO usuarioDTO = new DatoUsuarioDTO()
                    {
                        Id = usuarioVM.Id,
                        Nombre = usuarioVM.Nombre,
                        Apellido = usuarioVM.Apellido,
                        Cedula = usuarioVM.Cedula,
                        Email = usuarioVM.Email,
                        Password = usuarioVM.Password,
                        Rol = usuarioVM.Rol,
                    };
                    _modificarUsuarioCU.Ejecutar(usuarioDTO);
                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                    {
                        Fecha = DateTime.Today,
                        Accion = "Editar",
                        IdUsuario = (int)HttpContext.Session.GetInt32("LogueadoId"),
                    };
                    _altaAuditoria.Ejecutar(auditoriaDTO);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Mensaje = "Datos incorrectos";
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
            return View();
        }





        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            int? rolUsuario = HttpContext.Session.GetInt32("LogueadoRol");
            if (rolUsuario != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            DatoUsuarioViewModel usuarioVM = new DatoUsuarioViewModel();
            try
            {
                if (id <= 0)
                {
                    throw new Exception("El id no es correcto");
                }

                DatoUsuarioDTO usuarioDTO = _buscarUsuarioCU.Ejecutar(id);
                usuarioVM = new DatoUsuarioViewModel()
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    Cedula = usuarioDTO.Cedula,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    Rol = usuarioDTO.Rol,
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
            return View(usuarioVM);
        
    }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id > 0)
                {
                    _eliminarUsuarioCU.Ejecutar(id);
                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                    {
                        Fecha = DateTime.Today,
                        Accion = "Elminacion",
                        IdUsuario = (int)HttpContext.Session.GetInt32("LogueadoId"),
                    };
                    _altaAuditoria.Ejecutar(auditoriaDTO);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new UsuarioException("El ID no es correcto");
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

            return View();
        }

        public IActionResult Logout()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoId");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

