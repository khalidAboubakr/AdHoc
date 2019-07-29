using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdHocs.Core.Domain.Util
{
    internal static class Constants
    {
        public static readonly int MaxStringSize = 50; //size as converting to fixed string length
        public const int MaxStringLength = 50;

        public const int MaxSelectRecords = 5;

        public const double Epsilon = 0.000001;

        public const int IntStringLen = 11; //if you change this, will have to change the tests address constants
        public const int DoubleStringLen = 11;

        public const int DefaultLen = 11;//default len if not specified

        public const int NullAsInt = -12345678;
        public const double NullAsDouble = -1234567.8;
        public const String NullAsString = "";
    }
}
