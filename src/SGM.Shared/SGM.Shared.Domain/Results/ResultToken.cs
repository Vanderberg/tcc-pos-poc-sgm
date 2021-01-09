using System;

namespace SGM.Shared.Domain.Results
{
    public class ResultToken : ResultBase
    {
        public string Message { get; set; }
        public string accessToken { get; set; }
        public DateTime Expire { get; set; }

        public ResultToken() : base(false)
        {

        }

        public ResultToken(bool status) : base(status)
        {
        }

        public ResultToken(bool status, string message) : base(status)
        {
            this.Message = message;
        }

        public ResultToken(bool status, string message, string token, DateTime expire) : base(status)
        {
            this.Message = message;
            this.accessToken = token;
            this.Expire = expire;
        }
    }
}