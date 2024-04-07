using System;
using Xunit;

// Add the missing code to Chicken and Eggs

// Chicken implements the IBird interface
// A Chicken lays an egg that will hatch into a new Chicken
// Eggs from other types of birds should hatch into a new bird of their parent type
// Hatching an egg for the second time throw a System.InvalidOperationException

namespace MyTestApp
{
    public interface IBird
    {
        Egg Lay();
    }

    public class Chicken : IBird
    {
        public Egg Lay()
        {
            return new Egg(() => new Chicken());
        }
    }

    public class Eagle : IBird
    {
        public Egg Lay()
        {
            return new Egg(() => new Eagle());
        }
    }

    public class Egg
    {
        private bool _isHatched;
        private readonly Func<IBird> _createBird;

        public Egg(Func<IBird> createBird)
        {
            _createBird = createBird;
        }

        public IBird Hatch()
        {
            if (_isHatched)
                throw new InvalidOperationException();

            _isHatched = true;
            return _createBird();
        }
    }


    public class Main
    {
        [Fact]
        public void CheckIfChickenImplementIBird()
        {
            var chicken = new Chicken();
            var bird =  (IBird) chicken;
            Assert.NotNull(bird);
        }

        [Fact]
        public void CheckIfChickenMakeChicken()
        {
            var chicken = new Chicken();
            var egg = chicken.Lay();
            var childChicken = egg.Hatch();
            Assert.IsType<Chicken>(childChicken);
        }

        [Fact]
        public void TryToHatchSecondTime()
        {
            var chicken = new Chicken();
            var egg = chicken.Lay();
            egg.Hatch();

            Assert.Throws<InvalidOperationException>(() => egg.Hatch());
        }

        [Fact]
        public void EagleMakeEagle()
        {
            var eagle = new Eagle();
            var egg = eagle.Lay();
            var childEagle = egg.Hatch();
            Assert.IsType<Eagle>(childEagle);
        }
    }
}