using System;
using System.Threading;

namespace Events
{
    public class Shooter
    {
        private Random rng = new Random();

        // Now we need to create the event
        // All events have the SAME signature. They take two arguments, Object and Event Args
        // By convention, we use the name of the action and the "handler" word at the end.
        // The arguments are object sender (the one who raises the event) and the EventArgs where we can just use "e"
        public delegate void ShootingHandler(object sender, ShotsFiredEventArgs e);

        // Now we have to create an event of the type of the delegate
        public event EventHandler<ShotsFiredEventArgs> ShotsFired;

        // Add a name property

        public string Name { get; set; } = "Billy";



        // Now we need a method that will invoke this event
        public void OnShoot()
        {
            while (true) // Infinite loop
            {
                if (rng.Next(0,100) % 2 == 0) // 50% chance to kill
                {
                    if (ShotsFired != null) // Everytime we call on events, we need to check to see if the event is empty. If NOT EMPTY (then it has some subscribers), then INVOKE
                    {
                        // Raising the event using Invoke. In here we put the signature of our delegate. Who is our sender, who is raising the event? The Shooter class. 
                        // We will need to use the this keyword, then we can pass empty EventArgs for now
                        ShotsFired.Invoke(this, new ShotsFiredEventArgs() {TimeOfKill = DateTime.Now}); // "this" is what sends information about the object that raises the event. If we put the name property here like above, our subscriber methods will have access to them
                    }

                }
                else
                {
                    Console.WriteLine("I missed!");
                }

                Thread.Sleep(500);
            }
        }





    }


}
