using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DltNode.Hash;
using DltNode.Consensus;

namespace DltNode.Blockchain
{
	public class Block
	{
		public readonly Byte[] blockHash;

		private readonly Byte[] zero;

		public readonly Byte[] previousBlockHash;

		public readonly List<Transaction> transactions;

		public UInt64 nonce = 0;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="transactions"></param>
		/// <param name="previousBlock">Put null in to first block constructor</param>
		public Block(List<Transaction> transactions, Block previousBlock)
		{
			zero = new byte[32];
			this.previousBlockHash = previousBlock?.blockHash ?? zero;
			this.transactions = transactions;

			List<Byte[]> hashes = new List<Byte[]>();
			hashes.Add(previousBlockHash);
			foreach (var tx in transactions)
			{
				hashes.Add(tx.GetHash());
			}

			var preBlockHash = computeMerkleTreeHash(hashes);
			blockHash = PureHash.computeHash(BitConverter.GetBytes(nonce).Concat(preBlockHash).ToArray());
		}

		public void ComputeHashWithTarget(BigInteger target)
		{
			List<Byte[]> hashes = new List<Byte[]>();
			hashes.Add(previousBlockHash);
			foreach (var tx in transactions)
			{
				hashes.Add(tx.GetHash());
			}

			var preBlockHash = computeMerkleTreeHash(hashes);
			nonce = ProofOfWork.SolveHashComputationProblem(target, preBlockHash);
		}

		public Byte[] computeMerkleTreeHash(List<Byte[]> hashes)
		{
			if (hashes.Count == 1)
				return hashes[0];
			else if (hashes.Count == 2)
				return PureHash.computeHash(hashes[0].Concat(hashes[1]).ToArray());
			else
			{
				var mediumIndex = hashes.Count / 2;
				List<Byte[]> firstPart = hashes.GetRange(0, mediumIndex);
				List<Byte[]> secondPart = hashes.GetRange(mediumIndex, hashes.Count - 1);

				var hashOfLeft = computeMerkleTreeHash(firstPart);
				var hashOfRight = computeMerkleTreeHash(secondPart);

				return PureHash.computeHash(hashOfLeft.Concat(hashOfRight).ToArray());
			}
		}
	}
}
