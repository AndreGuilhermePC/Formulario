using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public bool cadastrarFuncionario()
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

        public MySqlDataReader localizarFuncionario()
        {
            try
            {
                MySqlConnection conexaoBancoMysql = new MySqlConnection(ConexaoBanco.conexaoBanco);
                conexaoBancoMysql.Open();

                string select = $"select id, nome, email, cpf, endereco from funcionarios where cpf = '{Cpf}';";

                MySqlCommand comandoMysql = conexaoBancoMysql.CreateCommand();
                comandoMysql.CommandText = select;

                MySqlDataReader reader = comandoMysql.ExecuteReader();
                return reader;
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro no banco de dados - método localizarFuncionario: " + e.Message);
                return null;
            }
        }

        public bool atualizarFuncionario()
        {
            try
            {
                MySqlConnection conexaoMysql = new MySqlConnection(ConexaoBanco.conexaoBanco);
                conexaoMysql.Open();

                string update = $"update Funcionarios set email='{Email}', endereco='{endereco}' where id='{Id}'";

                MySqlCommand comandoSQL = conexaoMysql.CreateCommand();
                comandoSQL.CommandText = update;

                comandoSQL.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método atualizarFuncionario: " + ex.Message);
                return false;
            }
        }

    }
}
