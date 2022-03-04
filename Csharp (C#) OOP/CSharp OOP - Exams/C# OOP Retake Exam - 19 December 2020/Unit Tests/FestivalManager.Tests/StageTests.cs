// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Performer performer;
		private Song song;

		[SetUp]
		public void Setup()
        {
			this.stage = new Stage();
			this.performer =new Performer("FirstName","LastName",18);
			this.song = new Song("Song",new TimeSpan(0,1,22));
        }

		[Test]
	    public void Test_CtorIfWorkingCurrectly()
	    {
			//Assert
			Assert.IsNotNull(this.stage);
		}

		[Test]
	    public void Test_ParameterWorkingCurrectly()
	    {
			//Assert
			Assert.IsNotNull(this.stage.Performers);
		}

		[Test]
		public void AddPerformer_ShouldIsRetunrNullObjectWithThrowsException()
        {

			//Arrange
			 this.performer = null;
			//Act

			//Assert
			Assert.Throws<ArgumentNullException>(
				() =>
				{
					this.stage.AddPerformer(performer);
				}
			);

		}

		[Test]
		public void AddPerformer_ShouldIsWithRetunrAgeThrowsException()
        {

			//Arrange
			this.performer = new Performer("Name","LastName",17);
			//Act

			//Assert
			Assert.Throws<ArgumentException>(
				() =>
				{
					this.stage.AddPerformer(performer);
				}
			);

		}

		[Test]
		public void AddPerformer_ShouldIsWithRetunrPerformerCorrcet()
        {

			//Act
			 this.stage.AddPerformer(this.performer);
			var expPerformer = this.stage.Performers.First();

			//Assert
			Assert.AreEqual(expPerformer, this.performer);
		}

		[Test]
		public void AddPerformer_ShouldIsWithRetunrPerformerCorrcetCount()
        {

			//Arrange
			var expPerformer = this.performer;
			var expCount = 1;
			//Act
			this.stage.AddPerformer(this.performer);

			//Assert
			Assert.AreEqual(expCount, this.stage.Performers.Count);
		}

		[Test]
		public void AddSong_ShouldIsWithRetunrSongWithThrowException()
        {

			//Arrange
			Song song = null;
			//Act

			//Assert
			Assert.Throws<ArgumentNullException>(
				() =>
				{
					this.stage.AddSong(song);
				}
			);
		}


		[Test]
		public void AddSong_ShouldIsWithRetunrSongWithThrowExceptionInTimeSpan()
        {

			//Arrange

			//Act

			//Assert
			Assert.Throws<ArgumentException>(
				() =>
				{
					this.stage.AddSong(new Song("Name",new TimeSpan(0,0,59)));
				}
			);
		}
		

		[Test]
		public void AddSongToPerformerShouldWithReturnException()
        {

			//Arrange

			//Act

			//Assert
			Assert.Throws<ArgumentNullException>(
				() =>
				{
					this.stage.AddSongToPerformer(null,null);
				}
			);
		}
		

		[Test]
		public void AddSongToPerformerShouldWithReturnStringMessageAndSuccesAddObject()
        {

			//Arrange
			var perfName = this.performer.FullName;
			var songName = this.song.Name;
			//Act
			this.stage.AddPerformer(this.performer);
			this.stage.AddSong(this.song);


			string expMessage = $"{this.song} will be performed by {this.performer}";
			string actMessage = this.stage.AddSongToPerformer(song.Name,performer.FullName);

			//Assert
			Assert.AreEqual(expMessage,actMessage);
		}

		[Test]
		public void PlayMusicShouldWithReturnCorrectMessage()
        {
			//Arrange
			var songsCount = this.stage.Performers.Sum(p => p.SongList.Count());

			string expMessage =  $"{this.stage.Performers.Count} performers played {songsCount} songs";

			//Assert
			Assert.AreEqual(expMessage, $"{this.stage.Performers.Count} performers played {songsCount} songs");
		}

		[Test]
		public void GetPerformerWithShouldThrowException()
		{
			//Arrange
			string performerName = "None";
			this.stage.AddPerformer(this.performer);

			//Act
			var actPerformer = this.stage.Performers.FirstOrDefault(p => p.FullName == performerName);

			//Assert
			Assert.IsNull(actPerformer, "There is no performer with this name.");

		}

		[Test]
		public void GetPerformerWithShouldRetturnCorrectElement()
		{
			//Arrange
			string performerName = this.performer.FullName;
			this.stage.AddPerformer(this.performer);

			//Act
			var actPerformer = this.stage.Performers.FirstOrDefault(p => p.FullName == performerName);

			//Assert
			Assert.IsNotNull(actPerformer);

		}
		//Arrange


		//Act

		//Assert


	}
}