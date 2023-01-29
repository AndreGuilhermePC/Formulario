using MySql.Data.MySqlClient;
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

                    if (cadastroF.cadastrarFuncionario())
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

        private void butPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionario = new CadastroFuncionarios();
                    cadFuncionario.Cpf = txtCpf.Text;

                    MySqlDataReader reader = cadFuncionario.localizarFuncionario();

                    if(reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            lblid.Text = reader["id"].ToString();
                            txtNome.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Funcionario não encontrado!!");
                            txtNome.Clear();
                            txtEmail.Clear();
                            txtCpf.Clear();
                            txtEndereco.Clear();
                            txtCpf.Focus();
                            lblid.Text = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Funcionario não encontrado!!");
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        txtCpf.Focus();
                        lblid.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CPF corretamente!");
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    txtCpf.Focus();
                    lblid.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ao encontrar o funcionario: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtCpf.Clear();
            txtEndereco.Clear();
            lblid.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtCpf.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(lblid.Text);
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;
                    
                    if (cadFuncionarios.atualizarFuncionario())
                    {
                        MessageBox.Show("Os dados do funcionário foram atualizados com sucesso!!");
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        lblid.Text = "";
                        txtCpf.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar as informações do Funconário!!!");
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtEndereco.Clear();
                        lblid.Text = "";
                        txtCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado");
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtEndereco.Clear();
                    lblid.Text = "";
                    txtCpf.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados do funcionário: " + ex.Message);
                txtNome.Clear();
                txtEmail.Clear();
                txtCpf.Clear();
                txtEndereco.Clear();
                lblid.Text = "";
                txtCpf.Focus();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionario = new CadastroFuncionarios();
                    cadFuncionario.Id = int.Parse(lblid.Text);

                    if (cadFuncionario.deletarFuncionario())
                    {
                        MessageBox.Show($" O funcionário foi excluído com sucesso!!!!!!!!!");
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtNome.Clear();
                        lblid.Text = "";
                        txtCpf.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possível excluir o funcionário");
                        txtCpf.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                        txtNome.Clear();
                        lblid.Text = "";
                        txtCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show($"Favor informar qual o funcionario deseja excluir");
                    txtCpf.Clear();
                    txtEmail.Clear();
                    txtEndereco.Clear();
                    txtNome.Clear();
                    lblid.Text = "";
                    txtCpf.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao excluir funcionário " + ex.Message);
            }
        }
    }
}