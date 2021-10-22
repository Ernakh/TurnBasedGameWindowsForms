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
    public partial class Aula01_inloco : Form
    {
        List<int> lista = new List<int>();
        List<Personagem> listaPersonagem = new List<Personagem>();

        public Aula01_inloco()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Teste te = new Teste();
                //te.erroForcado();

                lista.Add(int.Parse(textBox1.Text));

                MessageBox.Show("Cadastrado com Sucesso!");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Não pode dividir por 0!");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Letra não vira numero!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não cadastrado! Erro: " + ex.Message);
            }
            finally
            {
                //MessageBox.Show("Finally!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (int item in lista)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Personagem pers = new Personagem();
            pers.nome = txbNome.Text;
            pers.vida = Convert.ToInt32(txbVida.Text);
            pers.forca = Convert.ToInt32(txbForca.Text);
            pers.stamina= Convert.ToInt32(txbStamina.Text);

            listaPersonagem.Add(pers);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Existem " + listaPersonagem.Count + " personagens!");
        }
    }
}
