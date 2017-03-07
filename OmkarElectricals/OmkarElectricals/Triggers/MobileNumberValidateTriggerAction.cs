using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace OmkarElectricals.Triggers
{
    public class MobileNumberValidateTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var result = CheckIsValidatePhoneNumber(sender.Text);
            sender.TextColor = result ? Color.Blue : Color.Red;
        }

        private bool CheckIsValidatePhoneNumber(string mobileNumber)
        {
            try
            {
                mobileNumber = FormatMobilePhoneNumber(mobileNumber);
                var mTmpNumber = int.Parse(mobileNumber);
                return CheckIsMobilePhoneNumber(mTmpNumber);
            }
            catch (Exception s)
            {
                Debug.WriteLine($"{mobileNumber} is not a phone number with error: {s.Message}");
                return false;
            }
        }

        private static bool CheckIsMobilePhoneNumber(int mTmpNumber)
        {
            if (860000000 <= mTmpNumber && mTmpNumber <= 1999999999)
            {
                Debug.WriteLine($"{mTmpNumber} is a phone number");
                return true;
            }
            Debug.WriteLine($"{mTmpNumber} isn't a phone number");
            return false;
        }

        private static string FormatMobilePhoneNumber(string mobileNumber)
        {
            var result = mobileNumber;
            result = result.Replace("+", string.Empty);
            result = result.Replace("(", string.Empty);
            result = result.Replace(")", string.Empty);
            result = result.Replace(" ", string.Empty);
            result = result.Replace("-", string.Empty);
            result = result.Replace("*", string.Empty);
            result = result.Replace("#", string.Empty);
            if (result.StartsWith("+91"))
            {
                result = result.Replace("+91", string.Empty);
            }
            return result;
        }
    }
}
