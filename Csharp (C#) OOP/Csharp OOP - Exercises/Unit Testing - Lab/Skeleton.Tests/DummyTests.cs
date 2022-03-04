using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAtacked()
    {
        //Arange
        Dummy dummy = new Dummy(10, 15);

        //Act
        dummy.TakeAttack(5);

        //Assert
        Assert.That(dummy.Health, Is.EqualTo(5));
    }

    [Test]
    public void AttackDeadDummyShouldThrow()
    {
        //Arange
        Dummy dummy = new Dummy(0, 10);

        //Assert
        Assert.That(()=>dummy
        .TakeAttack(5),
        Throws.InvalidOperationException
        .With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        //Arange
        Hero hero = new Hero("Miro");
        Dummy dummy = new Dummy(10, 50);

        //Act
        hero.Attack(dummy);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(50));
    }  

    [Test]
    public void AliveDummyCantGiveExperience()
    {
        //Arange
        Hero hero = new Hero("Miro");
        Dummy dummy = new Dummy(20, 50);

        //Act
        hero.Attack(dummy);

        //Assert
        Assert.That(hero.Experience, Is.EqualTo(0));
    }   
   
}
