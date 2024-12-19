using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result AddEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    DL_EF.Direccion direccionEF = new DL_EF.Direccion();

                    direccionEF.IdDireccion = usuario.Direccion.IdDireccion;
                    direccionEF.Calle = usuario.Direccion.Calle;
                    direccionEF.NumeroInterior = usuario.Direccion.NumeroInterior;
                    direccionEF.NumeroExterior = usuario.Direccion.NumeroExterior;
                    string UserName = usuario.UserName;
                    var ObtenerId = context.UsuarioGetByName(UserName).FirstOrDefault();
                    direccionEF.IdUsuario = ObtenerId.Value;
                    direccionEF.IdColonia = usuario.Direccion.Colonia.IdColonia;

                    context.Direccions.Add(direccionEF);
                    int rowsaffected = context.SaveChanges();

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

    }
}
