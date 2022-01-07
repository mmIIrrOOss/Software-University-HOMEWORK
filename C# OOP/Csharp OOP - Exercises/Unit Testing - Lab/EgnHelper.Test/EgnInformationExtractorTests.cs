using System;
using EgnHelper.Enums;
using EgnHelper.Models;
using EgnHelper.Models.Contracts;
using NUnit.Framework;

namespace EgnHelper.Test
{
    [TestFixture]
    public class EgnInformationExtract
    {

        [Test]
        //ЕГН: 6101057509 е ЕГН на мъж, роден на 5 януари 1961 г.в регион София - окръг
        public void ExtractInformationShouldWorkCorrectlyFor6101057509()
        {
            //Arrange
            var infromationExtractor = new EgnInformationExtractor(new EgnValidator());

            //Act
            EgnInformation information = infromationExtractor.Extract("6101057509");

            //Assert
            Assert.That(information.PlaceOfBirth,Is.EqualTo( "София - окръг"));
            Assert.That(information.DayOfBirth, Is.EqualTo(new DateTime(1961, 1, 5)));
            Assert.That(information.Sex, Is.EqualTo((Sex.Male)));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 5 януари 1961 г. в регион София - окръг"));
        }


        [Test]
        //ЕГН: 8032056031 е ЕГН на жена, родена на 5 декември 1880 г.в регион Смолян
        public void ExtractInformationShouldWorkCorrectlyFor8032056031()
        {
            //Arrange
            var infromationExtractor = new EgnInformationExtractor(new EgnValidator());

            //Act
            var information = infromationExtractor.Extract("8032056031");

            //Assert
            Assert.That(information.PlaceOfBirth, Is.EqualTo("Смолян"));
            Assert.That(information.DayOfBirth,Is.EqualTo(new DateTime(1880, 12, 5)));
            Assert.That(information.Sex,Is.EqualTo(Sex.Female));
            Assert.That(information.ToString(),Is.EqualTo("ЕГН на жена, родена на 5 декември 1880 г. в регион Смолян"));
        }

        [Test]
        //ЕГН: 7552010005 е ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград
        public void ExtractInformationShouldWorkCorrectlyFor7552010005()
        {
            //Arrange
            var infromationExtractor = new EgnInformationExtractor(new EgnValidator());

            //Act
            var information = infromationExtractor.Extract("7552010005");

            //Assert
            Assert.That(information.PlaceOfBirth, Is.EqualTo(("Благоевград")));
            Assert.That(information.DayOfBirth, Is.EqualTo(new DateTime(2075, 12, 1)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград"));
        }

        [Test]

        public void ExtractInformationShouldWorkCorrectlyForOtherRegion()
        {
            //Arrange
            var infromationExtractor = new EgnInformationExtractor(new EgnValidator());

            //Act
            var information = infromationExtractor.Extract("0405059500");

            //Assert
            Assert.That(information.PlaceOfBirth, Is.EqualTo(("Друг /Неизвестен")));
            Assert.That(information.DayOfBirth, Is.EqualTo(new DateTime(1904, 5, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 5 май 1904 г. в регион Друг /Неизвестен"));
        }

        [Test]
        public void ExtractShouldThrowArgumentNullExceptionWhenGivenNull()
        {
            //Arrange
            var infromationExtractor = new EgnInformationExtractor(new EgnValidator());

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                infromationExtractor.Extract(null);
            }
            );
        }

        [Test]
        public void ExtractShouldThrowArgumentExceptionWhenGivenInvalidEgn()
        {
            //Arrangez
            var infromationExtractor = new EgnInformationExtractor(new AlwaysInvalidEgnValidator());

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                infromationExtractor.Extract("0000000000");
            }
            );
        }

    }

    internal class AlwaysInvalidEgnValidator : IEgnValidator
    {
        public bool IsValid(string egn)
        {
            return false;
        }
    }
}
