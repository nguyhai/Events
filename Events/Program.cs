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
            shooter.ShotsFired += KilledEnemy; // Delegate Chain, we are adding methods to a given delegate. There is no relation between KilledEnemy method and shooter object. 
            shooter.ShotsFired += AddScore;
            // Invoke the method that contains the event.
            shooter.OnShoot();
        }

        // Create a method that will subscribe. This method needs to have the same signature as our delegate
        public static void KilledEnemy(object sender, ShotsFiredEventArgs e)
        {
            var tempSender = sender as Shooter; // This transforms our sender object into Shooter
            
            Console.WriteLine("I killed an enemy!");
            Console.WriteLine($"Time of kill is {e.TimeOfKill}");
            Console.WriteLine($"My score is now {score} by {tempSender.Name}");
        }

        public static void AddScore(object sender, EventArgs e)
        {
            score++;
        }

    }


}
