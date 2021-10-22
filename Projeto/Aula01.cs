using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Aula01 : Form
    {
        Dictionary<int, List<string>> dicionario = new Dictionary<int, List<string>>();

        public Aula01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dicionario.ContainsKey(int.Parse(textBox1.Text)))
            {
                dicionario[int.Parse(textBox1.Text)].Add(textBox2.Text);
            }
            else
            {
                dicionario.Add(int.Parse(textBox1.Text),
                    new List<string> { textBox2.Text });
            }















            //bool existe = false;

            //foreach (int item in dicionario.Keys)
            //{
            //    if (item == int.Parse(textBox1.Text))
            //    {
            //        dicionario[item].Add(textBox2.Text);
            //        existe = true;
            //        break;
            //    }
            //}

            //if (!existe)
            //{
            //    dicionario.Add(int.Parse(textBox1.Text), new List<string> { textBox2.Text });
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                dicionario.Remove(int.Parse(textBox1.Text));
            }
            else
            {
                if(dicionario.ContainsKey(int.Parse(textBox1.Text)))
                {
                    dicionario[int.Parse(textBox1.Text)].Remove(textBox2.Text);
                }
            }








            //if (textBox2.Text == "")
            //{
            //    dicionario.Remove(int.Parse(textBox1.Text));
            //}
            //else
            //{
            //    foreach (int item in dicionario.Keys)
            //    {
            //        if (item == int.Parse(textBox1.Text))
            //        {
            //            dicionario[item].Remove(textBox2.Text);
            //            break;
            //        }
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if(dicionario.ContainsKey(int.Parse(textBox1.Text)))
            {
                foreach (string item in dicionario[int.Parse(textBox1.Text)])
                {
                    listBox1.Items.Add(item);
                }
            }









            //foreach (int item in dicionario.Keys)
            //{
            //    if (item == int.Parse(textBox3.Text))
            //    {
            //        foreach (string itemVal in dicionario[item])
            //        {
            //            listBox1.Items.Add(itemVal);
            //        }
            //    }
            //}
        }
    }
}
