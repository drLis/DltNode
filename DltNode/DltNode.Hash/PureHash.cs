using System;
using System.Security.Cryptography;
using System.Collections;
namespace DltNode.Hash
{
    public static class PureHash
    {

        //public 
        public static byte[] computeHash(byte[] input)
        {
            var hashing = SHA256.Create();
            //input.Length 


            return hashing.ComputeHash(input);
        }
        
    }
}
