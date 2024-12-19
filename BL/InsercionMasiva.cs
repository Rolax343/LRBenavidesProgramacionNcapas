using Microsoft.SqlServer.Server;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class InsercionMasiva
    {
        public static string UsuarioInsercionMasiva(StreamReader reader)
        {
            ML.Result result = new ML.Result();
            string registroserroneos = "";
            int RegistroExitoso = 0;
            int NumeroRegistro = 0;
            string linea = "";
            linea = reader.ReadLine();
            while ((linea = reader.ReadLine()) != null)
            {
                try
                {
                    string[] arreglo = linea.Split('|');
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Rol = new ML.Rol();
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Nombre = arreglo[0];
                    usuario.ApellidoPaterno = arreglo[1];
                    usuario.ApellidoMaterno = arreglo[2];
                    usuario.Sexo = arreglo[3];
                    usuario.UserName = arreglo[4];
                    usuario.Email = arreglo[5];
                    usuario.Password = arreglo[6];
                    usuario.Telefono = arreglo[7];
                    usuario.Celular = arreglo[8];
                    usuario.FechaNacimiento = arreglo[9];
                    if (usuario.FechaNacimiento != null)
                    {
                        DateTime Fecha = DateTime.ParseExact(usuario.FechaNacimiento.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        {
                            usuario.FechaNacimiento = Fecha.ToString("dd-MM-yyyy");
                        }                        
                    } else
                    {
                        usuario.FechaNacimiento = null;
                    }
                    usuario.CURP = arreglo[10];
                    usuario.Rol.IdRol = Convert.ToInt32(arreglo[11]);
                    usuario.Direccion.Calle = arreglo[12];
                    usuario.Direccion.NumeroInterior = arreglo[13];
                    usuario.Direccion.NumeroExterior = arreglo[14];
                    usuario.Direccion.Colonia.IdColonia = Convert.ToInt32(arreglo[15]);

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


                if (result.Correct)
                {
                    RegistroExitoso++;
                    NumeroRegistro++;
                }
                else
                {
                    NumeroRegistro++;
                    registroserroneos = registroserroneos + "No se ha podido insertar el registro numero " + NumeroRegistro + ". " + result.ErrorMessage + "\n";

                }

            }
            string Mensaje = registroserroneos + RegistroExitoso + " registros exitosos";
            return Mensaje;
        }

        public static ML.Result LeerExcel (string ConnectionString)
        {
            ML.Result result = new ML.Result ();
            try
            {
                using (OleDbConnection context = new OleDbConnection(ConnectionString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tableUsuario = new DataTable();
                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow item in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Rol = new ML.Rol();
                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Nombre = item[0].ToString();
                                usuario.ApellidoPaterno = item[1].ToString();
                                usuario.ApellidoMaterno = item[2].ToString();
                                string Sexo = item[3].ToString();
                                if (Sexo != "" && Sexo.Length == 1)
                                {
                                    usuario.Sexo = Sexo.ToUpper();
                                }
                                usuario.UserName = item[4].ToString();
                                usuario.Email = item[5].ToString();
                                usuario.Password = item[6].ToString();
                                usuario.Telefono = item[7].ToString();
                                usuario.Celular = item[8].ToString();
                                if (usuario.Celular == "")
                                {
                                    usuario.Celular = null;
                                }
                                usuario.FechaNacimiento = item[9].ToString();
                                if (usuario.FechaNacimiento != "")
                                {
                                    DateTime Fecha;
                                    if (DateTime.TryParseExact(usuario.FechaNacimiento.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out Fecha))
                                    {
                                        usuario.FechaNacimiento = Fecha.ToString("dd-MM-yyyy");
                                    }
                                }
                                else
                                {
                                    usuario.FechaNacimiento = null;
                                }
                                usuario.CURP = item[10].ToString();
                                if (usuario.CURP == "")
                                {
                                    usuario.CURP = null;
                                }
                                string IdRol = item[11].ToString();
                                if (IdRol != "")
                                {
                                    bool soloNumeros = true;
                                    foreach (char numero in IdRol)
                                    {
                                        if (numero < '0' || numero > '9')
                                        {
                                            soloNumeros = false;
                                            break;
                                        }
                                    }
                                    if (soloNumeros)
                                    {
                                        usuario.Rol.IdRol = Convert.ToInt32(IdRol);
                                    } else
                                    {
                                        usuario.Rol.IdRol = 0;
                                    }
                                } else
                                {
                                    usuario.Rol.IdRol = null;
                                }
                                usuario.Direccion.Calle = item[12].ToString();
                                usuario.Direccion.NumeroInterior = item[13].ToString();
                                usuario.Direccion.NumeroExterior = item[14].ToString();
                                string IdColonia = item[15].ToString();
                                if (IdColonia != "")
                                {
                                    bool soloNumeros = true;
                                    foreach (char numero in IdColonia)
                                    {
                                        if (numero < '0' || numero > '9')
                                        {
                                            soloNumeros = false;
                                            break;
                                        }
                                    }
                                    if (soloNumeros)
                                    {
                                        usuario.Direccion.Colonia.IdColonia = Convert.ToInt32(IdColonia);
                                    }
                                    else
                                    {
                                        usuario.Direccion.Colonia.IdColonia = 0;
                                    }
                                    
                                } 
                                else
                                {
                                    usuario.Direccion.Colonia.IdColonia = null;
                                }
                                

                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo recuperar los registros del archivo .xlsx";
                        }

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


        public static ML.Result Validacion(List<object> Objects)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            
            int NumeroRegistro = 1;
            foreach (ML.Usuario usuario in Objects)
            {
                ML.ErrorExcel errorExcel = new ML.ErrorExcel();
                errorExcel.NumeroRegistro = NumeroRegistro;

                if (usuario.Nombre == "")
                {
                    errorExcel.Error += "   El campo de Nombre esta vacio\n";
                }
                if (usuario.Nombre.Length > 50)
                {
                    errorExcel.Error += "   El campo de Nombre excede los 50 caracteres\n";
                }
                if (usuario.ApellidoPaterno == "")
                {
                    errorExcel.Error += "   El campo de Apellido Paterno esta vacio\n";
                }
                if (usuario.ApellidoPaterno.Length > 50)
                {
                    errorExcel.Error += "   El campo de Apellido Paterno excede los 50 caracteres\n";
                }
                if (usuario.ApellidoMaterno.Length > 50)
                {
                    errorExcel.Error += "   El campo de Apellido Materno excede los 50 caracteres\n";
                }
                if (usuario.Sexo == null)
                {
                    errorExcel.Error += "   El campo de Sexo esta vacio o contiene mas de 1 caracter\n";
                }
                else
                {
                    if (usuario.Sexo.ToString() != "H" && usuario.Sexo.ToString() != "M")
                    {
                        errorExcel.Error += "   El campo de sexo no corresponde a un caracter valido (H,M)\n";
                    }
                }
                if (usuario.UserName == "")
                {
                    errorExcel.Error += "   El campo de UserName esta vacio\n";
                }
                if (usuario.UserName.Length > 50)
                {
                    errorExcel.Error += "   El campo de UserName excede los 50 caracteres\n";
                }
                if (usuario.Email == "")
                {
                    errorExcel.Error += "   El campo de Email esta vacio\n";
                }
                if (usuario.Email.Length > 254)
                {
                    errorExcel.Error += "   El campo de Email excede los 254 caracteres\n";
                }
                if (usuario.Password == "")
                {
                    errorExcel.Error += "   El campo de Password esta vacio\n";
                }
                if (usuario.Password.Length > 50)
                {
                    errorExcel.Error += "   El campo de Passqord excede los 50 caracteres\n";
                }
                if (usuario.Telefono == "")
                {
                    errorExcel.Error += "   El campo de Telefono esta vacio\n";
                }
                if (usuario.Telefono.Length > 20)
                {
                    errorExcel.Error += "   El campo de Telefono excede los 20 caracteres\n";
                }
                foreach (char numero in usuario.Telefono)
                {
                    if (numero < '0' || numero > '9')
                    {
                        errorExcel.Error += "   El campo de Telefono contiene caracteres que no son numeros\n";
                        break;
                    }
                }
                if (usuario.Celular != null)
                {
                    if (usuario.Celular.Length > 20)
                    {
                        errorExcel.Error += "   El campo de Telefono excede los 20 caracteres\n";
                    }
                    foreach (char numero in usuario.Celular)
                    {
                        if (numero < '0' || numero > '9')
                        {
                            errorExcel.Error += "   El campo de Telefono contiene caracteres que no son numeros\n";
                            break;
                        }

                    }
                }
                if (usuario.FechaNacimiento != null)
                {
                    if (usuario.FechaNacimiento.Length > 10)
                    {
                        errorExcel.Error += "   El campo de fecha de nacimiento contiene mas de 10 caracteres\n";
                    }
                    else if (usuario.FechaNacimiento.Length < 10)
                    {
                        errorExcel.Error += "   El campo de fecha de nacimiento contiene menos de 10 caracteres\n";
                    }
                    else
                    {
                        DateTime fechaNacimiento;
                        if (!DateTime.TryParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
                        {
                            errorExcel.Error += "   La fecha ingresada se encuentra en un formato invalido, por favor utiliza yyyy-MM-dd\n";
                        }
                    }
                }
                if (usuario.CURP != null)
                {
                    if (usuario.CURP.Length > 18)
                    {
                        errorExcel.Error += "   El campo de CURP contiene mas de 18 caracteres\n";
                    }
                    else if (usuario.CURP.Length < 18)
                    {
                        errorExcel.Error += "   El campo de CURP contiene menos de 18 caracteres\n";
                    }
                    else
                    {
                        string validacionCURP = @"^[A-Z]{4}\d{6}[HM]{1}[A-Z]{5}[0-9]{2}$";
                        if (!Regex.IsMatch(usuario.CURP, validacionCURP))
                        {
                            errorExcel.Error += "   El campo de CURP se encuentra en un formato invalido\n";
                        }
                    }
                }
                if (usuario.Rol.IdRol != null)
                {
                    if (usuario.Rol.IdRol == 0)
                    {
                        errorExcel.Error += "   El campo de IdRol contiene caracteres no validos\n";
                    }
                    else if (usuario.Rol.IdRol < 1 || usuario.Rol.IdRol > 3)
                    {
                        errorExcel.Error += "   El campo de IdRol contiene un valor no valido (debe ser entre 1-3)\n";
                    }
                    
                }
                if (usuario.Direccion.Calle == "")
                {
                    errorExcel.Error += "   El campo de calle se encuentra vacio\n";
                }
                if (usuario.Direccion.Calle.Length > 50)
                {
                    errorExcel.Error += "   El campo de calle excede el limite de 50 caracteres\n";
                }
                if (usuario.Direccion.NumeroInterior == "")
                {
                    errorExcel.Error += "   El campo de Numero Interior se encuentra vacio\n";
                }
                if (usuario.Direccion.NumeroInterior.Length > 20)
                {
                    errorExcel.Error += "   El campo de Numero Interior excede el limite de 20 caracteres\n";
                }
                if (usuario.Direccion.NumeroExterior == "")
                {
                    errorExcel.Error += "   El campo de Numero Exterior se encuentra vacio\n";
                }
                if (usuario.Direccion.NumeroExterior.Length > 20)
                {
                    errorExcel.Error += "   El campo de Numero Exterior excede el limite de 20 caracteres\n";
                }
                if (usuario.Direccion.Colonia.IdColonia != null)
                {
                    if (usuario.Direccion.Colonia.IdColonia == 0)
                    {
                        errorExcel.Error += "   El campo de IdColonia contiene caracteres no validos\n";
                    }
                    else if (usuario.Direccion.Colonia.IdColonia < 1 || usuario.Direccion.Colonia.IdColonia > 150)
                    {
                        errorExcel.Error += "   El campo de IdColonia contiene un valor no valido (debe ser entre 1-150)\n";
                    }
                }
                if (errorExcel.Error != null )
                {
                    result.Objects.Add(errorExcel);
                }
                NumeroRegistro++;
            }
            return result;
        }
    }

}
