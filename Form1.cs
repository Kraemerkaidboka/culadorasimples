using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace culadorasimples
{
    public partial class Form1 : Form
    {
        int bundabranca;
        
        public Form1()
        {
            InitializeComponent();
        }

        enum operações
        { soma,
        subtrai,
        multiplica,
        divide,
        nenhuma
        }

        static operações ultimaoperação = operações.nenhuma;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            TextBoxDisplay.Text = TextBoxDisplay.Text + "=";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            TextBoxDisplay.Clear();
            ultimaoperação = operações.nenhuma;
        }

        private void TextBoxDisplay_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonSubtrai_Click(object sender, EventArgs e)
        {
            if (ultimaoperação == operações.nenhuma)
            {
                ultimaoperação = operações.subtrai;
            }
            else
            {
                fazercalculo(ultimaoperação);
            }
            TextBoxDisplay.Text += (sender as Button).Text;
            bundabranca = 0;
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            if (ultimaoperação == operações.nenhuma)
            {
                ultimaoperação = operações.soma;
            }
            else
            {
                fazercalculo(ultimaoperação);
            }
            TextBoxDisplay.Text += (sender as Button).Text;
            bundabranca = 0;
        }

        private void fazercalculo(operações ultimaoperação)
        {
           
            List<double> listadenumeros = new List<double>();
            
            
            switch (ultimaoperação)
            {
                case operações.soma:
                    listadenumeros = TextBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    TextBoxDisplay.Text = (listadenumeros[0] + listadenumeros[1]).ToString();
                    break;
                case operações.subtrai:
                    listadenumeros = TextBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    TextBoxDisplay.Text = (listadenumeros[0] + listadenumeros[1]).ToString();
                    break;
                case operações.multiplica:
                    listadenumeros = TextBoxDisplay.Text.Split('*').Select(double.Parse).ToList();
                    TextBoxDisplay.Text = (listadenumeros[0] + listadenumeros[1]).ToString();
                    break;
                case operações.divide:
                    try
                    {
                        listadenumeros = TextBoxDisplay.Text.Split('/').Select(double.Parse).ToList();
                        TextBoxDisplay.Text = (listadenumeros[0] + listadenumeros[1]).ToString();
                    }
                    catch(DivideByZeroException)
                    {
                        TextBoxDisplay.Text = "DIVIDE POR ZERO?";
                    }
                    break;
                case operações.nenhuma:

                    break;
                default:
                    break;
            }


        }

        private void ButtonMultiplica_Click(object sender, EventArgs e)
        {
            if (ultimaoperação == operações.nenhuma)
            {
                ultimaoperação = operações.multiplica;
            }
            else
            {
                fazercalculo(ultimaoperação);
            }
            TextBoxDisplay.Text += (sender as Button).Text;
            bundabranca = 0;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (ultimaoperação == operações.nenhuma)
            {
                ultimaoperação = operações.divide;
            }
            else
            {
                fazercalculo(ultimaoperação);
            }
            TextBoxDisplay.Text += (sender as Button).Text;
            bundabranca = 0;
        }

        private void buttonvirgula_Click(object sender, EventArgs e)
        {
            
            if (bundabranca > 0)
                    {
                return;
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + ",";
                bundabranca = 1;
            }
        }

        private void buttonnum_Click(object sender, EventArgs e)
        {
            // TextBoxDisplay.Text = TextBoxDisplay.Text + "0";
            TextBoxDisplay.Text += (sender as Button).Text;
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (TextBoxDisplay.Text.Length > 0 )

                TextBoxDisplay.Text = TextBoxDisplay.Text.Remove(TextBoxDisplay.Text.Length - 1, 1);
            if (TextBoxDisplay.Text.EndsWith(","))
            {
                bundabranca = 0;
            }
            else
            {
                return;
            }
        }

        private void button10
           _Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxDisplay.Text);
        }

        
    }
}
