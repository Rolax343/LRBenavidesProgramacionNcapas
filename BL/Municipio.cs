using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetAllEFSP(int IdEstado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    var tableMunicipio = context.MunicipioGetAll(IdEstado).ToList();

                    if (tableMunicipio.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in tableMunicipio)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.Estado = new ML.Estado();
                            municipio.IdMunicipio = item.IdMunicipio;
                            municipio.Nombre = item.Nombre;
                            municipio.Estado.IdEstado = item.IdEstado.Value;
                            result.Objects.Add(municipio);
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
