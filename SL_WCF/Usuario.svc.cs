﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public SL_WCF.Result UsuarioAdd (ML.Usuario usuario)
        {
             ML.Result result = BL.Usuario.AddEFSP(usuario);
             return new SL_WCF.Result
             {
                 Correct = result.Correct,
                 ErrorMessage = result.ErrorMessage,
                 Ex = result.Ex,
                 Objects = result.Objects,
                 Object = result.Object
             };
        }
        public SL_WCF.Result UsuarioGetAll (ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEFSP(usuario);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Objects = result.Objects,
                Object = result.Object
            };
        }

        public SL_WCF.Result UsuarioUpdate(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEFSP(usuario);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Objects = result.Objects,
                Object = result.Object
            };
        }

        public SL_WCF.Result UsuarioDelete(int Id)
        {
            ML.Result result = BL.Usuario.DeleteEFSP(Id);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Objects = result.Objects,
                Object = result.Object
            };
        }
    }
}
