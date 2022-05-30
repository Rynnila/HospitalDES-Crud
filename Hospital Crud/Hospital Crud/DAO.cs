using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hospital_Crud
{

    class DAO
    {
        MySqlConnection conexao;
        MySqlCommand cmd;
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;database=hospital;uid=root;password=root");
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão Aberta");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("erro ao acessar o banco de dados");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public void inserir()
        {

        }
        public void cadastro(Paciente p)
        {
            String sql = "INSERT INTO paciente values(null,@cpf,@nome,@endereco,@telefone,@email,@idade,@preferencial)";
            cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@cpf",p.cpf);
            cmd.Parameters.AddWithValue("@nome", p.nome);
            cmd.Parameters.AddWithValue("@endereco", p.endereco);
            cmd.Parameters.AddWithValue("@telefone",p.telefone);
            cmd.Parameters.AddWithValue("@email",p.email);
            cmd.Parameters.AddWithValue("@idade", p.idade);
            cmd.Parameters.AddWithValue("@preferencial", p.preferencial);

            cmd.ExecuteNonQuery();
            
        }
        public void exibir(Paciente p)
        {
            String sql = "SELECT * FROM paciente order by preferencial desc";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("Código pac:{0} \n CPF: {1} \n Nome:{2} \n Endereço:{3} \n Telefone:{4} \n Email:{5} \n Idade:{6} \n Preferencial:{7} \n", rdr["cod_paciente"], rdr["cpf"], rdr["nome"], rdr["endereco"], rdr["telefone"], rdr["email"], rdr["idade"], rdr["preferencial"]);
                Console.ReadKey();
            }
        }
    }
}
