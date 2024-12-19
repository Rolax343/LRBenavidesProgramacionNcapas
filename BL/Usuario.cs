using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //public static ML.Result Addsp (ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("UsuarioAdd", context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
        //            cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
        //            cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
        //            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
        //            cmd.Parameters.AddWithValue("@Email", usuario.Email);
        //            cmd.Parameters.AddWithValue("@Password", usuario.Password);
        //            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //            cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
        //            cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
        //            cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
        //            cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);


        //            context.Open();
        //            int rowsaffected = cmd.ExecuteNonQuery();
        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    } catch (Exception ex) { 

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result Updatesp(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("UsuarioUpdate", context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IdUsuario", usuario.Id);
        //            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
        //            cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
        //            cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
        //            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
        //            cmd.Parameters.AddWithValue("@Email", usuario.Email);
        //            cmd.Parameters.AddWithValue("@Password", usuario.Password);
        //            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //            cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
        //            cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
        //            cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
        //            cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);


        //            context.Open();
        //            int rowsaffected = cmd.ExecuteNonQuery();
        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result Delete(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario", context);
        //            cmd.Parameters.AddWithValue("@IdUsuario", usuario.Id);

        //            context.Open();
        //            int rowsaffected = cmd.ExecuteNonQuery();
        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result Deletesp(byte ID)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("UsuarioDelete", context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IdUsuario", ID);

        //            context.Open();
        //            int rowsaffected = cmd.ExecuteNonQuery();
        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("UsuarioGetAll", context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            DataTable tableUsuario = new DataTable();

        //            adapter.Fill(tableUsuario);

        //            if (tableUsuario.Rows.Count > 0)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (DataRow row in tableUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Id = Convert.ToByte(row[0]);
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.Sexo = (row[4].ToString()).First();
        //                    usuario.UserName = row[5].ToString();
        //                    usuario.Email = row[6].ToString();
        //                    usuario.Password = row[7].ToString();
        //                    usuario.Telefono = row[8].ToString();
        //                    usuario.Celular = row[9].ToString();
        //                    usuario.FechaNacimiento = row[10].ToString();
        //                    usuario.CURP = row[11].ToString();
        //                    usuario.Rol.IdRol = Convert.ToByte(row[12].ToString());

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result GetById(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("UsuarioGetById", context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IdUsuario", usuario.Id);

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            DataTable tableUsuario = new DataTable();

        //            adapter.Fill(tableUsuario);

        //            if (tableUsuario.Rows.Count > 0)
        //            {

        //                DataRow row = tableUsuario.Rows[0];

        //                usuario.Id = Convert.ToByte(row[0]);
        //                usuario.Nombre = row[1].ToString();
        //                usuario.ApellidoPaterno = row[2].ToString();
        //                usuario.ApellidoMaterno = row[3].ToString();
        //                usuario.Sexo = (row[4].ToString()).First();
        //                usuario.UserName = row[5].ToString();
        //                usuario.Email = row[6].ToString();
        //                usuario.Password = row[7].ToString();
        //                usuario.Telefono = row[8].ToString();
        //                usuario.Celular = row[9].ToString();
        //                usuario.FechaNacimiento = row[10].ToString();
        //                usuario.CURP = row[11].ToString();
        //                usuario.Rol.IdRol = Convert.ToByte(row[12].ToString());

        //                result.Object = usuario;

        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        public static ML.Result AddEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    
                    int rowsaffected = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, Convert.ToString(usuario.Sexo), usuario.UserName,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento,
                        usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, usuario.Imagen);
                    if (rowsaffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateEFSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    int rowsaffected = context.UsuarioUpdate(usuario.Id, usuario.Nombre, usuario.ApellidoPaterno, usuario.Sexo, usuario.UserName,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento,
                        usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.IdDireccion, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, usuario.Imagen);
                    if (rowsaffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateStatusEFSP(int IdUsuario, bool Status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    int rowsaffected = context.StatusUpdate(IdUsuario, Status);
                    if (rowsaffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result DeleteEFSP(int ID)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    int rowsaffected = context.UsuarioDelete(ID);
                    if (rowsaffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAllEFSP(ML.Usuario Usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {

                    var tableUsuario = context.UsuarioGetAll(Usuario.Nombre, Usuario.ApellidoPaterno, Usuario.ApellidoMaterno, Usuario.Rol.IdRol).ToList();

                    if (tableUsuario.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in tableUsuario)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Id = Convert.ToInt32(item.IdUsuario);
                            usuario.Nombre = item.Usuario_Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Sexo = item.Sexo;
                            usuario.UserName = item.UserName;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.Direccion.Calle = item.Calle;
                            usuario.Direccion.NumeroInterior = item.NumeroInterior;
                            usuario.Direccion.NumeroExterior = item.NumeroExterior;
                            usuario.Direccion.Colonia.Nombre = item.Colonia_Nombre;
                            usuario.Direccion.Colonia.CodigoPostal = item.CodigoPostal;
                            usuario.Direccion.Colonia.Municipio.Nombre = item.Municipio_Nombre;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = item.Estado_Nombre;
                            usuario.Imagen = item.Imagen;
                            usuario.Status = item.Status.Value;
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
                            if (item.FechaNacimiento != null)
                            {
                                usuario.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            } else
                            {
                                usuario.FechaNacimiento = null;
                            }
                            usuario.CURP = item.CURP;
                            usuario.Rol.IdRol = Convert.ToByte(item.IdRol);
                            usuario.Rol.NombreRol = item.Rol_Nombre;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros que coincidan con la busqueda";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetByIdEFSP(int ID)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    var tableUsuario = context.UsuarioGetById(ID).FirstOrDefault();

                    if (tableUsuario != null)
                    {
                        result.Object = new object();
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Id = Convert.ToInt32(tableUsuario.IdUsuario);
                        usuario.Nombre = tableUsuario.Usuario_Nombre;
                        usuario.ApellidoPaterno = tableUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = tableUsuario.ApellidoMaterno;
                        usuario.Sexo = tableUsuario.Sexo;
                        usuario.UserName = tableUsuario.UserName;
                        usuario.Email = tableUsuario.Email;
                        usuario.Password = tableUsuario.Password;
                        usuario.Telefono = tableUsuario.Telefono;
                        usuario.Celular = tableUsuario.Celular;
                        usuario.Direccion.Colonia.IdColonia = tableUsuario.IdColonia;
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = tableUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = tableUsuario.IdEstado;
                        usuario.Direccion.IdDireccion = tableUsuario.IdDireccion;
                        usuario.Direccion.Calle = tableUsuario.Calle;
                        usuario.Direccion.NumeroInterior = tableUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = tableUsuario.NumeroExterior;
                        usuario.Imagen = (tableUsuario.Imagen);
                        
                        if (tableUsuario.FechaNacimiento == null)
                        {
                            usuario.FechaNacimiento = null;
                        }
                        usuario.CURP = tableUsuario.CURP;
                        usuario.Rol.IdRol = Convert.ToByte(tableUsuario.IdRol);
                        usuario.Rol.NombreRol = tableUsuario.Rol_Nombre;

                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        
        //public static ML.Result AddEFLinq(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
        //        {
        //            DL_EF.Usuario usuarioEF = new DL_EF.Usuario();

        //            usuarioEF.Nombre = usuario.Nombre;
        //            usuarioEF.ApellidoPaterno = usuario.ApellidoPaterno;
        //            usuarioEF.ApellidoMaterno = usuario.ApellidoMaterno;
        //            usuarioEF.Sexo = Convert.ToString(usuario.Sexo);
        //            usuarioEF.UserName = usuario.UserName;
        //            usuarioEF.Email = usuario.Email;
        //            usuarioEF.Password = usuario.Password;
        //            usuarioEF.Telefono = usuario.Telefono;
        //            usuarioEF.Celular = usuario.Celular;
        //            usuarioEF.FechaNacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
        //            usuarioEF.CURP = usuario.CURP;
        //            usuarioEF.IdRol = usuario.Rol.IdRol;

        //            context.Usuarios.Add(usuarioEF);
        //            int rowsaffected = context.SaveChanges();
                    
        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result UpdateEFLinq(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
        //        {
        //            var usuarioEF = (from usuariolinq in context.Usuarios 
        //                             where usuariolinq.IdUsuario == usuario.Id 
        //                             select usuariolinq).SingleOrDefault();
        //            if (usuarioEF != null)
        //            {
        //                usuarioEF.Nombre = usuario.Nombre;
        //                usuarioEF.ApellidoPaterno = usuario.ApellidoPaterno;
        //                usuarioEF.ApellidoMaterno = usuario.ApellidoMaterno;
        //                usuarioEF.Sexo = Convert.ToString(usuario.Sexo);
        //                usuarioEF.UserName = usuario.UserName;
        //                usuarioEF.Email = usuario.Email;
        //                usuarioEF.Password = usuario.Password;
        //                usuarioEF.Telefono = usuario.Telefono;
        //                usuarioEF.Celular = usuario.Celular;
        //                usuarioEF.FechaNacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
        //                usuarioEF.CURP = usuario.CURP;
        //                usuarioEF.IdRol = usuario.Rol.IdRol;
        //            }

                    
        //            int rowsaffected = context.SaveChanges();

        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result DeleteEFLinq(int ID)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
        //        {
        //            var usuarioEF = (from usuariolinq in context.Usuarios
        //                             where usuariolinq.IdUsuario == ID
        //                             select usuariolinq).SingleOrDefault();
        //            context.Usuarios.Remove(usuarioEF);
        //            int rowsaffected = context.SaveChanges();

        //            if (rowsaffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result GetAllEFLinq()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
        //        {

        //            var tableUsuario = (from usuariolinq in context.Usuarios
        //                                join rollinq in context.Rols on usuariolinq.IdRol equals rollinq.IdRol
        //                                select new
        //                                {
        //                                    IdUsuario = usuariolinq.IdUsuario,
        //                                    Nombre = usuariolinq.Nombre,
        //                                    ApellidoPaterno = usuariolinq.ApellidoPaterno,
        //                                    ApellidoMaterno = usuariolinq.ApellidoMaterno,
        //                                    Sexo = usuariolinq.Sexo,
        //                                    UserName = usuariolinq.UserName,
        //                                    Email = usuariolinq.Email,
        //                                    Password = usuariolinq.Password,
        //                                    Telefono = usuariolinq.Telefono,
        //                                    Celular = usuariolinq.Celular,
        //                                    FechaNacimiento = usuariolinq.FechaNacimiento,
        //                                    CURP = usuariolinq.CURP,
        //                                    IdRol = usuariolinq.IdRol,
        //                                    NombreRol = rollinq.Nombre
        //                                }).ToList();

        //            if (tableUsuario.Count > 0)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (var item in tableUsuario)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Id = Convert.ToByte(item.IdUsuario);
        //                    usuario.Nombre = item.Nombre;
        //                    usuario.ApellidoPaterno = item.ApellidoPaterno;
        //                    usuario.ApellidoMaterno = item.ApellidoMaterno;
        //                    usuario.Sexo = (item.Sexo).First();
        //                    usuario.UserName = item.UserName;
        //                    usuario.Email = item.Email;
        //                    usuario.Password = item.Password;
        //                    usuario.Telefono = item.Telefono;
        //                    usuario.Celular = item.Celular;
        //                    usuario.FechaNacimiento = Convert.ToString(item.FechaNacimiento);
        //                    usuario.CURP = item.CURP;
        //                    usuario.Rol.IdRol = Convert.ToByte(item.IdRol);
        //                    usuario.Rol.NombreRol = item.NombreRol;

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
        //public static ML.Result GetByIdEFLinq(int ID)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
        //        {
        //            var tableUsuario = (from usuariolinq in context.Usuarios
        //                                where usuariolinq.IdUsuario == ID
        //                                select usuariolinq).FirstOrDefault();

        //            if (tableUsuario != null)
        //            {
        //                result.Object = new object();
        //                ML.Usuario usuario = new ML.Usuario();
        //                usuario.Rol = new ML.Rol();
        //                usuario.Id = Convert.ToByte(tableUsuario.IdUsuario);
        //                usuario.Nombre = tableUsuario.Nombre;
        //                usuario.ApellidoPaterno = tableUsuario.ApellidoPaterno;
        //                usuario.ApellidoMaterno = tableUsuario.ApellidoMaterno;
        //                usuario.Sexo = (tableUsuario.Sexo).First();
        //                usuario.UserName = tableUsuario.UserName;
        //                usuario.Email = tableUsuario.Email;
        //                usuario.Password = tableUsuario.Password;
        //                usuario.Telefono = tableUsuario.Telefono;
        //                usuario.Celular = tableUsuario.Celular;
        //                usuario.FechaNacimiento = Convert.ToString(tableUsuario.FechaNacimiento);
        //                usuario.CURP = tableUsuario.CURP;
        //                usuario.Rol.IdRol = Convert.ToByte(tableUsuario.IdRol);

        //                result.Object = usuario;
        //                result.Correct = true;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}
    }
}
