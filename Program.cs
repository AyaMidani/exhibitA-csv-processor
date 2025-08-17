using System;
using System.IO;
using System.Linq;
using System.Globalization;

namespace ExhibitA
{
    public class PlayRow
    {
        public string Id { get; set; } = string.Empty;
        public string Song { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public DateTime Time { get; set; }
    }

    class Program
    {
        static readonly string[] DateFormats = new[]
        {
            "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy",
            "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd"
        };

        static DateTime ParseDate(string s)
        {
            if (DateTime.TryParseExact(
                    s, DateFormats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var dt))
                return dt;
            return DateTime.Parse(s, CultureInfo.InvariantCulture);
        }

        static void Main(string[] args)
        {
            var inputPath  = Path.Combine("input", "exhibitA-input.csv");
            var outputDir  = "output";
            var outputPath = Path.Combine(outputDir, "results.csv");
            Directory.CreateDirectory(outputDir);

            var rows = File.ReadAllLines(inputPath)
                .Skip(1)
                .Select(l =>
                {
                    var p = l.Split('\t');
                    return new PlayRow
                    {
                        Id   = p[0],
                        Song = p[1],
                        User = p[2],
                        Time = ParseDate(p[3])
                    };
                })
                .ToList();

            var target = new DateTime(2016, 8, 10);

            var distribution =
                rows.Where(r => r.Time.Date == target.Date)
                    .GroupBy(r => r.User)
                    .Select(g => g.Select(x => x.Song).Distinct().Count())
                    .GroupBy(distinctCount => distinctCount)
                    .Select(g => new { DistinctPlayCount = g.Key, ClientCount = g.Count() })
                    .OrderBy(x => x.DistinctPlayCount)
                    .ToList();

            using (var w = new StreamWriter(outputPath))
            {
                w.WriteLine("DISTINCT_PLAY_COUNT,CLIENT_COUNT");
                foreach (var row in distribution)
                    w.WriteLine($"{row.DistinctPlayCount},{row.ClientCount}");
            }

            Console.WriteLine($"Results for 2016-08-10 written to {outputPath}");
        }
    }
}
