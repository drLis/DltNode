using System;
using System.Security.Cryptography;


namespace DltNode.Hash
{
	public class PureHash
	{
		public byte[] computeHash(byte[] input)
		{
			var hashing = SHA256.Create();

			return hashing.ComputeHash(input);
		}
	}
}
