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

		public void Edit(string newContent)
		{
			this.Content = newContent;
		}

		public void ChangeAuthor(string newAuthor)
		{
			this.Author = newAuthor;
		}

		public void Rename(string newTitle)
		{
			this.Title = newTitle;
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
			List<string> articlesList = Console.ReadLine()
				.Split(", ")
				.ToList();
			string title = articlesList[0];
			string content = articlesList[1];
			string author = articlesList[2];

			var article = new Article(title, content, author);

			int lines = int.Parse(Console.ReadLine());

			for (int i = 1; i <=lines; i++)
			{
				string[] commands = Console.ReadLine()
					.Split(": ",StringSplitOptions.RemoveEmptyEntries)
					.ToArray();
				if (commands[0] == "Edit")
				{
					string newContent = commands[1];
					article.Edit(newContent);
					
				}
				else if (commands[0] == "ChangeAuthor")
				{
					string newAuthor = commands[1];
					article.ChangeAuthor(newAuthor);
					
				}
				else if (commands[0] == "Rename")
				{
					string newTitle = commands[1];
					article.Rename(newTitle);
					
				}
			}
			Console.WriteLine(article.ToString());
			
			
		}
	}
}
