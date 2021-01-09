namespace SGM.Shared.Domain.Results
{
    public abstract class ResultBase
    {
        public bool status { get; set; }

        public ResultBase(bool status)
        {
            this.status = status;
        }
    }
}