
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository repository;
    private Hero hero;
    private List<Hero> heroes;

    [SetUp]
    public void Setup()
    {
        this.repository = new HeroRepository();
        this.hero = new Hero("Name", 10);
        this.heroes = new List<Hero>();
    }

    [Test]
    public void TestConstructorIfWorkingCorrect()
    {
        //Arrange

        //Act

        //Assert
        Assert.IsNotNull(this.repository);
    }

    [Test]
    public void TestCreateMethodShouldWithThrowsExceptionWithForNullHero()
    {
        //Arrange
        Hero hero = null;
        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                this.repository.Create(hero);
            }, nameof(hero), "Hero is null"
        );
    }

    [Test]
    public void TestCreateMethodShouldWithThrowsExceptionWithForExistHero()
    {
        //Arrange

        //Act
        this.repository.Create(this.hero);
        //Assert
        Assert.Throws<InvalidOperationException>(
            () =>
            {
                this.repository.Create(this.hero);
            }, $"Hero with name {hero.Name} already exists"
        );
    }

    [Test]
    public void TestCreateMethodShouldWithAddedSuccesForReturnStringMessage()
    {
        //Arrange

        //Act
        var expMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";

        //Assert
        Assert.AreEqual(expMessage, this.repository.Create(hero));
    }

    [Test]
    public void TestRemoveMethodShouldWithThrowsExceptionForNameIsNull()
    {
        //Arrange
        this.repository.Create(this.hero);

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Remove(null);
        }, "Name cannot be null");
    }

    [Test]
    public void TestRemoveMethodShouldWithThrowsExceptionForNameIsWhiteSpace()
    {
        //Arrange
        this.repository.Create(this.hero);

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Remove("   ");
        }, "Name cannot be null");
    }

    [Test]
    public void TestRemoveMethodShouldWithForNameIsSucces()
    {
        //Arrange
        this.repository.Create(this.hero);

        //Act

        //Assert
        Assert.AreEqual(true, this.repository.Remove("Name"));
    }

    [Test]
    public void GetHeroWithHighestLevelWithReturnHero()
    {
        //Arrange
        this.repository.Create(this.hero);
        var expLevel = this.hero.Level;

        //Act
        var actLevel = this.repository.GetHeroWithHighestLevel();

        //Assert
        Assert.AreEqual(expLevel, actLevel.Level);
        Assert.AreEqual(this.hero, this.repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroWithReturnHeroName()
    {
        //Arrange
        this.repository.Create(this.hero);
        var expName = this.hero.Name;

        //Act
        var actName = this.repository.GetHero("Name");

        //Assert
        Assert.AreEqual(expName, actName.Name);
        Assert.AreEqual(this.hero, this.repository.GetHero("Name"));
    }

    [Test]
    public void TestCollectionWithReturnIreadOnlyCollectionSucces()
    {
        //Arrange

        //Assert
        Assert.AreEqual(this.heroes.AsReadOnly(), this.repository.Heroes);
    }

}

