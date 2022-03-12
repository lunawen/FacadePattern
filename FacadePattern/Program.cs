using BallOfMud.Services;

/*
 * Without using Facade

BigClass bigClass = new BigClass();
            
bigClass.SetValueI(3);
            
bigClass.IncrementI();
bigClass.IncrementI();
bigClass.IncrementI();
            
bigClass.DecrememntI();

Console.WriteLine($"Final Number : {bigClass.GetValueB()}");
 */


// Using Facade

BigClassFacade bigClass = new BigClassFacade();

bigClass.IncreaseBy(50);
bigClass.DecreaseBy(20);

Console.WriteLine($"Final Number : {bigClass.GetCurrentValue()}");