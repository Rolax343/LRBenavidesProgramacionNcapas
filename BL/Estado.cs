using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    var tableEstado = (from estadolinq in context.Estadoes
                                          select new
                                          {
                                              IdEstado = estadolinq.IdEstado,
                                              Nombre = estadolinq.Nombre
                                          }).ToList();

                    if (tableEstado.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in tableEstado)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = item.IdEstado;
                            estado.Nombre = item.Nombre;
                            result.Objects.Add(estado);
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
