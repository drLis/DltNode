using System;
using DltNode.Blockchain;
using System.Text;

namespace DltNode.Main
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine();
			Console.WriteLine(1);
			Transaction tx = new Transaction("Product X has moved from A to B");
			Console.WriteLine(tx.info);
			Console.WriteLine(Encoding.Default.GetString(tx.GetHash()));
		}
	}
}
