using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        //Arange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesnt change after attack.");

    }

    [Test]
    public void AttackWithBrokenAxeShouldThrow()
    {
        //Arange
        Axe axe = new Axe(5, 0);
        Dummy dummy = new Dummy(10, 10);

        //Assert
        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With
            .Message.EqualTo("Axe is broken."));
    }
}