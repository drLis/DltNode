using System;
using System.Text;
using DltNode.Blockchain;

namespace DltNode.Main
{
	class Program
	{
		static void Main(string[] args)
		{
			Transaction tx = new Transaction("Product X has moves from A to B");
			Console.WriteLine(tx.info);
			//Console.WriteLine(tx.GetHash()[0]);
			//String result = Convert.ToString(tx.GetHash());
			Console.WriteLine(Encoding.Default.GetString(tx.GetHash()));
			//uint a = 0;
			//uint b = 5 / a;
		}
	}
}
