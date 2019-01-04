using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AspNetMvc.Infrastructure.SharedKernel
{
    public class Validation
    {

        #region[NumberPhone]

        //	1234567890
        //	123-456-7890
        //	123-456-7890 x1234
        //	123-456-7890 ext1234
        //	(123)-456-7890
        //  123.456.7890
        //  123 456 7890
        public static bool IsValidNumberPhone(String str)
        {
            if (Regex.IsMatch(str, @"^[0-9]{10}$")
                || Regex.IsMatch(str, @"^[0-9]{3}[\-]{1}[0-9]{3}[\-]{1}[0-9]{4}$")
                || Regex.IsMatch(str, @"^[0-9]{3}[\-]{1}[0-9]{3}[\-]{1}[0-9]{4}[\s]{1}[a-z]{1}[0-9]{4}$")
                || Regex.IsMatch(str, @"^[0-9]{3}[\-]{1}[0-9]{3}[\-]{1}[0-9]{4}[\s]{1}[a-z]{3}[0-9]{4}$")
                || Regex.IsMatch(str, @"^[\(]{1}[0-9]{3}[\)]{1}[\-]{1}[0-9]{3}[\-]{1}[0-9]{4}$")
                || Regex.IsMatch(str, @"^[0-9]{3}[\.]{1}[0-9]{3}[\.]{1}[0-9]{4}$")
                || Regex.IsMatch(str, @"^[0-9]{3}[\s]{1}[0-9]{3}[\s]{1}[0-9]{4}$"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check input(Số điện thoại VN bắt đầu với 0 hoặc +84)
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidPhoneVN(string phone)
        {
            phone = phone.Trim();
            if (Regex.IsMatch(phone, @"^0[0-9]{9,10}$") || Regex.IsMatch(phone, @"^(\+84)[0-9]{9,10}$"))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region[Email]
        public static bool isValidEmail(string str)
        {
            if (Regex.IsMatch(str, @"^([a-z0-9_\.\+-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check input(định dạng email)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmailBySystem(string email)
        {
            email = email.Trim();
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region[Letters]
        public static bool onlyLetters(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z]+$")) return true;
            return false;
        }

        public static bool onlyLettersAndWhiteSpace(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z\s]*$")) return true;
            return false;
        }


        public static bool onlyLettersAndNumbers(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z0-9]+$")) return true;
            return false;
        }

        public static bool onlyLettersAndNumbersAndUnderscore(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z0-9_]+$")) return true;
            return false;
        }
        #endregion

        #region[Number]

        /// <summary>
        /// Check input(số)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidNumberic(object value)
        {
            if (value == null || value is DateTime)
            {
                return false;
            }

            if (value is Int16 || value is Int32 || value is Int64 || value is Decimal || value is Single || value is Double || value is Boolean)
            {
                return true;
            }

            try
            {
                if (value is string)
                    Double.Parse(value as string);
                else
                    Double.Parse(value.ToString());
                return true;
            }
            catch { }
            return false;
        }
        public static bool isNumber(String str)
        {
            if (Regex.IsMatch(str, @"^[0-9]{1,}$")) return true;
            return false;
        }
        public static bool rangeLengthString(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z]{1,50}$")) return true;
            return false;
        }

        public static bool greaterLengthString(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z\s]{5,}$")) return true;
            return false;
        }
        #endregion

        #region[DataType]

        /// <summary>
        /// Check input(Long or Int)
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidInt16Int32Int64(object value)
        {
            if (value == null || value is DateTime)
            {
                return false;
            }

            if (value is Int16 || value is Int32 || value is Int64)
            {
                return true;
            }

            try
            {
                if (value is string)
                    long.Parse(value as string);
                else
                    long.Parse(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region[StringLength]
        /// <summary>
        /// Check input(Độ dài chuỗi)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsValidStringLength(String str, int length)
        {
            str = str.Trim();
            return str.Length <= length;
        }
        #endregion

        #region[DateTime]
        /// <summary>
        /// Check input(DateTime)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsValidDateTime(String str)
        {
            str = str.Trim();
            DateTime tempOut;
            return DateTime.TryParse(str, out tempOut);
        }
        #endregion

        #region[Others]

        /// <summary>
        /// Check input(Tên)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsValidCharName(String str)
        {
            str = str.Trim();
            return Regex.IsMatch(str, @"^[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+"
                                    + @"([\s]{1}[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+)+$");
        }
        //public static bool IsValidCharName(String str)
        //{
        //    return Regex.IsMatch(str, @"^[a-zA-Z]+([\s]{1}[a-zA-Z]+)+$");
        //}

        public static bool isValidId(String str)
        {
            if (Regex.IsMatch(str, @"^[0-9]{1,}$")) return true;
            return false;
        }

        public static bool isValidName(String str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z]+$")) return true;
            return false;
        }

        public static bool isValidAge(String str)
        {
            if (Regex.IsMatch(str, @"^\d+$")) return true;
            return false;
        }
        #endregion

    }
}
