using Common;
using System.Threading.Tasks;

namespace FuncApp1.Helpers
{
    public class FakeMessageAdd : IMessageAdd
    {
        public async Task<bool> AddAsync(
            MessageAddOptions messageAddOptions)
        {
            return await Task.FromResult(true);
        }
    }
}
