using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios
{
    public class CadastroFuncionarios
    {
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public bool CadastrarFuncionario()
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(ConexaoBanco.conexaoBanco);
                conexao.Open();

                string insert = $" insert into funcionarios (nome,email,cpf,endereco) values ('{Nome}','{Email}','{Cpf}','{Endereco}')";

                MySqlCommand comandosSql = conexao.CreateCommand();
                comandosSql.CommandText = insert;

                comandosSql.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro na conexão ao banco de dados " + ex.Message);
                return false;
            }
        }
    }
}
