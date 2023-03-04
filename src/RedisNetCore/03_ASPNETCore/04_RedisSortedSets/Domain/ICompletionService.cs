using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_RedisSortedSets.Domain;

public interface ICompletionService
{
    bool HasWords { get; }
    void AddRange(IEnumerable<string> words);
    IEnumerable<string> Get(string prefix);
}
