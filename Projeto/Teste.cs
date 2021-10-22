using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Teste
    {   
        public void erroForcado()
        {
            try
            {
                int x = 0;
                int y = 3;
                int z = y / x;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
