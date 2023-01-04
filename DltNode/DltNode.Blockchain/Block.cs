
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DltNode.Hash;

namespace DltNode.Blockchain
{
    public class Block
    {
        public readonly Byte[] blockHash;

        public readonly Byte[] previousBlockHash;

        public readonly List<Transaction> transactions;

        public readonly Byte[] zero;
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
            blockHash = computeMerkleTreeHash(hashes);
        }
        public Byte[] computeMerkleTreeHash(List<Byte[]> hashes)
        {
            if (hashes.Count == 1)
                return hashes[0];
            else if (hashes.Count == 2)
                return PureHash.computeHash(hashes[0].Concat(hashes[1]).ToArray());
            else
            {
                List<Byte[]> firstPart = hashes.GetRange(0, hashes.Count / 2);
                List<Byte[]> secondPart = hashes.GetRange(hashes.Count / 2, hashes.Count - 1);
                var hashOfLeft = computeMerkleTreeHash(firstPart);
                var hashOfRight = computeMerkleTreeHash(secondPart);
                return PureHash.computeHash(hashOfLeft.Concat(hashOfRight).ToArray());
            }

            return Array.Empty<Byte>();
        }
    }
}