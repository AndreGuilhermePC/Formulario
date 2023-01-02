using System.Drawing.Text;

namespace Funcionarios
{
    public partial class btnCadastrar : Form
    {
        public btnCadastrar()
        {
            InitializeComponent();
        }

        private void B_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtCpf.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    CadastroFuncionarios cadastroF = new CadastroFuncionarios();
                    cadastroF.Nome = txtNome.Text;
                    cadastroF.Email = txtEmail.Text;
                    cadastroF.Cpf = txtCpf.Text;
                    cadastroF.Endereco = txtEndereco.Text;

                    if (cadastroF.CadastrarFuncionario())
                    {
                        MessageBox.Show($"Funcionario {cadastroF.Nome} foi cadastrado com sucesso!!!!!!");
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel cadastrar o funcionario!");
                    }

                }
                else
                {
                    MessageBox.Show("Favor preencher todos os campos corretamente!");
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtNome.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionario " + ex.Message);
            }
        }
    }
}