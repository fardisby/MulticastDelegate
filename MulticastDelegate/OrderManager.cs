using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
    public class OrderManager
    {

        public delegate void OrderCompleted(); 

        public void NotifyUser()
        {
            Console.WriteLine("User has been notified about the order.");
        }

        public void UpdateInventory()
        {
            Console.WriteLine("Inventory has been updated.");
        }

        public void GenerateInvoice()
        {
            Console.WriteLine("Invoice has been generated.");
        }


        public void StartOrderProcess()
        {
            OrderCompleted orderChain = NotifyUser;

            orderChain += UpdateInventory;
            orderChain += GenerateInvoice;

            Console.WriteLine("Processing Order ...");
            orderChain.Invoke();

            Console.WriteLine("\nRemoving UpdateInventory from the chain...");

            orderChain -= UpdateInventory;

            orderChain.Invoke();
        }

    }
}
