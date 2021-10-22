using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Aula02_inloco : Form
    {
        Dictionary<int, string> dicionario = new Dictionary<int, string>();

        public Aula02_inloco()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dicionario.Add(int.Parse(textBox1.Text), textBox2.Text);
                MessageBox.Show("Gravado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dicionario.Remove(Convert.ToInt32(textBox1.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (int item in dicionario.Keys)
            {
                if (item == int.Parse(textBox3.Text))
                {
                    listBox1.Items.Add(dicionario[item]);
                    //break;
                }
                else
                {
                    MessageBox.Show("A chave " + item + " possui o " +
                        "valor " + dicionario[item]);
                }
            }
        }
    }
}
