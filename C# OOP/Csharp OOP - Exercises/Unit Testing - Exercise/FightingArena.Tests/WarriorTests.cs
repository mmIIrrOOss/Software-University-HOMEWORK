namespace Tests
{

    using System;
    using NUnit.Framework;

    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfCostructorWorksCurrectly()
        {
            //Arrange
            string expectedName = "Miro";
            int expectedDmg = 50;
            int expectedHP = 100;
            Warrior warrior = new Warrior(expectedName, expectedDmg, expectedHP);

            //Act
            string actualName = warrior.Name;
            int actualDmg = warrior.Damage;
            int actualHP = warrior.HP;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDmg, actualDmg);
            Assert.AreEqual(expectedHP, actualHP);

        }

        [Test]
        public void TestWithLikeName()
        {
            //Arrange
            string name = null;
            int dmg = 50;
            int hp = 100;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            //Arrange
            string name = string.Empty;
            int dmg = 50;
            int hp = 100;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeWhiteSpaceName()
        {
            //Arrange
            string name = "      ";
            int dmg = 50;
            int hp = 100;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            //Arrange
            string name = "Miro";
            int dmg = 0;
            int hp = 100;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeNegativeDamage()
        {
            //Arrange
            string name = "Miro";
            int dmg = -1;
            int hp = 100;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        public void TestWithLikeNegativeHP()
        {
            //Arrange
            string name = "Miro";
            int dmg = 2;
            int hp = -1;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });

        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhenLowHPShouldThrowException(int attackerHp)
        {
            //Arrange
            string attackerName = "Miro";
            int attackerDmg = 10;

            //Act
            string diffenderName = "Gosho";
            int diffenderDmg = 10;
            int diffenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHp);
            Warrior diffenderWarrior = new Warrior(diffenderName,
                diffenderDmg, diffenderHP);

            //Assert
            Assert.Throws<InvalidOperationException>(()=>
            {
                attacker.Attack(diffenderWarrior);
            }
            );


        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWithLowHPShouldThrowException(int diffenderHP)
        {
            //Arrange
            string aName = "Miro";
            int aDmg = 10;
            int aHp = 100;
            //Act
            string diffenderName = "Gosho";
            int diffenderDmg = 10;

            Warrior attacker = new Warrior(aName, aDmg, aHp);
            Warrior diffenderWarrior = new Warrior(diffenderName,
                diffenderDmg, diffenderHP);

            //Assert
            Assert.Throws<InvalidOperationException>(()=>
            {
                attacker.Attack(diffenderWarrior);
            }
            );


        }

        [Test]
        public void AttackingStrongerEnemyShouldThrowException()
        {
            //Arrange
            string aName = "Miro";
            int aDmg = 10;
            int aHp = 35;
            //Act
            string dName = "Gosho";
            int dDmg = 40;
            int dHP = 35;

            Warrior attacker = new Warrior(aName, aDmg, aHp);
            Warrior diffenderWarrior = new Warrior(dName, dDmg, dHP);

            //Assert
            Assert.Throws<InvalidOperationException>(()=>
            {
                attacker.Attack(diffenderWarrior);
            }
            );


        }

        [Test]
        public void AttackingShouldDecreaseHPWhenSuccessfull()
        {
            //Arrange
            string aName = "Miro";
            int aDmg = 10;
            int aHp = 40;
            
            string dName = "Gosho";
            int dDmg = 5;
            int dHP = 50;

            Warrior attackerWarrior = new Warrior(aName, aDmg, aHp);
            Warrior diffenderWarrior = new Warrior(dName, dDmg, dHP);

            int expectedAttackerHP = aHp - dDmg;
            int expecedDiffenderHP = dHP - aDmg;

            //Act
            attackerWarrior.Attack(diffenderWarrior);

            //Assert
            Assert.AreEqual(expectedAttackerHP, attackerWarrior.HP);
            Assert.AreEqual(expecedDiffenderHP, diffenderWarrior.HP);
        }

        [Test]
        public void KillingEnemyWithAttack()
        {
            //Arrange
            string aName = "Miro";
            int aDmg = 80;
            int aHp = 100;
            
            string dName = "Gosho";
            int dDmg = 10;
            int dHP = 60;

            Warrior attackerWarrior = new Warrior(aName, aDmg, aHp);
            Warrior diffenderWarrior = new Warrior(dName, dDmg, dHP);

            int expectedAttackerHP = aHp - dDmg;
            int expecedDiffenderHP = 0;

            //Act
            attackerWarrior.Attack(diffenderWarrior);

            //Assert
            Assert.AreEqual(expectedAttackerHP, attackerWarrior.HP);
            Assert.AreEqual(expecedDiffenderHP, diffenderWarrior.HP);
        }
    }
}