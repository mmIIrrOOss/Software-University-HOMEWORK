namespace Tests
{
    using NUnit.Framework;
    using System;

    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior attacker;
        private Warrior diffender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Miro", 5, 50);
            this.attacker = new Warrior("Pesho", 10, 80);
            this.diffender = new Warrior("Gosho", 5, 60);
        }

        [Test]
        public void TestIfConstructorWorkCurrectly()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldPhysicallyAddTheWarriorToTheArena()
        {
            //Arrange

            //Act
            this.arena.Enroll(this.warrior);

            //Assert

            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }
        

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            //Arrange
            int expectedCount = 2;

            //Act
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(new Warrior("Mirkos",5,60));
            int actualCount = this.arena.Count;

            //Assert
            Assert.AreEqual(expectedCount,actualCount);
        }
        
        

        [Test]
        public void EnrollShouldSameWarriorShouldThrowException()
        {
            //Arrange
            this.arena.Enroll(this.warrior);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(()=> 
            {
                this.arena.Enroll(this.warrior);
            }
            );
        }

        [Test]
        public void EnrollTwoWarriorsWithSameNameShouldThrowException()
        {
            //Arrange
            Warrior warriorCopy = new Warrior(this.warrior.Name,
                this.warrior.Damage, this.warrior.HP);
            //Act
            this.arena.Enroll(this.warrior);
            //Assert
            Assert.Throws<InvalidOperationException>(()=> 
            {
                this.arena.Enroll(warriorCopy);
            }
            );
        }

        [Test]
        public void TestFightingWithMissingAttacker()
        {
            //Arrange

            //Act
            this.arena.Enroll(this.diffender);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena
                .Fight(this.attacker.Name, this.diffender.Name);
            }
            );
           
        }

        
        [Test]
        public void TestFightingWithMissingDeffender()
        {
            //Arrange

            //Act
            this.arena.Enroll(this.attacker);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena
                .Fight(this.attacker.Name, this.diffender.Name);
            }
            );
           
        }
        
        
        [Test]
        public void TestFightingBetweenTwoWarriors()
        {
            //Arrange
            int expectedAHP = this.attacker.HP - 
                this.diffender.Damage;
            int expectedDHP = this.diffender.HP - 
                this.attacker.Damage;

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.diffender);

            //Act
            this.arena.Fight(this.attacker.Name, this.diffender.Name);

            //Assert
            Assert.AreEqual(expectedAHP, this.attacker.HP);
            Assert.AreEqual(expectedDHP, this.diffender.HP);
        }




    }
}
