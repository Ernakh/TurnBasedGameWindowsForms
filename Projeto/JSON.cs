using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Projeto
{
    public partial class JSON : Form
    {
        public JSON()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<User> usuarios = new List<User>();

            string filePath = Path.Combine(Application.CommonAppDataPath, "usuarios.json");

            if (!Directory.Exists(Application.CommonAppDataPath))
            {
                Directory.CreateDirectory(Application.CommonAppDataPath);
            }

            if (File.Exists(filePath))
            {
                usuarios = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));

                foreach (User item in usuarios)
                {
                    if (item.login == textBox1.Text)
                    {
                        MessageBox.Show("Usuário já cadastrado! Com a senha " + item.senha);
                        return;
                    }
                }

                User user = new User();
                user.login = textBox1.Text;
                user.senha = textBox2.Text;

                usuarios.Add(user);

                gravarArquivo(usuarios, filePath);
            }
            else
            {
                User user = new User();
                user.login = textBox1.Text;
                user.senha = textBox2.Text;

                usuarios.Add(user);

                gravarArquivo(usuarios, filePath);
            }
        }

        private bool gravarArquivo(List<User> lista, string diretorio)
        {
            try
            {
                File.WriteAllText(diretorio, JsonConvert.SerializeObject(lista));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<User> usuarios = new List<User>();

            string filePath = Path.Combine(Application.CommonAppDataPath, "usuarios.json");

            if (!Directory.Exists(Application.CommonAppDataPath))
            {
                Directory.CreateDirectory(Application.CommonAppDataPath);
            }

            if (File.Exists(filePath))
            {
                usuarios = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));

                foreach (User item in usuarios)
                {
                    if (item.login == textBox1.Text)
                    {
                        if (item.senha == textBox2.Text)
                        {
                            MessageBox.Show("Seja bem-vindo!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Senha não confere! Tente novamente!");
                            return;
                        }
                    }
                }

                MessageBox.Show("Usuário não encontrado!");
                return;
            }
        }
    }
}
