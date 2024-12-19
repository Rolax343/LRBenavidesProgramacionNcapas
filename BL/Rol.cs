using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    var tableRol = (from rollinq in context.Rols
                                    select new
                                    {
                                        Id = rollinq.IdRol,
                                        nombre = rollinq.Nombre
                                    }).ToList();

                    if (tableRol.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in tableRol)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = item.Id;
                            rol.NombreRol = item.nombre;
                            result.Objects.Add(rol);
                        }
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
