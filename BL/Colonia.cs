using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetAllEFSP(int IdMunicipio)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LRBenavidesProgramacionNCapasEntities context = new DL_EF.LRBenavidesProgramacionNCapasEntities())
                {
                    var tableColonia = context.ColoniaGetAll(IdMunicipio).ToList();

                    if (tableColonia.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in tableColonia)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.Municipio = new ML.Municipio();
                            colonia.IdColonia = item.IdColonia;
                            colonia.Nombre = item.Nombre;
                            colonia.CodigoPostal = item.CodigoPostal;
                            colonia.Municipio.IdMunicipio = item.IdMunicipio.Value;
                            result.Objects.Add(colonia);
                        }
                        result.Correct = true;
                    } else
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
