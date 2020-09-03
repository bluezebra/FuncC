using System;
using System.Linq;
using System.Net.Http;
using LanguageExt;
using static System.Console;
using static System.Math;
using static LanguageExt.Prelude;

namespace FuncCConsole
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var req = new HttpRequestMessage();
            req.Headers.Add("userId", "333");
            req.Headers.Add("tenantId", "666");


            var userId = req.SafeGetValue("userId");
            var tenantId = req.SafeGetValue("tenantId");

            if (tenantId.IsNone)
                WriteLine("No TenantIdKey received.");
            var tenantIdValue1 = tenantId.Map(x => x);
            WriteLine($"TenantId value is: {tenantIdValue1}");

            var userIdValue = "";
            userId.Match(x => userIdValue = x, () => WriteLine("No userId ha ha we did something different."));
            WriteLine("We separated userId out: " + userIdValue);

            var tenantIdValue = "";
            tenantId.Match(x => tenantIdValue = x, () => WriteLine("No tenantId ha ha we did something different."));
            WriteLine("Nothing in tenantId: " + tenantIdValue);
            
            WriteLine(userId.Match(x => x, () => "No userId"));

            if (userId.IsNone)
                WriteLine("None detected");
            else
                WriteLine("Found: "+ userId);


            WriteLine(tenantId.Match(x => x, () => "No tenantId"));

            if (tenantId.IsNone)
                WriteLine("None detected");
            else
                WriteLine("Found: "+ tenantId);

        }
        static Option<string> SafeGetValue(this HttpRequestMessage req, string key)
        {
            return req.Headers.Contains(key) 
                ? Some(req.Headers.GetValues(key).First()) 
                : Option<string>.None;
        }

        static Either<string, double> Calc(double x, double y)
        {
            if (y == 0) return "y cannot be 0";
            if (x != 0 && Sign(x) != Sign(y))
                return "x / y cannot be negative";
            return Sqrt(x / y);
        }

    }

    public static class F
    {
        public static readonly Func<int, string> ToString2 = i => i.ToString();

        public static readonly Func<int, Func<int, int>> Add = a => b => a + b;

    }

}