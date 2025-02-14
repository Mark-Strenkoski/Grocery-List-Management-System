using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strenkoski_Final
{
    internal class GroceryItem
    {
        string _Name;
        int _Quantity;
        string _Note;

        public GroceryItem()
        {
        }

        public string GetName()
        {
            return _Name;
        }
        public string GetNote()
        {
            return _Note;
        }
        public int GetQuantity()
        {
            return _Quantity;
        }
        private void SetName(string theName)
        {
            _Name = theName;
        }
        private void SetNote(string theNote)
        {
            _Note = theNote;
        }
        private bool SetQuantity(int theQuantity)
        {
            bool success;
            if (theQuantity > 0)
            {
                _Quantity = theQuantity;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }
        private string AskQuestion(string theQuestion, bool required)
        {
            bool error = false;
            string theAnswer;
            do
            {
                Console.WriteLine(theQuestion);
                theAnswer = Console.ReadLine();
                if ((theAnswer == "") && (required == true))
                {
                    error = true;
                    Console.WriteLine("You MUST enter some text!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
                else
                {
                    error = false;
                }
            } while (error == true);
            return theAnswer;
        }
        public void Display()
        {
            Console.WriteLine("Item Information:");
            Console.WriteLine();
            Console.WriteLine("Name: {0}", _Name);
            Console.WriteLine("Quantity Needed: {0}", _Quantity);
            Console.WriteLine("Note: {0}", _Note);
        }
        public void Setup()
        {
            string theName = AskQuestion("What item would you like to add to this list?", true);
            string theNote = AskQuestion("What note would you like to make?", false);
            int theQuantity;
            bool success;
            SetName(theName);
            SetNote(theNote);

            do
            {
                theQuantity = int.Parse(AskQuestion("How many would you like?", true));
                success = SetQuantity(theQuantity);
            } while (success == false);
        }

    }
}
