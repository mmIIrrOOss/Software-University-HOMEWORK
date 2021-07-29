using System;

namespace _02._Articles
{
	using System.Collections.Generic;
	using System.Linq;
	class Article
	{
		public Article(string title, string content, string author)
		{
			this.Title = title;
			this.Content = content;
			this.Author = author;
		}
		public override string ToString()
		{
			return $"{Title} - {Content}: {Author}";
		}
		public string Title { get; set; }
		public string Content { get; set; }
		public string Author { get; set; }

	}
	class Program
	{
		static void Main(string[] args)
		{
			int lines = int.Parse(Console.ReadLine());
			List<Article> articlesList = new List<Article>();
			List<string> input = new List<string>();
			for (int i = 1; i <= lines; i++)
			{
				input = Console.ReadLine().Split(", ").ToList();
				var articule = new Article(input[0], input[1], input[2]);
				articlesList.Add(articule);
			}
			string orderByWhat = Console.ReadLine();
			switch (orderByWhat)
			{
				case "title":
					articlesList = articlesList.OrderBy(x => x.Title).ToList();
					break;

				case "content":
					articlesList = articlesList.OrderBy(X => X.Content).ToList();
					break;

				case "autor":
					articlesList = articlesList.OrderBy(X => X.Author).ToList();
					break;
			}
			Console.WriteLine(string.Join(Environment.NewLine,articlesList));


		}
	}
}
