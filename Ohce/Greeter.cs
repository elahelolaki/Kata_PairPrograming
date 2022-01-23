using System;

namespace Ohce
{
    public class Greeter
    {
        public int Hour { get; set; }

        public Greeter(int hour)
        {
            Hour = hour;
        }

        public string getGreetingFor(string name)
        {
            string greeting = "";
            if (Hour >= 20 || Hour <= 6)
            {
                greeting = "¡Buenas noches " + name + "!";
            }
            else if (Hour > 6 && Hour < 12)
            {
                greeting = "¡Buenos días " + name + "!";
            }
            else
            {
                greeting = "¡Buenas tardes " + name + "!";
            }
            return greeting;

        }
    }
}
