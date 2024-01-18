using Lubricentro.Application.Common.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace Lubricentro.Infrastructure.Services;

public class PasswordProvider : IPasswordProvider
{
    private readonly List<char> _chars;
    private const int _minimumPasswordLength = 7;
    public PasswordProvider()
    {
        _chars = [];
        for(char c = 'a'; c <= 'z'; c++)
        {
            _chars.Add(c);
        }
        for(char c = '1'; c <= '9'; c++)
        {
            _chars.Add(c);
        }
    }
    public string GenerateRandomPassword()
    {
        int charSetSize = _chars.Count;
        StringBuilder stringBuilder = new();
        int randomIndex;
        for(int i = 0; i < _minimumPasswordLength; i++)
        {
            randomIndex = RandomNumberGenerator.GetInt32(0, charSetSize);
            stringBuilder.Append(_chars[randomIndex]);
        }
        return stringBuilder.ToString();
    }
}
