using NUnit.Framework;
using Ohce;
using System;
using System.IO;

namespace OhceTest
{
    [TestFixture]
    public class OhceShow
    {
        [Test]
        [TestCase(21, "pedro", "¡Buenas noches pedro!")]
        [TestCase(18, "elahe", "¡Buenas tardes elahe!")]
        public void OhceGreeterTest(int hour, string name, string expected)
        {
            var greeter = new Greeter(hour);
            var actual = greeter.getGreetingFor(name);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase("hola", "aloh")]
        [TestCase("oto", "oto\n¡Bonita palabra!")]
        public void OhceReponderTest(string input, string expected)
        {
            var res = new Responder();
            var actual = res.response(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(21, "pedro",new string[]{"hola", "oto", "!stop" }, "¡Buenas noches pedro!\nhola\naloh\noto\noto\n¡Bonita palabra!\n!stop\nAdios pedro")]
        public void OhceCompleteTest(int hour, string name, string[] input, string expected)
        {
            var greeter = new Greeter(hour);
            var message = greeter.getGreetingFor(name);
            var res = new Responder();
            foreach (var item in input)
            {
                message += "\n" + item;
                if (item == "!stop")
                {
                    message += "\n" + "Adios " + name;
                    break;
                } 
                message += "\n" + res.response(item);
            }

            var stringReader = new StringReader(message);
            Console.SetIn(stringReader);

            var actual = string.Empty;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                actual += line + "\n";
            }

            if (actual.Length > 0)
                actual = actual.Substring(0, actual.Length - 1);
            Assert.AreEqual(expected, actual);
        }

    }
}
