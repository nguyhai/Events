using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {

        static int score = 0;

        static void Main(string[] args)
        {
            // Creating the shooter object
            Shooter shooter = new Shooter();

            // Now we need a method that will subscribe. We can subscribe multiple methods. 
            shooter.KillingCompleted += KilledEnemy; // Delegate Chain, we are adding methods to a given delegate. There is no relation between KilledEnemy method and shooter object. 
            shooter.KillingCompleted += AddScore;
            // Invoke the method that contains the event.
            shooter.OnShoot();
        }

        // Create a method that will subscribe. This method needs to have the same signature as our delegate
        public static void KilledEnemy(object sender, EventArgs e)
        {
            Console.WriteLine("I killed an enemy!");
            Console.WriteLine($"My score is now {score}");
        }

        public static void AddScore(object sender, EventArgs e)
        {
            score++;
        }

    }

    internal class Shooter
    {
        private Random rng = new Random();

        // Now we need to create the event
        // All events have the SAME signature. They take two arguments, Object and Event Args
        // By convention, we use the name of the action and the "handler" word at the end.
        // The arguments are object sender (the one who raises the event) and the EventArgs where we can just use "e"
        public delegate void KillingHandler(object sender, EventArgs e);

        // Now we have to create an event of the type of the delegate
        public event KillingHandler KillingCompleted;

        // Now we need a method that will invoke this event
        public void OnShoot()
        {
            while (true) // Infinite loop
            {
                if (rng.Next(0,100) % 2 == 0) // 50% chance to kill
                {
                    if (KillingCompleted != null) // Everytime we call on events, we need to check to see if the event is empty. If NOT EMPTY (then it has some subscribers), then INVOKE
                    {
                        // Raising the event using Invoke. In here we put the signature of our delegate. Who is our sender, who is raising the event? The Shooter class. 
                        // We will need to use the this keyword, then we can pass empty EventArgs for now
                        KillingCompleted.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        Console.WriteLine("I missed!");
                    }
                }
            }
        }





    }


}
