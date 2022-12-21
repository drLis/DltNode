using System;
using DltNode.Hash;
using System.Text;
namespace DltNode.Blockchain
{
	public class Transaction
	{
		public readonly String info;
		public Transaction(string info)
        {
			this.info = info;
        }

		public Byte[] GetHash() => PureHash.computeHash(Encoding.UTF8.GetBytes(info));
	}
}
