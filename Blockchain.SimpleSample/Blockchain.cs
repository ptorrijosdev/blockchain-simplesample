using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blockchain.SimpleSample
{
    class Blockchain<T> : IEnumerable<Block<T>> where T : class
    {
        #region Properties

        public List<Block<T>> Items { get; }

        #endregion

        #region Constructors

        public Blockchain()
        {
            Items = new List<Block<T>>();
        }

        #endregion

        public void Add(T content)
        {
            Block<T> newBlock;

            if (Items.Count == 0)
            {
                // Add as genesis block
                var genesisBlock = new Block<T>(null, content);
                newBlock = new Block<T>(genesisBlock, content);
            }
            else
            {
                // Add block
                var previousBlock = Items.Last();
                newBlock = new Block<T>(previousBlock, content);
            }

            Items.Add(newBlock);
        }

        public IEnumerator<Block<T>> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
