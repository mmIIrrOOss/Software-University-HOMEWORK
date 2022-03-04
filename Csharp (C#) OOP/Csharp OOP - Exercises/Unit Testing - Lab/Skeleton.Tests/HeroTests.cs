using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const int attackPoints = 2;
    private const int durabilityPoints = 1;
    private const int dummyHealth = 6;
    private const int dummyExperience = 5;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(attackPoints, durabilityPoints);
        this.dummy = new Dummy(dummyHealth, dummyExperience);
    }

    [TearDown]
    public void CleanUp()
    {
        this.axe = null;
        this.dummy = null;
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {

        //Arrange
        axe.Attack(dummy);
        int expectedDurability = durabilityPoints - 1;

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurability)
            , "Axe Durability doesnt change after attack.");

    }

    [Test]
    public void AttackWithBrokenAxeShouldThrow()
    {
        //Arrange
        axe.Attack(dummy);

        //Assert

        Assert.That(() => axe.Attack(dummy),
            Throws
            .InvalidOperationException
            .With.Message.EqualTo("Axe is broken."),
            "Unappropriate message");   
    }

    [Test]
    public void DummyLoosesHealthIfAttacked()
    {
        //Arrange
        int damageTaken = 5;
        int expectedHealth = dummy.Health - damageTaken;

        //Act
        dummy.TakeAttack(damageTaken);

        //Assert

        Assert.That(dummy.Health, Is.EqualTo(expectedHealth)
            , "Inproper ammount of health taken from Dummy");   
    }

    [Test]
    public void AttackDeadDummyShouldThrow()
    {
        //Arrange
        int damageTaken = 6;

        //Act
        dummy.TakeAttack(damageTaken);

        //Assert
        Assert.That(()=>dummy.TakeAttack(damageTaken),
            Throws.InvalidOperationException
            .With.Message
            .EqualTo("Dummy is dead."),
            "Inapropiate message");
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        //Act
        dummy.TakeAttack(dummy.Health);

        //Assert

        Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExperience)
            , "Dead dummy doesnt give correct ammount at experience");   
    }

    [Test]
    public void AliveDummyCanGiveExperience()
    {
         //Arange
        Hero hero = new Hero("Miro");
        Dummy dummy = new Dummy(dummyHealth, dummyExperience);

        //Act
        hero.Attack(dummy);

        //Assert

        Assert.That(() => dummy.GiveExperience(), 
            Throws.InvalidOperationException
            .With.Message
            .EqualTo("Alive dummy changes experience"));
             
    }
}