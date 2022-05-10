using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

namespace blockchain
{

    public class Block
    {
        public DateTime CreatedDate { get; }
        public string Hash { private set; get; }
        public string PreviousHash { get; }
        public object Data { get; }

        private int nonce;

        public Block(object data, string previousHash)
        {
            nonce = 0;

            CreatedDate = DateTime.Now;
            PreviousHash = previousHash;
            Data = data;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            return ComputeSha256Hash($"{CreatedDate}{Data}{PreviousHash}{nonce}");
        }

        string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void MineBlock(int difficulty)
        {
            Console.WriteLine($"{DateTime.Now}: Mining started ... ");
            while (Hash.Substring(0, difficulty) != string.Join('0', new string[difficulty + 1]))
            {
                nonce++;
                Hash = CalculateHash();
            }
            Console.WriteLine($"{DateTime.Now}: Mining Completed! ");
        }

        public override string ToString()
        {
            return $@"[
                CreatedDate: {CreatedDate},
                Previous Hash: {PreviousHash},
                Hash: {Hash},
                Data: {Data}
]";
        }

        public override bool Equals(object obj)
        {
            return ((obj is Block)
            && ((Block)obj).Hash == Hash
            && ((Block)obj).Data == Data
            && ((Block)obj).PreviousHash == PreviousHash
            && ((Block)obj).CreatedDate == CreatedDate);
        }

        public override int GetHashCode()
        {
            return Hash.GetHashCode();
        }
    }

    public class BlockChain
    {
        public BlockChain()
        {
            Blocks = new List<Block>();
            Blocks.Add(createGenesisBlock());

        }

        public Block createGenesisBlock()
        {
            return new Block("GenesisBlock", "0");
        }

        public Block GetLatestBlock()
        {
            return Blocks.LastOrDefault();
        }

        public void AddData(object data)
        {
            Console.WriteLine($"Adding Block {Blocks.Count} data");
            var newBlock = new Block(data, Blocks.LastOrDefault().Hash);
            newBlock.MineBlock(5);

            Blocks.Add(newBlock);
            Console.WriteLine($"Added Block {Blocks.Count} data\n");

        }

        public List<Block> Blocks { get; }

        public bool IsValidChain()
        {
            var realGenesisBlock = createGenesisBlock();

            if (realGenesisBlock.Equals(Blocks[0]))
            {
                return false;
            }

            for (var i = 1; i < Blocks.Count; i++)
            {
                var currentBlock = Blocks[i];
                var previousBlock = Blocks[i - 1];

                if (previousBlock.Hash != currentBlock.PreviousHash)
                {
                    return false;
                }

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var result = "";
            var index = 0;
            foreach (var block in Blocks)
            {
                result += $"Block {index++}: {block}\n";
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var blockChain = new BlockChain();

            blockChain.AddData("Data 1");

            blockChain.AddData("Data 2");

            blockChain.AddData("Data 3");

            Console.WriteLine($"BlockChain: {blockChain}");
            Console.WriteLine($"BlockChain Valid? {blockChain.IsValidChain()}");

            //alter block 2 data
            var alterBlock2 = new Block("new data 02", blockChain.Blocks[1].Hash);
            blockChain.Blocks[2] = alterBlock2;

            Console.WriteLine($"BlockChain: {blockChain}");
            Console.WriteLine($"BlockChain Valid? {blockChain.IsValidChain()}");

        }
    }
}
