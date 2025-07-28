using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDataStructures.Trie
{
    public interface ITrieIndex<IndexType> : IReadOnlyList<IndexType>
    {
        public IReadOnlyList<IndexType> IndexData { get; }
    }
}
