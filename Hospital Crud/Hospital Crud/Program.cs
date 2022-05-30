using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            DAO con = new DAO();
            Paciente pac = new Paciente();
            pac.cad_pac();
            con.cadastro(pac);
            Console.ReadKey();
            con.exibir(pac
            );
        }
    }
}
