using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Blockchain.SimpleSample
{
    class Block<T> where T : class
    {
        #region Properties

        public DateTime TimeSpan { get; }
        public int PreviousHash { get => _previousBlock == null ? 0 : _previousBlock.GetHash(); }
        public T Content { get; set; }

        private Block<T> _previousBlock;

        #endregion

        #region Constructors

        public Block(Block<T> previousBlock, T content)
        {
            TimeSpan = DateTime.Now;
            _previousBlock = previousBlock;
            Content = content;
        }

        #endregion

        public int GetHash()
        {
            string content = string.Format("{0}.{1}.{2}", PreviousHash.ToString(), TimeSpan.ToString("dd/MM/yyyy HH:mm:ss"), Content.ToString());
            return content.GetHashCode();
        }
    }
}
