using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DltNode.Hash;

namespace DltNode.Blockchain
{
    class Block
    {
        public readonly Byte[] blockHash;

        public readonly Byte[] previousBlockHash;

        public readonly List<Transaction> transactions;

        public readonly Byte[] zero;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactions"></param>
        /// <param name="previousBlock">Put null in to first block constructor</param>
        public Block(List<Transaction> transactions, Block previousBlock)
        {
            zero = Array.Empty<Byte>();
            this.previousBlockHash = previousBlock?.blockHash ?? zero;
            this.transactions = transactions;
        }
        public Byte[] computeMerkleTreeHash(Byte[][] hashes)
        {
            if (hashes.Length == 1)
                return hashes[0];
            else if (hashes.Length == 2)
                return PureHash.computeHash(hashes[0].Concat(hashes[1]).ToArray());
            else
            {
                Byte[][] firstPart = hashes[..(hashes.Length / 2)];
                Byte[][] secondPart = hashes[(hashes.Length / 2)..];
                var hashOfLeft = computeMerkleTreeHash(firstPart);
                var hashOfRight = computeMerkleTreeHash(secondPart);
                return PureHash.computeHash(hashOfLeft.Concat(hashOfRight).ToArray());
            }

            return Array.Empty<Byte>();
        }
    }
}
