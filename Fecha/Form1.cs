using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fecha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void btmAceptar_Click(object sender, EventArgs e)
        {
            //Limpieza de error provider

            epvValidar.Clear();

            //Validacion de llenado de campos

            if (Validar())
            {

            }
            else
            {

                //creacion de variables y dandole un valor

                string mescrito = "";
                int dia = Convert.ToInt32(txtDia.Text);
                int mes = Convert.ToInt32(txtMes.Text);
                int año = Convert.ToInt32(txtAño.Text);


                if (mes > 12 || mes < 1)
                {
                    MessageBox.Show("Mes no Valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Se revisan los meses para agregar un dia, un mes o un año

                    if (dia == 31 && (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12))
                    {
                        if ((dia == 31) && (mes == 12))
                        {
                            año = año + 1;
                            mes = 0;

                        }

                        dia = 1;
                        mes = mes + 1;

                    }
                    else if (dia == 30 && (mes == 4 || mes == 6 || mes == 9 || mes == 11))
                    {
                        dia = 1;
                        mes = mes + 1;
                    }
                    else if (dia == 28 && mes == 3)
                    {
                        dia = 1;
                        mes = mes + 1;
                    }
                    else
                    {
                        dia = dia + 1;
                    }

                    //Se agarra el valor de mes y se lo pasa a un string

                    if (mes == 1)
                    {
                        mescrito = "Enero";
                    }
                    else if (mes == 2)
                    {
                        mescrito = "Febrero";
                    }
                    else if (mes == 3)
                    {
                        mescrito = "Marzo";
                    }
                    else if (mes == 4)
                    {
                        mescrito = "Abril";
                    }
                    else if (mes == 5)
                    {
                        mescrito = "Mayo";
                    }
                    else if (mes == 6)
                    {
                        mescrito = "Junio";
                    }
                    else if (mes == 7)
                    {
                        mescrito = "Julio";
                    }
                    else if (mes == 8)
                    {
                        mescrito = "Agosto";
                    }
                    else if (mes == 9)
                    {
                        mescrito = "Septiembre";
                    }
                    else if (mes == 10)
                    {
                        mescrito = "Octubre";
                    }
                    else if (mes == 11)
                    {
                        mescrito = "Noviembre";
                    }
                    else if (mes == 12)
                    {
                        mescrito = "Diciembre";
                    }

                    txtDia.Text = "";
                    txtAño.Text = "";
                    txtMes.Text = "";

                    lblFecha.Text = Convert.ToString(dia) + " de " + mescrito + " de " + Convert.ToString(año);
                }


            }

        }

        //Validacion para que solo se puedan poner numeros en los text box

        private void txtDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private bool Validar()
        {
            bool validar = false;
            if (txtAño.Text == "")
            {
                epvValidar.SetError(txtAño, "Llenar campo");
                validar = true;
            }
            if (txtMes.Text == "")
            {
                epvValidar.SetError(txtMes, "Llenar campo");
                validar = true;
            }
            if (txtDia.Text == "")
            {
                epvValidar.SetError(txtDia, "Llenar campo");
                validar = true;

            }
            return validar;
        }
    }
}
