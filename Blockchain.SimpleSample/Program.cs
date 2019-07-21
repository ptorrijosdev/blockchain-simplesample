using System;
using System.Collections.Generic;

namespace Blockchain.SimpleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lets start the blockchain and add some transactions
            Console.WriteLine("Starting the Blockchain...");
            Blockchain<string> transactionsBlockchain = new Blockchain<string>();

            Console.WriteLine("\nAdding transactions:");
            List<string> transactions = new List<string>()
            {
                "Pablo sent 10 bitcoins to Raúl",
                "Daniel sent 150 bitcoins to Raúl",
                "Raúl sent 50 bitcoins to Pablo"
            };

            int transactionIndex = 1;
            foreach(var transaction in transactions)
            {
                Console.WriteLine("  (+) Transaction {0}: \"{1}\"", transactionIndex, transaction);
                transactionsBlockchain.Add(transaction);
                transactionIndex++;
            }

            Console.WriteLine("\nThe transaction hashes are next:");
            transactionIndex = 1;
            foreach (var transaction in transactionsBlockchain.Items)
            {
                Console.WriteLine("  ({0}) Hash \"{1}\"", transactionIndex, transaction.GetHash());
                transactionIndex++;
            }

            // We have everything working, so lets try to hack the system modifying one of the transactions
            Console.WriteLine("\nNow, we change the second transaction to hack the system...");
            Console.WriteLine("  (-) Previous state: \"{0}\"", transactionsBlockchain.Items[1].Content);
            transactionsBlockchain.Items[1].Content = "Daniel sent 150 bitcoins to Pablo";
            Console.WriteLine("  (+) New state:      \"{0}\"", transactionsBlockchain.Items[1].Content);

            // Now, the chain hashes have been changed
            Console.WriteLine("\nThe new transaction hashes are next:");
            Console.ForegroundColor = ConsoleColor.Green;
            transactionIndex = 1;
            foreach (var transaction in transactionsBlockchain.Items)
            {
                Console.WriteLine("  ({0}) Hash \"{1}\"", transactionIndex, transaction.GetHash());
                Console.ForegroundColor = ConsoleColor.Red;
                transactionIndex++;
            }
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
