using System;
using System.Text;
using DltNode.Hash;

namespace DltNode.Blockchain
{
	public class Transaction
	{
		public readonly String info;

		public Transaction(String info)
		{
			this.info = info;
		}

		public Byte[] GetHash() => PureHash.computeHash(Encoding.ASCII.GetBytes(info));
	}
}
