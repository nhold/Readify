using System;
using System.ComponentModel;

namespace TRS.ConsoleApp.Commands
{
    /// <summary>
    /// A class that will help extract typed arguments from an array of strings.
    ///
    /// All it really does is easily cast to a built in type \ enum safely and gives back in a typed Tuple.
    /// it's used to do the Place command to try and get valid arguments out in an easier to read manner.
    /// </summary>
    public static class ArgumentHelper
    {
        public static Tuple<T1, T2> GetArguments<T1, T2>(string[] arguments)
            where T1 : struct, IConvertible
            where T2 : struct, IConvertible
        {
            if (arguments.Length == 2)
            {
                T1 first = default;
                T2 second = default;

                try
                {
                    first = (T1)TypeDescriptor.GetConverter(first).ConvertFrom(arguments[0]);
                    second = (T2)TypeDescriptor.GetConverter(second).ConvertFrom(arguments[1]);
                }
                catch (Exception)
                {
                    return null;
                }

                return new Tuple<T1, T2>(first, second);
            }

            return null;
        }

        public static Tuple<T1, T2, T3> GetArguments<T1, T2, T3>(string[] splitInput)
            where T1 : struct, IConvertible
            where T2 : struct, IConvertible
            where T3 : struct, IConvertible
        {
            if (splitInput.Length == 3)
            {
                T1 first = default;
                T2 second = default;
                T3 third = default;

                try
                {
                    first = (T1)TypeDescriptor.GetConverter(first).ConvertFrom(splitInput[0]);
                    second = (T2)TypeDescriptor.GetConverter(second).ConvertFrom(splitInput[1]);
                    third = (T3)TypeDescriptor.GetConverter(third).ConvertFrom(splitInput[2]);
                }
                catch (Exception)
                {
                    return null;
                }

                return new Tuple<T1, T2, T3>(first, second, third);
            }

            return null;
        }
    }
}