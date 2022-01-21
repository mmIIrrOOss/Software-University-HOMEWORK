namespace BankSafe.Tests
{
    using System;
    using NUnit.Framework;

    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.item = new Item("Miro", "1");
        }

        [Test]
        public void WhenDoesNotExist_ShouldThrowException()
        {
            //Arrange

            //Act

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("ima go", item);
            });

            //Assert
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");

        }

        [Test]
        public void WhenCellAlreadyTaken_ShouldThrowException()
        {
            //Arrange

            //Act

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("AZ", "69"));
            });

            //Assert
            Assert.AreEqual(ex.Message, "Cell is already taken!");

        }

        [Test]
        public void WhenItemAlreadyExist_ShouldThrowException()
        {
            //Arrange

            //Act

            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("B3", item);
            });

            //Assert
            Assert.AreEqual(ex.Message, "Item is already in cell!");

        }

        [Test]
        public void SuccesCompareShouldReturnCurrentStrngMessage()
        {
            //Arrange

            //Act
            string result = vault.AddItem("A2", item);

            //Assert
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");

        }


        [Test]
        public void WhenRemoveCalledAnd_ShouldThrowException()
        {
            //Arrange

            //Act

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("ima go", item);
            });

            //Assert
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");

        }

        [Test]
        public void WhenRemoveCalledAndItem_ShouldThrowException()
        {
            //Arrange

            //Act

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", item);
            });

            //Assert
            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");

        }

        [Test]
        public void WhenRemoveItemSuccesuflyShouldReturnCUrrentItemAndMessage()
        {
            //Arrange
            vault.AddItem("A2", item);
            //Act
            string result = vault.RemoveItem("A2", item);

            //Assert
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");

        }

        [Test]
        public void WhenRemoveItemSuccesuflyShouldTheMakeCellNull()
        {
            //Arrange
            vault.AddItem("A2", item);

            //Act
            string result = vault.RemoveItem("A2", item);

            //Assert
            Assert.AreEqual(null, vault.VaultCells["A2"]);

        }

        [Test]
        public void WhenItemsAdded_ShouldSetItemToCell()
        {
            //Arrange

            //Act
            vault.AddItem("A2", item);

            //Assert
            Assert.AreEqual(item, vault.VaultCells["A2"]);

        }
    }
}