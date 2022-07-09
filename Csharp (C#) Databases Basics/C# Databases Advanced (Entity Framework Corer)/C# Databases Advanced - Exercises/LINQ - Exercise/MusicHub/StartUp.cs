namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var emportAlbumsInfo = context.Producers
                .FirstOrDefault(p => p.Id == producerId)
                .Albums.Select(alubm => new
                {
                    AlbumName = alubm.Name,
                    ReleaseDate = alubm.ReleaseDate,
                    ProducerName = alubm.Producer.Name,
                    Songs = alubm.Songs.Select(song => new
                    {
                        SongName = song.Name,
                        Price = song.Price,
                        Writer = song.Writer.Name
                    })
                    .OrderByDescending(song => song.SongName)
                    .ThenBy(writer => writer.Writer)
                    .ToList(),
                    AlbumPrice = alubm.Price
                })
                .OrderByDescending(alubm => alubm.AlbumPrice)
                .ToList();

            foreach (var albumInfo in emportAlbumsInfo)
            {
                sb.AppendLine($"-AlbumName: {albumInfo.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {albumInfo.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {albumInfo.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;
                foreach (var song in albumInfo.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {albumInfo.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd(); ;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs.AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers.
                                         Select(p => p.Performer.FirstName + " " + p.Performer.LastName)
                                         .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.WriterName)
                .ThenBy(s=>s.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();
            int counter = 1;

            foreach (var song in songsAboveDuration)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
