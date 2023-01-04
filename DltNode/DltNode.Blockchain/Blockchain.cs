using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DltNode.Blockchain
{
    public class Blockchain
    {
        public List<Block> blockchain;

        public Blockchain(Block genesisBlock)
        {
            blockchain = new List<Block>();
            blockchain.Add(genesisBlock);
        }
        public Boolean AddNewBlock(Block newBlock)
        {
            if (newBlock.previousBlockHash != blockchain[blockchain.Count() - 1].blockHash)
            {
                return false;
            }
            else
            {
                blockchain.Add(newBlock);
                return true;
            }
        }
        public Int32 Height => blockchain.Count();
    }
}