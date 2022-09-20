using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Interface
{
    public interface IUsuarioManejo
    {
        void GuardarUsuario(int Anousuario);
        int GetEdad();
    }
}
