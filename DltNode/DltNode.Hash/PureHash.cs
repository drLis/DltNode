using System;
using System.Security.Cryptography;


namespace DltNode.Hash
{
	public static class PureHash
	{
		public static byte[] computeHash(byte[] input)
		{
			var hashing = SHA256.Create();

			return hashing.ComputeHash(input);
		}
	}
}
