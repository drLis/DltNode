﻿using System;
using System.Linq;
using System.Numerics;
using DltNode.Hash;

namespace DltNode.Consensus
{
	public static class ProofOfWork
	{
		static public UInt64 SolveHashComputationProblem(BigInteger target, Byte[] preBlockHash)
		{
			UInt64 nonce = 0;

			var newHash = PureHash.computeHash(BitConverter.GetBytes(nonce).Concat(preBlockHash).ToArray());
			do
			{
				nonce++;
				newHash = PureHash.computeHash(BitConverter.GetBytes(nonce).Concat(preBlockHash).ToArray());
			} while (BigInteger.Abs(new BigInteger(newHash)) >= target);

			return nonce;
		}
	}
}
