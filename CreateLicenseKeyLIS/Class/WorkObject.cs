using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

// --------------------------------------------------------------------------------------------------------

// 08/2008
// This application demonstrates a technique for creating a form to capture a user's license
// key. It validates the key, and then stores it in the registry.

// It also shows how to encrypt that key before storing it, and then decrypting it before using it
// You may modify and use this code in your applications.  

// If you have any questions, please email me at grant@serialkeymaker.com

// Grant Porteous
// http://www.serialkeymaker.com
// Serial Key Maker is an Effortless Software Licensing Solution for .Net developers

// --------------------------------------------------------------------------------------------------------


namespace CreateLicenseKeyLIS
{
    class WorkObject
    {

        public enum DateInterval { Second, Minute, Hour, Day, Week, Month, Quarter, Year }

        private const string cstr_LICENSE_KEY = "LicenseKey";
        private const string Ngayhet = "Date";
        private static string m_strLocalPassword = "MyL0c@lpa$$w0rd!";

        // ----------------------------------------------------------------------------------------------------------------------
        // ----       This sample is adapted from code I found at:
        // ----       http://www.obviex.com/samples/Encryption.aspx
        // ----------------------------------------------------------------------------------------------------------------------
        // ---- DECLARE SOME CONSTANTS
        private static string m_strPassPhrase = "MyPriv@Password!$$";

        private static string m_strHashAlgorithm = "MD5";

        private static int m_strPasswordIterations = 2;

        // --- can be any number
        private static string m_strInitVector = "@1B2c3D4e5F6g7H8";

        private static int m_intKeySize = 256;

        internal static string Reg_Section
        {
            get
            {
                return "LIS";
            }
        }

        internal static string Reg_Folder
        {
            get
            {
                return "XETNGHIEM";
            }
        }

        public static long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new TimeSpan(EndDate.Ticks - StartDate.Ticks);

            switch (Interval)
            {
                case DateInterval.Day: lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Hour: lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Minute: lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Month: lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter: lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Second: lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case DateInterval.Week: lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case DateInterval.Year: lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            } return (lngDateDiffValue);
        }//end of DateDiff

        // --- can be 192 or 128
        internal static string EncryptMD5(string plainText, string p_strSaltValue,DateTime ngayhethan)
        {
            string strReturn = String.Empty;
            //  Convert strings into byte arrays.
            //  Let us assume that strings only contain ASCII codes.
            //  If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            //  encoding.
            try
            {
                byte[] initVectorBytes;
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector);
                byte[] saltValueBytes;
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(p_strSaltValue) ;
                //  Convert our plaintext into a byte array.
                //  Let us assume that plaintext contains UTF8-encoded characters.
                byte[] plainTextBytes;
                plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                
                //  First, we must create a password, from which the key will be derived.
                //  This password will be generated from the specified passphrase and 
                //  salt value. The password will be created using the specified hash 
                //  algorithm. Password creation can be done in several iterations.
                System.Security.Cryptography.PasswordDeriveBytes password;
                password = new System.Security.Cryptography.PasswordDeriveBytes(m_strPassPhrase,
                    saltValueBytes, m_strHashAlgorithm, m_strPasswordIterations);
                // Dim password As Rfc2898DeriveBytes
                // password = New Rfc2898DeriveBytes(m_strPassPhrase, _
                //                                 saltValueBytes, _
                //                                 m_strPasswordIterations)
                //  Use the password to generate pseudo-random bytes for the encryption
                //  key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes;
                int intKeySize = 0;
                intKeySize = ((int)((m_intKeySize / 8)));
                keyBytes = password.GetBytes(intKeySize);
                //  Create uninitialized Rijndael encryption object.
                System.Security.Cryptography.RijndaelManaged symmetricKey;
                symmetricKey = new System.Security.Cryptography.RijndaelManaged();
                //  It is reasonable to set encryption mode to Cipher Block Chaining
                //  (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC;
                // symmetricKey.Padding = PaddingMode.Zeros
                //  Generate encryptor from the existing key bytes and initialization 
                //  vector. Key size will be defined based on the number of the key 
                //  bytes.
                System.Security.Cryptography.ICryptoTransform encryptor;
                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                //  Define memory stream which will be used to hold encrypted data.
                System.IO.MemoryStream memoryStream;
                memoryStream = new System.IO.MemoryStream();
                //  Define cryptographic stream (always use Write mode for encryption).
                System.Security.Cryptography.CryptoStream cryptoStream;
                cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, encryptor, System.Security.Cryptography.CryptoStreamMode.Write);
                //  Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                //  Finish encrypting.
                cryptoStream.FlushFinalBlock();
                //  Convert our encrypted data from a memory stream into a byte array.
                byte[] cipherTextBytes;
                cipherTextBytes = memoryStream.ToArray();
                //  Close both streams.
                memoryStream.Close();
                cryptoStream.Close();
                //  Convert encrypted data into a base64-encoded string.
                string cipherText;
                cipherText = Convert.ToBase64String(cipherTextBytes);
                //  Return encrypted string.
                strReturn = cipherText;
            }
            catch (Exception ex)
            {
                strReturn = null;
            }
            return strReturn;
        }

        internal static string DecryptMD5(string cipherText, string p_strSaltValue)
        {
            string strReturn = String.Empty;
            //  Convert strings defining encryption key characteristics into byte
            //  arrays. Let us assume that strings only contain ASCII codes.
            //  If strings include Unicode characters, use Unicode, UTF7, or UTF8
            //  encoding.
            try
            {
                byte[] initVectorBytes;
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector);
                byte[] saltValueBytes;
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(p_strSaltValue);
                //  Convert our ciphertext into a byte array.
                byte[] cipherTextBytes;
                cipherTextBytes = Convert.FromBase64String(cipherText);
                //  First, we must create a password, from which the key will be 
                //  derived. This password will be generated from the specified 
                //  passphrase and salt value. The password will be created using
                //  the specified hash algorithm. Password creation can be done in
                //  several iterations.
                System.Security.Cryptography.PasswordDeriveBytes password;
                // Dim password As Rfc2898DeriveBytes
                // password = New Rfc2898DeriveBytes(m_strPassPhrase, _
                //                                 saltValueBytes, _
                //                                 m_strPasswordIterations)
                password = new System.Security.Cryptography.PasswordDeriveBytes(m_strPassPhrase, saltValueBytes, m_strHashAlgorithm, m_strPasswordIterations);
                //  Use the password to generate pseudo-random bytes for the encryption
                //  key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes;
                int intKeySize;
                intKeySize = ((int)((m_intKeySize / 8)));
                keyBytes = password.GetBytes(intKeySize);
                //  Create uninitialized Rijndael encryption object.
                System.Security.Cryptography.RijndaelManaged symmetricKey;
                symmetricKey = new System.Security.Cryptography.RijndaelManaged();
                //  It is reasonable to set encryption mode to Cipher Block Chaining
                //  (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC;
                // symmetricKey.Padding = PaddingMode.Zeros
                //  Generate decryptor from the existing key bytes and initialization 
                //  vector. Key size will be defined based on the number of the key 
                //  bytes.
                System.Security.Cryptography.ICryptoTransform decryptor;
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                //  Define memory stream which will be used to hold encrypted data.
                System.IO.MemoryStream memoryStream;
                memoryStream = new System.IO.MemoryStream(cipherTextBytes);
                //  Define memory stream which will be used to hold encrypted data.
                System.Security.Cryptography.CryptoStream cryptoStream;
                cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, decryptor, System.Security.Cryptography.CryptoStreamMode.Read);
                //  Since at this point we don't know what the size of decrypted data
                //  will be, allocate the buffer long enough to hold ciphertext;
                //  plaintext is never longer than ciphertext.
                byte[] plainTextBytes;

                plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount;

                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                //  Close both streams.
                memoryStream.Close();
                cryptoStream.Close();
                //  Convert decrypted data into a string. 
                //  Let us assume that the original plaintext string was UTF8-encoded.
                string plainText;
                plainText = System.Text.Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                //  Return decrypted string.
                strReturn = plainText;
            }
            catch (Exception ex)
            {
                strReturn = null;
            }
            return strReturn;
        }

        internal static bool SaveLicenseKeyToReg(string p_strLicenseKey,DateTime ngayhethan)
        {
            bool blnReturn;
            string strEncryptedKey = String.Empty;
            string stringExpiredate = String.Empty;
            string ngayhh = ngayhethan.ToString("dd/MM/yyy");
            try
            {
                strEncryptedKey = EncryptMD5(p_strLicenseKey, m_strLocalPassword, ngayhethan);
                stringExpiredate = EncryptMD5(ngayhh, m_strLocalPassword, ngayhethan);
                Interaction.SaveSetting(Reg_Folder, Reg_Section, cstr_LICENSE_KEY, strEncryptedKey);
                Interaction.SaveSetting(Reg_Folder, Reg_Section, Ngayhet, stringExpiredate);
           
                blnReturn = true;
            }
            catch (Exception ex)
            {
                blnReturn = false;
            }
            return blnReturn;
        }

        internal static string GetLicenseKeyFromRegistry()
        {
            string strEncryptedKey = String.Empty;
            string strLicenseKey = String.Empty;
            if (!string.IsNullOrEmpty(Reg_Folder))
            {
                strEncryptedKey = Interaction.GetSetting(Reg_Folder, Reg_Section, cstr_LICENSE_KEY, String.Empty);
                // --- If there is a license key stored in the registry, it will be encrypted.
                // --- try decrypt it
                if (!string.IsNullOrEmpty(strEncryptedKey))
                {
                    strLicenseKey = DecryptMD5(strEncryptedKey, m_strLocalPassword);
                }
            }
            else
            {
                // todo Deal with errors
            }
            return strLicenseKey;
        }

        
        internal static KeyDetails ValidateKey(string p_strUnEncryptedKey)
        {
            KeyDetails objReturn = null;

            //'Validate that key is valid
        //'---- since this is a demonstration of this technique, we will just have a simple 
        //'---- key to show the principle.  In reality you will use a more sophisticated
        //'---- system to generate keys that embed various details into the key that allows
        //'---- you to programatically lock out features, disable portions of the software (or all of it).
        //'----
        //'---- Such is system is what Serial Key Maker is:  http://www.serialkeymaker.com
        //'---- This is where you would plug in a call to the something like the Serial Key Maker API
        //'---- to validate that the license key supplied is actually a valid key.

        //'---- So, for now, if the key is a string 20 characters long, then consider it a valid unlimited version
        //'---- else if it is a number 20 digits long then it is a valid demo version


            objReturn = new KeyDetails();
            if ((!string.IsNullOrEmpty(p_strUnEncryptedKey)
                        && ((p_strUnEncryptedKey.Length == 20)
                        && !Microsoft.VisualBasic.Information.IsNumeric(p_strUnEncryptedKey))))
            {
                // With...
                objReturn.IsValid = true;
                objReturn.DateCreated = DateAndTime.Now;
                objReturn.Expires = false;
                objReturn.DateValidThrough = new DateTime(2020, 12, 31);
            }
            else if ((!string.IsNullOrEmpty(p_strUnEncryptedKey)
                        && ((p_strUnEncryptedKey.Length == 20)
                        && Microsoft.VisualBasic.Information.IsNumeric(p_strUnEncryptedKey))))
            {
                // With...
                objReturn.IsValid = true;
                objReturn.DateValidThrough = new DateTime(2010, 12, 31);
                objReturn.Expires = true;
                objReturn.DateCreated = DateAndTime.Now;
            }
            else
            {
                // With...
                objReturn.IsValid = false;
                objReturn.DateCreated = DateAndTime.Now;
                objReturn.Expires = true;
            }
            return objReturn;


        }

        internal static string StripHyphens(string p_strString)
        {
            string strReturn = String.Empty;
            try
            {
                if (!string.IsNullOrEmpty(p_strString))
                {
                    strReturn = p_strString.Replace("-", "");
                }
            }
            catch (Exception ex)
            {
                strReturn = p_strString;
            }
            return strReturn;
        }


    }

    
    

}
