using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banco
{
    public partial class Form1 : Form
    {
        List<Thread> listaOperaciones;
        Thread hiloUno;
        Thread hiloDos;

        public Form1()
        {
            hiloUno = new Thread(this.Comenzar);
            hiloDos = new Thread(this.Actualizar);
            listaOperaciones = new List<Thread>();
            InitializeComponent(); // se crea el boton ->  se crea en el H0
            CargarLista();
        }



        




        public void Actualizar()
        {




            while (true)
            {
                if (this.lb_saldo.InvokeRequired) //si lo mangueo
                {
                    this.lb_saldo.BeginInvoke(
                        (MethodInvoker)delegate ()
                    {
                        this.lb_saldo.Text = Banco.Cuenta.saldo.ToString();
                        this.richTextBox1.Text += Banco.Cuenta.ToString();
                    }
                    );
                }
                else // si ya lo tengo
                {
                    this.lb_saldo.Text = Banco.Cuenta.saldo.ToString();
                    this.richTextBox1.Text += Banco.Cuenta.ToString();
                }

                Thread.Sleep(5000);
            }

        }
        public void Comenzar() // ESTA ASOCIADO A UN HILO 1 

        // form hilo 0 
        {
            foreach (Thread item in listaOperaciones)
            {
                Thread.Sleep(2000);
                item.Start();
            }


        }

        private void CargarLista()
        {

            Thread miTr = new Thread(Banco.AgregarSaldo);

            miTr.Name = "Thread farolito";

            listaOperaciones.Add(new Thread(Banco.AgregarSaldo));
            listaOperaciones.Add(new Thread(Banco.AgregarSaldo));
            listaOperaciones.Add(new Thread(Banco.AgregarSaldo));
            listaOperaciones.Add(new Thread(Banco.AgregarSaldo));


            for (int i = 0; i < listaOperaciones.Count; i++)
            {
                listaOperaciones[i].Name = string.Concat("Thread numero", i + 1);
            }

            listaOperaciones.Add(miTr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!hiloUno.IsAlive)
            {
                hiloUno.Start(); //inicio los threads que cargan data
                hiloDos.Start(); // inicio el thread que cada 5 seg actualiza info
            }
            else
            {
                hiloUno.Abort();
                hiloDos.Abort();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
