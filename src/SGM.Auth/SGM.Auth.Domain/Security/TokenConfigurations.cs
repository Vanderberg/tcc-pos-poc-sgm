namespace SGM.Auth.Domain.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; } // Publico
        public string Issuer { get; set; } //Emissor
        public int Seconds { get; set; }
    }
}