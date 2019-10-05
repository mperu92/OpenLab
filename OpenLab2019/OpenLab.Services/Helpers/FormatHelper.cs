using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenLab.Services.Helpers
{
    public class AcctNumberFormat : IFormatProvider, ICustomFormatter
    {
        private const int ACCT_LENGTH = 12;

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
                throw new ArgumentNullException($"{fmt} or {arg} are null");

            // Provide default formatting if arg is not an Int64.
            if (arg.GetType() != typeof(Int64))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{fmt}' is invalid.", e);
                }

            if (fmt == null)
                throw new ArgumentNullException($"{fmt} or {arg} are null");

            // Provide default formatting for unsupported format strings.
            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "H" || ufmt == "I"))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{fmt}' is invalid.", e);
                }

            // Convert argument to a string.
            string result = arg.ToString();

            // If account number is less than 12 characters, pad with leading zeroes.
            if (result.Length < ACCT_LENGTH)
                result = result.PadLeft(ACCT_LENGTH, '0');
            // If account number is more than 12 characters, truncate to 12 characters.
            if (result.Length > ACCT_LENGTH)
                result = result.Substring(0, ACCT_LENGTH);

            if (ufmt == "I")                    // Integer-only format. 
                return result;
            // Add hyphens for H format specifier.
            else                                         // Hyphenated format.
                return result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return string.Empty;
        }
    }
}
