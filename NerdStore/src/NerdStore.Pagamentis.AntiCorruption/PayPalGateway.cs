using System;
using System.Linq;

namespace NerdStore.Pagamentos.AntiCorruption;

public class PayPalGateway : IPayPalGateway
{
    public bool CommitTransaction(string cardHashKey, string orderId, decimal amount)
    {
        return new Random().Next(2) == 0; // é como se fosse uma roleta russa pois as vezes será aprovado e as vezes nao
        //return false;
    }

    public string GetCardHashKey(string serviceKey, string cartaoCredito)
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }

    public string GetPayPalServiceKey(string apiKey, string encriptionKey)
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[new Random().Next(s.Length)]).ToArray());
    }
}
