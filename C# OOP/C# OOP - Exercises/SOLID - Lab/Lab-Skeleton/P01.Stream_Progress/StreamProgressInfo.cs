
namespace P01.Stream_Progress
{
	using System;

    public class StreamProgressInfo : StreamProgressor
    {
        public StreamProgressInfo(IStreamable file) : base(file)
        {
        }
    }
}
