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
using System.Xml;

namespace Projeto
{
    public partial class XML : Form
    {
        public XML()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();

            for (int j = 0; j < 5; j++)
            {
                List<string> lista = new List<string>();

                Random rd = new Random();
                int max = rd.Next(1, 10);

                for (int i = 0; i < max; i++)
                {
                    lista.Add(rd.Next(0, 100).ToString());
                }

                dic.Add(j, lista);
            }

            XmlDocument doc = new XmlDocument();
            XmlElement raiz = doc.CreateElement("NumeroRaiz");
            doc.AppendChild(raiz);

            XmlProcessingInstruction pi = doc.CreateProcessingInstruction("xml", "version=\"1.0\"");
            doc.InsertBefore(pi, raiz);

            foreach (int user in dic.Keys)
            {
                XmlElement filho = doc.CreateElement("numero");
                filho.SetAttribute("id", user.ToString());
                raiz.AppendChild(filho);

                int i = 0;

                foreach (string valor in dic[user])
                {
                    XmlElement filho1 = doc.CreateElement("itensLista");
                    filho1.InnerText = valor;
                    filho.AppendChild(filho1);

                    i++;
                }
            }

            string filePath = Path.Combine(Application.CommonAppDataPath, "usuarios.xml");

            doc.Save(filePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
