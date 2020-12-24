using System;

namespace TesteApp.Models.Seguranca
{
    public sealed class Token
    {
        private Token() { }

        public static string NovoToken()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
    }
}