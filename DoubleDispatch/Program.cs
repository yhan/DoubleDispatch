namespace DoubleDispatch
{
    using System;

    using NFluent;

    using NUnit.Framework;

    [TestFixture]
    public class DoubleDispatchFailShould
    {
        [Test]
        public void Repro_fails()
        {
            Payment payment = new AliPay();
            Client microsoft = new Microsoft();
            var pay = payment.Pay(microsoft);

            Check.That(pay).IsEqualTo($"Pays Microsoft through Alibaba");
            Check.That(microsoft.Capital).IsEqualTo(10000);
        }

        [Test]
        public void Repro()
        {
            Asteroid theExplodingAsteroidRef = new ExplodingAsteroid();
            SpaceShip theApolloSpacecraftRef = new ApolloSpacecraft();
            var collideWith = theExplodingAsteroidRef.CollideWith(theApolloSpacecraftRef);

            Check.That(collideWith).IsEqualTo("ExplodingAsteroid hit a ApolloSpacecraft");
        }
    }

    public class SpaceShip
    {
        public virtual string GetShipType()
        {
            return "SpaceShip";
        }
    }

    public class ApolloSpacecraft : SpaceShip
    {
        public override string GetShipType()
        {
            return "ApolloSpacecraft";
        }
    }

    public class Asteroid
    {
        public virtual string CollideWith(SpaceShip ship)
        {
            return "Asteroid hit a SpaceShip";
        }
        public virtual string CollideWith(ApolloSpacecraft ship)
        {
           return "Asteroid hit an ApolloSpacecraft";
        }
    }

    public class ExplodingAsteroid : Asteroid
    {
        public override string CollideWith(SpaceShip ship)
        {
            return $"ExplodingAsteroid hit a {ship.GetShipType()}";
        }

        public override string CollideWith(ApolloSpacecraft ship)
        {
            return $"ExplodingAsteroid hit an {ship.GetShipType()}";
        }
    };
}