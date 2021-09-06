

namespace P01.Stream_Progress
{
	public  interface IStreamable:ISource
	{
		int BytesSent { get; }
	}
}
