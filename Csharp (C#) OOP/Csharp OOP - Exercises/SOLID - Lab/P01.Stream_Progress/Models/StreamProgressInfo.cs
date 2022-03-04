namespace P01.Stream_Progress.Models
{
    using Constrains;

    public class StreamProgressInfo
    {
        private readonly IResult streamProgress;

        public StreamProgressInfo(IResult streamProgress)
        {
            this.streamProgress = streamProgress;
        }

        public int CalculateCurrentPercent()
        {
            return streamProgress.BytesSent * 100 / streamProgress.Length;
        }
    }
}
