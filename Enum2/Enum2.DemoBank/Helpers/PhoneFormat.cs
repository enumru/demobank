using System.Text.RegularExpressions;

namespace Enum2.DemoBank.Helpers
{
    public static class PhoneFormat
    {
        public static string ClearPhone(this string phone)
        {
            phone = Regex.Replace(phone, "[^\\d]", "");
            return phone;
        }

        public static string FormatPhone(this string phone)
        {
            phone = phone.ClearPhone();

            if (phone.Length == 11 && (phone[0] == '7' || phone[0] == '8')) // russia
            {
                phone = string.Format("+{0} ({1}) {2}-{3}",
                    phone.Substring(0, 1), phone.Substring(1, 3), phone.Substring(4, 3), phone.Substring(7, 4));
            }
            else if (phone.Length == 10 && phone.Substring(0, 3) == "375") // belorus
            {
                phone = string.Format("+{0} ({1}) {2}",
                    phone.Substring(0, 3), phone.Substring(3, 3), phone.Substring(6, 4));
            }
            else if (phone.Length == 10 && phone.Substring(0, 3) == "380") // ukraine
            {
                phone = string.Format("+{0} ({1}) {2}",
                    phone.Substring(0, 3), phone.Substring(3, 3), phone.Substring(6, 4));
            }
            else if (phone.Length == 12 && phone.Substring(0, 3) == "998") // uzbekistan
            {
                phone = string.Format("+{0} ({1}) {2}-{3}",
                    phone.Substring(0, 3), phone.Substring(3, 2), phone.Substring(5, 3), phone.Substring(8, 4));
            }
            else if (phone.Length == 8 && phone[0] == '7') // kaz
            {
                phone = string.Format("+{0} ({1}) {2}",
                    phone.Substring(0, 1), phone.Substring(1, 3), phone.Substring(4, 4));
            }

            return phone;
        }

        public static string FormatPhoneIfNot(this string phone)
        {
            return Regex.IsMatch(phone, "[^\\d]") ? phone : phone.FormatPhone();
        }

        public static bool IsValid(this string phone)
        {
            phone = phone.ClearPhone();
            var isValid = phone.Length >= 8;
            return isValid;
        }
    }
}