using System;
using System.Text;
using DltNode.Hash;
using System.Security.Cryptography;


namespace DltNode.Blockchain
{
	public class Transaction
	{
		public readonly String info;

		public Byte[] signature;

		public Byte[] from; // public key of sender

		public Transaction(String info, Byte[] signature = null)
		{
			this.info = info;
			if (!(signature is null))
			{
				this.signature = signature;
			}
		}

		public void Sign(RSAParameters parameters)
		{
			var hash = this.GetHash();
			using (RSA rsa = RSA.Create())
			{
				rsa.ImportParameters(parameters);
				RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
				rsaFormatter.SetHashAlgorithm(nameof(SHA256));

				signature = rsaFormatter.CreateSignature(hash);
			}
		}

		public Boolean VerifySignature(Byte[] punlicKey)
		{

			return false;
		}

		public Byte[] GetHash() => PureHash.computeHash(Encoding.ASCII.GetBytes(info));
	}
}
