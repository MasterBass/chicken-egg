using System;

// Add the missing code to Chicken and Eggs

// Chicken implements the IBird interface
// A Chicken lays an egg that will hatch into a new Chicken
// Eggs from other types of birds should hatch into a new bird of their parent type
// Hatching an egg for the second time throw a System.InvalidOperationException

namespace MyTestApp.Empty
{
    public interface IBird
    {
        Egg Lay();
    }

    public class Chicken 
    {
        public Chicken()
        {
        }
    }

    public class Egg
    {
        public Egg(Func<IBird> createBird)
        {
            throw new NotImplementedException("Waiting to be implemented.");
        }
        
        public IBird Hatch()
        {
            throw new NotImplementedException("Waiting to be implemented.");
        }
        
    }
    

    //var chicken = new Chicken();
    //var egg = chicken.Lay();
    //var childChicken = egg.Hatch();
    
}
