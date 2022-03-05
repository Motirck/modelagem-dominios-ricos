using System;
using System.Linq;

namespace NerdStore.Pagamentos.AntiCorruption;

public class ConfigurationManager : IConfigurationManager
{
    public string GetValue(string node)
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
