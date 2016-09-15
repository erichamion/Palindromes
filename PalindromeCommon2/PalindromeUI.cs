﻿using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    public class PalindromeUI
    {
        //public delegate AbstractValueSupplier<long> ValueSupplierCreator(int numDigits);
        

        //private readonly IValueFinderFactory _finderFactory;
        //private readonly ISingleParameterValueSupplierFactory _supplierFactory;
        private readonly IValueFinderFactory _finderFactory;


        
        public PalindromeUI(IValueFinderFactory finderFactory)
        {
            //_finderFactory = finderFactory;
            //_supplierCreator = supplierCreator;
            _finderFactory = finderFactory;
        }

        public void RunUI()
        {
            int digits;
            do
            {
                digits = -1;
                bool isValid;
                do
                {
                    Console.WriteLine("How many digits are each factor (0 to quit)?");
                    Console.Write(" > ");
                    isValid = int.TryParse(Console.ReadLine(), out digits);
                    if (!isValid || digits < 0)
                    {
                        Console.WriteLine("Please enter an integer between 1 and 9, inclusive, or 0 to quit.\n");
                    }
                } while (!isValid || digits < 0);

                if (digits > 0)
                {
                    IValueFinder finder = _finderFactory.CreateValueFinder(digits);
                    Console.WriteLine(finder.FindValue());
                    Console.WriteLine("Press a key...");
                    Console.ReadKey(true);
                    Console.WriteLine();
                }
            } while (digits != 0);
        }
    }
}