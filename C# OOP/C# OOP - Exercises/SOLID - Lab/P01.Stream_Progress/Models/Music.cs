namespace P01.Stream_Progress.Models
{
    using Constrains;

    public class Music:IResult
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public string Artist { get => artist; set => artist = value; }

        public string Album { get => album; set => album = value; }
    }
}
