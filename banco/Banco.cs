using System;
using System.Threading;

namespace banco
{
    public static class Banco
    {

        static CuentaBancaria cuenta;
        static Random rand;

        static Banco()
        {
            cuenta = new CuentaBancaria("pepe", 0);
               rand = new Random();
        }

        public static CuentaBancaria Cuenta { get => cuenta; set => cuenta = value; }


        public static int GetSaldo()
        {
            return rand.Next(0, 19999);
        }


        public static void AgregarSaldo()
        {
            int cantidadOperaciones = 40;

            do
            {
                cuenta.saldo += GetSaldo();
                cuenta.remitente.Add(Thread.CurrentThread.Name);

                Thread.Sleep(1000);
                cantidadOperaciones--;

            } while (cantidadOperaciones != 0);

        }

    }
}
