using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace CustomAttributesExample.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var properties = GetPropertiesOfOrderObject();
            OutputAttributeInformationOfProperties(properties);
            
            while(true)
            {
                var name = AskForPropertyName();
                var propertyValue = GetPropertyValueFromName(name);
                Console.WriteLine(propertyValue);
                Console.WriteLine(String.Empty);
            }
        }

        private static string AskForPropertyName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the property to discover its value:");
            return Console.ReadLine();
        }

        private static string GetPropertyValueFromName(string name)
        {
            var properties = GetPropertiesOfOrderObject();
            var order = OrderFactory.GetOrder();

            foreach (var prop in properties)
            {
                var attribute = (MergeableAttribute[])prop.GetCustomAttributes(typeof(MergeableAttribute), false);

                if (attribute[0].Name == name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return prop.GetValue(order, new object[0]).ToString();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return "Could not find a Property with this Merge Attribute Name on the Mock Order";
        }

        private static IEnumerable<PropertyInfo> GetPropertiesOfOrderObject()
        {
            return typeof(Order)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.IsDefined(typeof(MergeableAttribute), false));
        }

        private static void OutputAttributeInformationOfProperties(IEnumerable<PropertyInfo> properties)
        {
            Console.WriteLine("Mock Order Object Loaded...");
            Console.WriteLine("Order Properties marked with the Merge Attribute:");
            Console.WriteLine(String.Empty);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Note only these Order Properties are available - and not any others");
            Console.WriteLine("See Order.cs for details");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Empty);

            foreach (var prop in properties)
            {
                var attribute = (MergeableAttribute[])prop.GetCustomAttributes(typeof(MergeableAttribute), false);

                Console.Write(attribute[0].Name);
                Console.Write(" - ");
                Console.WriteLine(attribute[0].Description);
                Console.WriteLine(String.Empty);
            }

            Console.WriteLine(String.Empty);
        }
    }
}
