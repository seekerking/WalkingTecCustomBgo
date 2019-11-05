using System.Text.RegularExpressions;

namespace AppSys.Framework.Validator
{
    public class IpValidator : IDataValidator
    {
        public bool Verify(object value)
        {
            return Verify(value?.ToString());
        }

        public bool Verify(string value)
        {
            Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (!string.IsNullOrWhiteSpace(value) && validipregex.IsMatch(value)) ? true : false;
        }
    }
}
