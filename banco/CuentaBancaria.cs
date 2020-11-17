using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banco
{
   public class CuentaBancaria
    {
        public string cliente;
        public int saldo;
        public List<string> remitente;

        public CuentaBancaria(string cliente, int saldo)
        {
            this.cliente = cliente;
            this.saldo = saldo;
            remitente = new List<string>();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in remitente)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
