using Lubricentro.Application.Common.Interfaces.Services;

namespace Lubricentro.Infrastructure.Services;

public class CuilService : ICuilService
{
    public bool ValidateCuil(string cuil)
    {
        if (cuil.Length != 11) return false;


        int count = 0;
        for (int i = 9, j = 0; i >= 0; i--, j++)
        {
            if (!char.IsDigit(cuil[i])) return false;

            Console.WriteLine($"{count} {cuil[i]} {j % 6 + 2}");
            count += (cuil[i] - '0') * (j % 6 + 2);
        }

        return (11 - (count % 11)) % 11 + '0' == cuil[10];
    }
}
