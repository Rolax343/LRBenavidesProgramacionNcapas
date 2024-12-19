using ML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Services.Description;
using System.Web.UI;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll(ML.Usuario Usuario)
        {
            
            UsuarioReference.UsuarioClient cliente = new UsuarioReference.UsuarioClient();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Nombre = Usuario.Nombre == null ? "" : Usuario.Nombre;
            usuario.ApellidoPaterno = Usuario.ApellidoPaterno == null ? "" : Usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = Usuario.ApellidoMaterno == null ? "" : Usuario.ApellidoMaterno;
            usuario.Rol.IdRol = Usuario.Rol?.IdRol == null ? 0 : Usuario.Rol.IdRol;
            ML.Result resultRol = new ML.Result();
            var result = cliente.UsuarioGetAll(usuario);
            resultRol = BL.Rol.GetAllEFLinq();
            if (resultRol.Correct)
            {
                usuario.Rol.Rols = resultRol.Objects;
            }
            else
            {
                ViewBag.Mensaje = "No hay Roles para mostrar";
                return PartialView("Modal");
            }
            if (result.Correct)
            {

                usuario.Usuarios = result.Objects.ToList();
                return View(usuario);
            }
            else
            {
                ViewBag.error = "Hubo un error al obtener las materias: '" + result.ErrorMessage + "'";
                return View(usuario);
            }

        }

        [HttpPost]
        public ActionResult InsercionMasiva()
        {
            if (Session["pathExcel"] == null)
            {
                HttpPostedFileBase Archivo = Request.Files["UsuarioCarga"];

                if (Archivo != null || Archivo.ContentLength > 0)
                {
                    string extensionPermitidaText = ConfigurationManager.AppSettings["ExtensionText"];
                    string extensionPermitidaExcel = ConfigurationManager.AppSettings["ExtensionExcel"];
                    string extensionArchivo = Path.GetExtension(Archivo.FileName);

                    if (extensionArchivo == extensionPermitidaText)
                    {
                        StreamReader reader = new StreamReader(Archivo.InputStream);
                        String Resultado = BL.InsercionMasiva.UsuarioInsercionMasiva(reader);
                        ViewBag.Mensaje = Resultado;
                        return PartialView("Modal");

                    }
                    else if (extensionArchivo == extensionPermitidaExcel)
                    {
                        string filepath = Server.MapPath("~/CargaMasiva/") + Path.GetFileNameWithoutExtension(Archivo.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx";

                        if (!System.IO.File.Exists(filepath))
                        {
                            Archivo.SaveAs(filepath);
                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filepath;

                            ML.Result leerResult = BL.InsercionMasiva.LeerExcel(connectionString);

                            if (leerResult.Correct)
                            {

                                ML.Result resultValidar = BL.InsercionMasiva.Validacion(leerResult.Objects);
                                if (resultValidar.Objects.Count > 0)
                                {
                                    string ErroresValidacion = "";
                                    foreach (ML.ErrorExcel errorExcel in resultValidar.Objects)
                                    {
                                        ErroresValidacion += "Error en el registro numero " + errorExcel.NumeroRegistro + ":\n  "
                                            + errorExcel.Error;
                                    }
                                    ViewBag.Mensaje = ErroresValidacion;
                                }
                                else
                                {
                                    Session["pathExcel"] = filepath;
                                    ViewBag.Mensaje = "El archivo fue validado correctamente";
                                }

                            }
                            else
                            {
                                ViewBag.Mensaje = "No se pudo leer el archivo: " + leerResult.ErrorMessage;
                            }
                        }
                        else
                        {
                            ViewBag.Mensaje = "No se puedo guardar su archivo";
                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "El tipo de archivo no es compatible";

                    }
                }
                else
                {
                    ViewBag.Mensaje = "No se ha seleccionado ningun archivo";

                }
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + Session["pathExcel"].ToString();

                ML.Result leerExcel = BL.InsercionMasiva.LeerExcel(connectionString);

                if (leerExcel.Correct)
                {
                    string ErroresBD = "";
                    int NumeroRegistro = 1;
                    int RegistrosExitosos = 0;
                    int RegistrosErroneos = 0;
                    foreach (ML.Usuario usuario in leerExcel.Objects)
                    {
                        NumeroRegistro++;
                        ML.Result resultAgregar = BL.Usuario.AddEFSP(usuario);
                        if (!resultAgregar.Correct)
                        {
                            RegistrosErroneos++;
                            ErroresBD += "Hubo un error al agregarse el registro numero " + NumeroRegistro + ":\n   " + resultAgregar.ErrorMessage +"\n";
                        } else
                        {
                            RegistrosExitosos++;
                        }
                    }
                    string mensajeResultado = "Registros Exitosos: " + RegistrosExitosos + "\nErrores: " + RegistrosErroneos + "\n" + ErroresBD;
                    ViewBag.Mensaje = mensajeResultado;
                    Session["pathExcel"] = null;
                }
            }
            
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            if (IdUsuario == null)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.Rol = new ML.Rol();
                ML.Result resultRol = new ML.Result();
                resultRol = BL.Rol.GetAllEFLinq();
                if (resultRol.Correct)
                {
                    usuario.Rol.Rols = resultRol.Objects;
                }
                else
                {
                    ViewBag.Mensaje = "No hay Roles para mostrar";
                    return PartialView("Modal");
                }
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Colonias = new List<object>();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Municipios = new List<object>();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                ML.Result resultEstados = new ML.Result();
                resultEstados = BL.Estado.GetAllEFLinq();
                if (resultEstados.Correct)
                {
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                }
                else
                {
                    ViewBag.Mensaje = "No hay Estados para mostrar para mostrar";
                    return PartialView("Modal");
                }


                return View(usuario);
            }
            else
            {

                ML.Result result = BL.Usuario.GetByIdEFSP(IdUsuario.Value);
                if (result.Correct)
                {
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                    usuario = (ML.Usuario)result.Object;
                    ML.Result resultRol = new ML.Result();
                    resultRol = BL.Rol.GetAllEFLinq();
                    if (resultRol.Correct)
                    {
                        usuario.Rol.Rols = resultRol.Objects;
                    }
                    else
                    {
                        ViewBag.Mensaje = "No hay Roles para mostrar";
                        return PartialView("Modal");
                    }

                    ML.Result resultEstados = new ML.Result();
                    resultEstados = BL.Estado.GetAllEFLinq();
                    if (resultEstados.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                    }
                    else
                    {
                        ViewBag.Mensaje = "No hay Estados para mostrar para mostrar";
                        return PartialView("Modal");
                    }
                    ML.Result resultMunicipios = new ML.Result();
                    resultMunicipios = BL.Municipio.GetAllEFSP(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    if (resultMunicipios.Correct)
                    {
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    }
                    else
                    {
                        ViewBag.Mensaje = "No hay Estados para mostrar para mostrar";
                        return PartialView("Modal");
                    }
                    ML.Result resultColonias = new ML.Result();
                    resultColonias = BL.Colonia.GetAllEFSP(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    if (resultColonias.Correct)
                    {
                        usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                    }
                    else
                    {
                        ViewBag.Mensaje = "No hay Estados para mostrar para mostrar";
                        return PartialView("Modal");
                    }
                    if (usuario.Imagen != null)
                    {
                        if (usuario.Imagen[0] == 0x89 && usuario.Imagen[1] == 0x50 && usuario.Imagen[2] == 0x4E && usuario.Imagen[3] == 0x47)
                        {
                            usuario.ImagenMime = "image/png";
                        }
                        if (usuario.Imagen[0] == 0xFF && usuario.Imagen[1] == 0xD8)
                        {
                            usuario.ImagenMime = "image/jpeg";
                        }
                    }
                    return View(usuario);

                }
                else
                {
                    ViewBag.Mensaje = "ocurrio un error al identificar el registro" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
            {
            if (ModelState.IsValid)
            {
                if (usuario.Id == 0)
                {
                    HttpPostedFileBase imagen = Request.Files["ImagenUsuario"];

                    if (imagen.ContentLength > 0)
                    {
                        usuario.Imagen = ConvertirImagenAByte(imagen);
                    }
                    UsuarioReference.UsuarioClient cliente = new UsuarioReference.UsuarioClient();
                    var resultUsuario = cliente.UsuarioAdd(usuario);

                    if (resultUsuario.Correct)
                    {
                        ViewBag.Mensaje = "El usuario fue registrado con exito";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo registrar el usuario" + resultUsuario.ErrorMessage;
                    }
                    return PartialView("Modal");
                }
                else
                {
                    HttpPostedFileBase imagen = Request.Files["ImagenUsuario"];

                    if (imagen.ContentLength > 0)
                    {
                        usuario.Imagen = ConvertirImagenAByte(imagen);
                    }
                    UsuarioReference.UsuarioClient cliente = new UsuarioReference.UsuarioClient();
                    var result = cliente.UsuarioUpdate(usuario);

                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El usuario fue actualizado con exito";
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se pudo actualizar el usuario" + result.ErrorMessage;
                    }
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result resultRol = new ML.Result();
                resultRol = BL.Rol.GetAllEFLinq();
                if (resultRol.Correct)
                {
                    usuario.Rol.Rols = resultRol.Objects;
                }
                ML.Result resultEstados = new ML.Result();
                resultEstados = BL.Estado.GetAllEFLinq();
                if (resultEstados.Correct)
                {
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                }
                ML.Result resultMunicipios = new ML.Result();
                resultMunicipios = BL.Municipio.GetAllEFSP(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                if (resultMunicipios.Correct)
                {
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                }
                ML.Result resultColonias = new ML.Result();
                resultColonias = BL.Colonia.GetAllEFSP(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                if (resultColonias.Correct)
                {
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                }
                return View(usuario);
            }
        }

        [HttpGet]

        public ActionResult Delete(int IdUsuario)
        {
            UsuarioReference.UsuarioClient cliente = new UsuarioReference.UsuarioClient();
            var result = cliente.UsuarioDelete(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Mensaje = "El usuario fue eliminado con exito";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar el usuario" + result.ErrorMessage;
            }
            return PartialView("Modal");


        }

        [HttpGet]
        public ActionResult confirmacion(int IdUsuario)
        {
            ViewBag.ID = IdUsuario;
            return PartialView("Modal_delete");
        }

        [HttpGet]
        public JsonResult GetMunicipiosByIdEstado(int IDEstado)
        {
            ML.Result result = new ML.Result();
            result = BL.Municipio.GetAllEFSP(IDEstado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUsuarioStatus(int IdUsuario,bool Status)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.UpdateStatusEFSP(IdUsuario , Status);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetColoniasByIdMunicipio(int IDMunicipio)
        {
            ML.Result result = new ML.Result();
            result = BL.Colonia.GetAllEFSP(IDMunicipio);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertirImagenAByte(HttpPostedFileBase Imagen)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            byte[] data = reader.ReadBytes((int)Imagen.ContentLength);
            return data;
        }

        public ActionResult EnviarCorreo ()
        {
            try
            {
                string correo = ConfigurationManager.AppSettings["Correo"].ToString();
                string contraseña = ConfigurationManager.AppSettings["Contraseña"].ToString();
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(correo, contraseña),
                    EnableSsl = true
                };
                var mensaje = new MailMessage
                {
                    From = new MailAddress(correo, "Rolax"),
                    Subject = "Correo de Prueba",
                    Body = @"
                                <html>
                                    <body style='text-align: center;'>
                                        <h1 style='font-style: italic; color: red;'>WASAAAAAAAAAAAAAAAAAAAAAAAA</h1>
                                        <a href='https://i.pinimg.com/736x/8b/f6/96/8bf696fe7045f94be2d21c23c5f61a1c.jpg'>
                                            <img src='https://i.pinimg.com/736x/8b/f6/96/8bf696fe7045f94be2d21c23c5f61a1c.jpg' alt='Imagen' style='max-width: 100%; height: auto;' />
                                        </a>
                                    </body>
                                </html>", 
                    IsBodyHtml = true
                };

                mensaje.To.Add("jguevaraflores3@gmail.com");
                smtpClient.Send(mensaje);
                ViewBag.Mensaje = "Correo Enviado Exitosamente";
                return PartialView("Modal");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return PartialView("Modal");
        }

    }
}