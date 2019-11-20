using System.Threading.Tasks;

namespace Common
{
    public interface IMessageAdd
    {
        Task<bool> AddAsync(
            MessageAddOptions messageAddOptions);
    }
}
