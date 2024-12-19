using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        //public static void Eleccion() 
        //{
        //    Console.WriteLine("Por favor, elija una opcion(n):\n1- Insertar un registro\n2- Actualizar un registro\n3- Eliminar un registro\n4- Visualizar todos los registros\n5- Visualizar un solo registro");
        //    byte eleccion = Convert.ToByte(Console.ReadLine());

        //    if (eleccion == 1)
        //    {
        //        Addsp();
        //    }
        //    else if (eleccion == 2)
        //    {
        //        Updatesp();
        //    }
        //    else if (eleccion == 3)
        //    {
        //        Deletesp();
        //    }
        //    else if (eleccion == 4)
        //    {
        //        GetAll();
        //    }
        //    else if (eleccion == 5)
        //    {
        //        GetById();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error: Eleccion no valida");
        //    }
        //}
        ////public static void Add()
        ////{
        ////    ML.Usuario usuario = new ML.Usuario();

        ////    Console.WriteLine("¿Cual es tu nombre?");
        ////    usuario.Nombre = Console.ReadLine();

        ////    Console.WriteLine("¿Cual es apellido?");
        ////    usuario.Apellido = Console.ReadLine();

        ////    Console.WriteLine("¿Cual es tu edad?");
        ////    usuario.Edad = Convert.ToByte(Console.ReadLine());

        ////    Console.WriteLine("¿Cual es tu sexo?");
        ////    usuario.Sexo = Convert.ToChar(Console.ReadLine());

        ////    ML.Result result = BL.Usuario.Add(usuario);

        ////    if (result.Correct)
        ////    {
        ////        Console.WriteLine("Se ha insertado tu registro");
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine("No se ha insertado tu registro" + result.ErrorMessage);
        ////    }

        ////}

        //public static void Addsp()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.Rol = new ML.Rol();

        //    Console.WriteLine("¿Cual es tu nombre?");
        //    usuario.Nombre = Console.ReadLine();

        //    Console.WriteLine("¿Cual es apellido paterno?");
        //    usuario.ApellidoPaterno = Console.ReadLine();

        //    Console.WriteLine("¿Cual es apellido materno?");
        //    usuario.ApellidoMaterno = Console.ReadLine();

        //    Console.WriteLine("¿Cual es tu sexo?");
        //    usuario.Sexo = Convert.ToChar(Console.ReadLine());

        //    Console.WriteLine("Escribe tu nombre de usuario");
        //    usuario.UserName = Console.ReadLine();

        //    Console.WriteLine("Escribe tu direccion de correo electronico");
        //    usuario.Email = Console.ReadLine();

        //    Console.WriteLine("Escribe tu contraseña");
        //    usuario.Password = Console.ReadLine();

        //    Console.WriteLine("Escribe tu Telefono fijo");
        //    usuario.Telefono = Console.ReadLine();

        //    Console.WriteLine("Escribe tu Telefono Celular");
        //    usuario.Celular = Console.ReadLine();

        //    Console.WriteLine("¿Cual es tu fecha de nacimiento?");
        //    usuario.FechaNacimiento = Console.ReadLine();

        //    Console.WriteLine("Escribe tu CURP");
        //    usuario.CURP = Console.ReadLine();

        //    Console.WriteLine("Escribe el ID de tu rol");
        //    usuario.Rol.IdRol = Convert.ToByte(Console.ReadLine());

        //    ML.Result result = BL.Usuario.AddEFLinq(usuario);

        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Se ha insertado tu registro");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se ha insertado tu registro" + result.ErrorMessage);
        //    }

        //}

        ////public static void Update()
        ////{
        ////    ML.Usuario usuario = new ML.Usuario();


        ////    Console.WriteLine("¿Cual es el ID del registro que deseas modificar?");
        ////    usuario.Id = Convert.ToByte(Console.ReadLine());

        ////    Console.WriteLine("¿Cual es el nuevo nombre?");
        ////    usuario.Nombre = Console.ReadLine();

        ////    Console.WriteLine("¿Cual es el nuevo sexo?");
        ////    usuario.Sexo = Convert.ToChar(Console.ReadLine());

        ////    ML.Result result = BL.Usuario.Update(usuario);

        ////    if (result.Correct)
        ////    {
        ////        Console.WriteLine("Se ha actualizado tu registro");
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine("No se ha actualizado tu registro" + result.ErrorMessage);
        ////    }

        ////}

        //public static void Updatesp()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    usuario.Rol = new ML.Rol();

        //    Console.WriteLine("Escribe el ID del registro que deseas modificar");
        //    usuario.Id = Convert.ToByte(Console.ReadLine());

        //    Console.WriteLine("¿Cual es el nombre?");
        //    usuario.Nombre = Console.ReadLine();

        //    Console.WriteLine("¿Cual es apellido paterno?");
        //    usuario.ApellidoPaterno = Console.ReadLine();

        //    Console.WriteLine("¿Cual es el apellido materno?");
        //    usuario.ApellidoMaterno = Console.ReadLine();

        //    Console.WriteLine("¿Cual es tu sexo?");
        //    usuario.Sexo = Convert.ToChar(Console.ReadLine());

        //    Console.WriteLine("Escribe tu nuevo nombre de usuario");
        //    usuario.UserName = Console.ReadLine();

        //    Console.WriteLine("Escribe tu nueva direccion de correo electronico");
        //    usuario.Email = Console.ReadLine();

        //    Console.WriteLine("Escribe tu nueva contraseña");
        //    usuario.Password = Console.ReadLine();

        //    Console.WriteLine("Escribe tu nuevo Telefono fijo");
        //    usuario.Telefono = Console.ReadLine();

        //    Console.WriteLine("Escribe tu nuevo Telefono Celular");
        //    usuario.Celular = Console.ReadLine();

        //    Console.WriteLine("¿Cual es tu fecha de nacimiento?");
        //    usuario.FechaNacimiento = Console.ReadLine();

        //    Console.WriteLine("Escribe tu CURP");
        //    usuario.CURP = Console.ReadLine();

        //    Console.WriteLine("Escribe el ID de tu rol");
        //    usuario.Rol.IdRol = Convert.ToByte(Console.ReadLine());

        //    ML.Result result = BL.Usuario.UpdateEFLinq(usuario);

        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Se ha actualizado tu registro");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se ha actualizado tu registro" + result.ErrorMessage);
        //    }

        //}

        ////public static void Delete()
        ////{
        ////    ML.Usuario usuario = new ML.Usuario();


        ////    Console.WriteLine("¿Cual es el ID del registro que deseas ELIMINAR?");
        ////    usuario.Id = Convert.ToByte(Console.ReadLine());

        ////    Console.WriteLine("¿Estas seguro que deseas eliminar el registro con ID = " + usuario.Id + "?\n1- Si\n2- No");
        ////    byte confirmacion = Convert.ToByte(Console.ReadLine());

        ////    if (confirmacion == 1)
        ////    {
        ////        ML.Result result = BL.Usuario.Delete(usuario);

        ////        if (result.Correct)
        ////        {
        ////            Console.WriteLine("Se ha eliminado tu registro");
        ////        }
        ////        else
        ////        {
        ////            Console.WriteLine("Tu registro no ha sido eliminado" + result.ErrorMessage);
        ////        }

        ////    }
        ////    else if (confirmacion == 2)
        ////    {
        ////        Eleccion();
        ////    }
        ////}

        //public static void Deletesp()
        //{
        //    Console.WriteLine("¿Cual es el ID del registro que deseas ELIMINAR?");
        //    byte ID = Convert.ToByte(Console.ReadLine());

        //    Console.WriteLine("¿Estas seguro que deseas eliminar el registro con ID = " + ID + "?\n1- Si\n2- No");
        //    byte confirmacion = Convert.ToByte(Console.ReadLine());

        //    if (confirmacion == 1)
        //    {
        //        ML.Result result = BL.Usuario.DeleteEFLinq(ID);

        //        if (result.Correct)
        //        {
        //            Console.WriteLine("Se ha eliminado tu registro");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Tu registro no ha sido eliminado debido a un error" + result.ErrorMessage);
        //        }

        //    }
        //    else if (confirmacion == 2)
        //    {
        //        Console.WriteLine("Tu registro no ha sido eliminado");
        //    }
        //}
        //public static void GetAll()
        //{
        //    ML.Result result = BL.Usuario.GetAllEFLinq();

        //    if (result.Correct)
        //    {
        //        foreach (ML.Usuario usuario in result.Objects)
        //        {
        //            Console.WriteLine("IdUsuario: " + usuario.Id);
        //            Console.WriteLine("Nombre: " + usuario.Nombre);
        //            Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
        //            Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
        //            Console.WriteLine("Sexo: " + usuario.Sexo);
        //            Console.WriteLine("UserName: " + usuario.UserName);
        //            Console.WriteLine("Email: " + usuario.Email);
        //            Console.WriteLine("Password: " + usuario.Password);
        //            Console.WriteLine("Telefono: " + usuario.Telefono);
        //            Console.WriteLine("Celular: " + usuario.Celular);
        //            Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);
        //            Console.WriteLine("CURP: " + usuario.CURP);
        //            Console.WriteLine("IdRol: " + usuario.Rol.IdRol);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se encontraron registros en la tabla" + result.ErrorMessage);
        //    }
        //}

        //public static void GetById()
        //{
        //    Console.WriteLine("¿Cual es el ID del registro que deseas visualizar?");
        //    int ID = Convert.ToInt32(Console.ReadLine());

        //    ML.Result result = BL.Usuario.GetByIdEFLinq(ID);

        //    if (result.Correct)
        //    {
        //        ML.Usuario usuario = new ML.Usuario();
        //        usuario = (ML.Usuario)result.Object;
        //        Console.WriteLine("IdUsuario: " + usuario.Id);
        //        Console.WriteLine("Nombre: " + usuario.Nombre);
        //        Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
        //        Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
        //        Console.WriteLine("Sexo: " + usuario.Sexo);
        //        Console.WriteLine("UserName: " + usuario.UserName);
        //        Console.WriteLine("Email: " + usuario.Email);
        //        Console.WriteLine("Password: " + usuario.Password);
        //        Console.WriteLine("Telefono: " + usuario.Telefono);
        //        Console.WriteLine("Celular: " + usuario.Celular);
        //        Console.WriteLine("Fecha de nacimiento: " + usuario.FechaNacimiento);
        //        Console.WriteLine("CURP: " + usuario.CURP);
        //        Console.WriteLine("IdRol: " + usuario.Rol.IdRol);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se ha encontrado tu registro" + result.ErrorMessage);
        //    }
        //}

        public static void CargaMasivatxt()
        {
            string path = @"C:\Users\digis\Documents\Luis_Rolando_Benavides_Valadez\LRBenavidesProgramacionNcapas\PL\files\UsuarioInsertMasivo.txt";

            StreamReader reader = new StreamReader(path);
            int RegistroExitoso = 0;
            int NumeroRegistro = 0;
            string linea = "";
            linea = reader.ReadLine();
            while ((linea = reader.ReadLine()) != null)
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
                    usuario.FechaNacimiento = Fecha.ToString("dd-MM-yyyy");
                }
                usuario.CURP = arreglo[10];
                usuario.Rol.IdRol = Convert.ToInt32(arreglo[11]);
                usuario.Direccion.Calle = arreglo[12];
                usuario.Direccion.NumeroInterior = arreglo[13];
                usuario.Direccion.NumeroExterior = arreglo[14];
                usuario.Direccion.Colonia.IdColonia = Convert.ToInt32(arreglo[15]);
                ML.Result result = BL.Usuario.AddEFSP(usuario);

                if (result.Correct)
                {
                    RegistroExitoso++;
                    NumeroRegistro++;
                }
                else
                {
                    NumeroRegistro++;
                    Console.WriteLine("No se ha podido insertar el registro numero "+ NumeroRegistro + " :" + result.ErrorMessage);
                }

            }
            Console.WriteLine(RegistroExitoso + " registros exitosos");
        }
    }
}
