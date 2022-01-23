using System;
using System.Collections.Generic;
using System.Text;

namespace Ohce
{
    public class Responder
    {  

        public Responder( )
        { 
        }
        public string response(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            var lineReversed = new string(charArray);   
            if (input.Equals(lineReversed))
            {
                lineReversed += "\n¡Bonita palabra!";
            }
            return lineReversed;
        }
    }
}
