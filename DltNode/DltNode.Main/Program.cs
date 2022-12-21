using System;
using System.Collections;
using System.Text;
using DltNode.Blockchain;
namespace DltNode.Main
{
	class Program
	{
		static void Main(string[] args)
		{
			Transaction tx = new Transaction("Product X has moved from A to B");
			Console.WriteLine(Encoding.Default.GetString(tx.GetHash()));
		}
	}
}
