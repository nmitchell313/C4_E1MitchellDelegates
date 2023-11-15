//Nicholas Mitchell nmitchell11@cnm.edu
//Delegates Demo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace MitchellDelegatesDemo
{
    internal class Program
    {
        //Delegate signature is return string, no arguments
        delegate void DispStrDelegate(string param);

        static void Main(string[] args)
        {
            //Get a line of text to convert
            Console.Write("Please enter some text: ");
            String text = Console.ReadLine();

            //Instantiate three delegate objects            
            DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
            DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
            DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

            //Call them one after the other
            saying1(text);
            saying2(text);
            saying3(text);

            //Get another text line
            Console.Write("Please enter some text: ");
            text = Console.ReadLine();

            //Make a new delegate object and concatenate delegates
            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += new DispStrDelegate(LowerCased);
            sayings += new DispStrDelegate(Console.WriteLine);

            //Call the one delegate and run all three methods
            Console.WriteLine("Running multi cast directly: ");
            sayings(text);

            //Pass delegate as a method argument
            Console.WriteLine("Running by passing delegate to another method: ");
            RunMyDelegate(sayings, text);

            //Create and run a lambda expression
            Console.WriteLine("Running by passing in a lambda expression: ");
            RunMyDelegate((string t) => { Console.WriteLine("Lambda: " + t); }, text);

            //Remove the type and let it be infered
            Console.WriteLine("Lambda without type: ");
            RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

            //Remove the parenthesis
            Console.WriteLine("Lambda without parenthesis: ");
            RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);

            //Add a lambda expression to our delegate
            sayings += t => { Console.WriteLine("Lambda3: " + t); };
            Console.WriteLine("Three Delegates and a lambda: ");
            RunMyDelegate(sayings, text);


        }

        // Method that capatilizes a string.
        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capatilized --> " + text.ToUpper());
        }

        // Method that lower cases a string.
        static void LowerCased(string text)
        {
            Console.WriteLine("Your input lower cased --> " + text.ToLower());
        }

        // Method that takes a delegate as an argument
        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }


    }
}
