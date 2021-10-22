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
    public partial class Jogo1 : Form
    {
        Dictionary<string, Item> itens = new Dictionary<string, Item>();

        string[] nomeItems = { "Faca", "Facão", "Espada", "Cajado", "Chu-ko-Nu", "Arco Curvado", "Arco Longo", "Mangual", "Foice", "Harberd", "Lança", "Machado", "Martelo", "Tridente", "Chicote" };

        public Jogo1()
        {
            InitializeComponent();

            lblHP1.Text = "100";
            lblHP2.Text = "100";

            Random rd = new Random();

            for (int i = 0; i < 6; i++)
            {
                Item item = new Item();
                item.nome = nomeItems[rd.Next(0, nomeItems.Length - 1)];
                item.dano = rd.Next(0, 100);
                item.hits = 1;
                item.regeneracao = 0;

                if (item.dano > 70)
                    item.regeneracao = rd.Next(-20, -5);

                if (item.dano < 20)
                {
                    item.regeneracao = rd.Next(5, 20);
                    item.hits = rd.Next(2, 3);
                }

                item.id = i;

                if (i < 3)
                {
                    itens.Add("1-" + item.id, item);
                    listBox1.Items.Add(item.nome);
                }
                else
                {
                    itens.Add("2-" + item.id, item);
                    listBox2.Items.Add(item.nome);
                }
            }

            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;

            if (!itens["1-" + (listBox1.SelectedIndex)].usar)
            {
                MessageBox.Show("O Item não pode mais ser utilizado!");
                return;
            }

            lblHP2.Text = (int.Parse(lblHP2.Text) - 
                (itens["1-" + listBox1.SelectedIndex].dano 
                * itens["1-" + listBox1.SelectedIndex].hits)).ToString();
            lblHP1.Text = (int.Parse(lblHP1.Text) + 
                (itens["1-" + listBox1.SelectedIndex].regeneracao 
                * itens["1-" + listBox1.SelectedIndex].hits)).ToString();

            itens["1-" + (listBox1.SelectedIndex)].usar = false;

            if (int.Parse(lblHP2.Text) <= 0)
            {
                MessageBox.Show("Player 1 Venceu!");
                Application.Exit();
            }

            lblLog.Text = "Player 1 atacou! Vez do Player 2!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;

            if (!itens["2-" + (listBox2.SelectedIndex + 3)].usar)
            {
                MessageBox.Show("O Item não pode mais ser utilizado!");
                return;
            }

            lblHP1.Text = (int.Parse(lblHP1.Text) - (itens["2-" + (listBox2.SelectedIndex + 3)].dano * itens["2-" + (listBox2.SelectedIndex + 3)].hits)).ToString();
            lblHP2.Text = (int.Parse(lblHP2.Text) + (itens["2-" + (listBox2.SelectedIndex + 3)].regeneracao * itens["2-" + (listBox2.SelectedIndex + 3)].hits)).ToString();

            itens["2-" + (listBox2.SelectedIndex + 3)].usar = false;

            if (int.Parse(lblHP1.Text) <= 0)
            {
                MessageBox.Show("Player 2 Venceu!");
                Application.Exit();
            }

            lblLog.Text = "Player 2 atacou! Vez do Player 1!";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDano1.Text = itens["1-" + listBox1.SelectedIndex].dano.ToString();
            lblHits1.Text = itens["1-" + listBox1.SelectedIndex].hits.ToString();
            lblRegen1.Text = itens["1-" + listBox1.SelectedIndex].regeneracao.ToString();
            lblUsar1.Text = itens["1-" + listBox1.SelectedIndex].usar.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDano2.Text = itens["2-" + (listBox2.SelectedIndex + 3)].dano.ToString();
            lblHits2.Text = itens["2-" + (listBox2.SelectedIndex + 3)].hits.ToString();
            lblRegen2.Text = itens["2-" + (listBox2.SelectedIndex + 3)].regeneracao.ToString();
            lblUsar2.Text = itens["2-" + (listBox2.SelectedIndex + 3)].usar.ToString();
        }
    }
}
