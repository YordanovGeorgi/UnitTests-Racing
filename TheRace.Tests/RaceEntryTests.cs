using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructorUnitCarShouldCreateCarCorectly()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);

            Assert.AreEqual("A", car.Model);
            Assert.AreEqual(10, car.HorsePower);
            Assert.AreEqual(10.5, car.CubicCentimeters);
        }

        [Test]
        public void TestConstructorUnitDriveShouldCreateDriverCorectly()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);
            UnitDriver driver = new UnitDriver("B", car);

            Assert.AreEqual("B", driver.Name);
            Assert.AreEqual("A", driver.Car.Model);
            Assert.AreEqual(10, driver.Car.HorsePower);
            Assert.AreEqual(10.5, driver.Car.CubicCentimeters);
        }

        [Test]
        public void TestConstructorUnitDriveShouldThrowArgumentNullExceptionIfNameNull()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, car));
        }

        [Test]
        public void TestConstructorRaceEntryCreateEmptyCollection()
        {
            RaceEntry race = new RaceEntry();

            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void TestMethodAddShouldThrowInvalidOperationExceptionIfDriverNull()
        {

            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void TestMethodAddShouldThrowInvalidOperationExceptionIfDriverAlreadyInCollection()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);

            RaceEntry race = new RaceEntry();
            race.AddDriver(new UnitDriver("A", car));
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(new UnitDriver("A", car)));
        }

        [Test]
        public void TestMethodAddIncreaseCollectionCount()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);

            RaceEntry race = new RaceEntry();
            race.AddDriver(new UnitDriver("A", car));
            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void TestMethodAddShouldReturnCorectMessage()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);

            RaceEntry race = new RaceEntry();
            string returnedMessage = race.AddDriver(new UnitDriver("A", car));
            string expectedMessage = "Driver A added in race.";
            Assert.AreEqual(expectedMessage, returnedMessage);
        }

        [Test]
        public void TestMethodCalculateAverageHorsePowerShouldThrowInvalidOperationExceptionIfDriverCountLessThanDefaultMin()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);

            RaceEntry race = new RaceEntry();
            race.AddDriver(new UnitDriver("A", car));
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void TestMethodAddShouldReturnCorectAverageHorsePower()
        {
            UnitCar car = new UnitCar("A", 10, 10.5);
            UnitCar carTwo = new UnitCar("B", 10, 10.5);


            RaceEntry race = new RaceEntry();
            race.AddDriver(new UnitDriver("A", car));
            race.AddDriver(new UnitDriver("B", carTwo));

            Assert.AreEqual(10, race.CalculateAverageHorsePower());
        }
    }
}