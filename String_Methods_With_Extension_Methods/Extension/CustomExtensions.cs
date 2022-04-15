using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Methods_With_Extension_Methods.Extension
{
    public static class CustomExtensions
    {
        public static char[] ExToCharArray(this string str)
        {
            char[] strChar = new char[str.Length];
            for (int i = 0; i < strChar.Length; i++)
                strChar[i] = str[i];
            return strChar;
        }
        public static char[] ExToCharArray(this string str, int startIndex, int length)
        {
            char[] strChar;
            if (str.Length - startIndex > length)
            {
                strChar = new char[length];
                int j = 0;
                for (int i = startIndex; i < startIndex + length; i++)
                {
                    strChar[j] = str[i];
                    j++;
                }
            }
            else
                throw new Exception("length degeri ana metinin length inden büyük...");

            return strChar;
        }
        public static string ExSubstring(this string str, int startindex)
        {
            string donusDegeri = "";
            if (str.Length > startindex)
            {
                for (int i = startindex; i < str.Length; i++)
                {
                    donusDegeri += str[i];
                }
            }
            return donusDegeri;
        }
        public static string ExSubstring(this string str, int startindex, int length)
        {
            string donusDegeri = "";
            if (str.Length >= startindex + length)
            {
                for (int i = startindex; i < startindex + length; i++)
                {
                    donusDegeri += str[i];
                }
            }
            else
                throw new Exception("Girilen başlangıç degeri ve uzunluk metin boyutunu aşıyor.");
            return donusDegeri;
        }
        public static int ExIndexOf(this string str, char value)
        {
            int donecekIndex = -1;
            char[] dizi = ExToCharArray(str);
            for (int i = 0; i < dizi.Length; i++)
                if (value == dizi[i])
                {
                    donecekIndex = i;
                    break;
                }

            return donecekIndex;
        }
        public static int ExIndexOf(this string str, string value)
        {
            int donecekIndex = -1;
            for (int i = 0; i <= str.Length - value.Length; i++)
            {
                if (value == ExSubstring(str, i, value.Length))
                    donecekIndex = i;
            }

            return donecekIndex;
        }
        public static int ExIndexOf(this string str, char value, int startIndex)
        {
            int donecekIndex = -1;

            if (str.Length > startIndex)
            {
                char[] dizi = ExToCharArray(str);
                for (int i = startIndex; i < dizi.Length; i++)
                {
                    if (value == dizi[i])
                        donecekIndex = i;
                }
            }
            else
                throw new Exception("Gönderilen başlama indexi metnin boyutundan fazla...");

            return donecekIndex;
        }
        public static int ExIndexOf(this string str, string value, int startIndex)
        {
            int donecekIndex = -1;

            if (str.Length >= startIndex + value.Length)
            {
                string subdonenDeger = "";
                for (int i = startIndex; i <= str.Length - value.Length; i++)
                {
                    subdonenDeger = ExSubstring(str, i, value.Length);
                    if (value == subdonenDeger)
                        donecekIndex = i;
                }
            }

            return donecekIndex;
        }
        public static bool ExEndsWith(this string str, string value)
        {
            bool donecekDeger = false;
            if (str.Length >= value.Length)
            {
                string subDonen = ExSubstring(str, str.Length - value.Length);
                if (subDonen == value)
                    donecekDeger = true;
            }
            return donecekDeger;
        }
        public static int ExCompareTo(this string str, string strB)
        {
            int donecekDeger = 0;

            if (str.Length > strB.Length)
                strB = strB.PadRight(str.Length, ' ');
            else if (str.Length < strB.Length)
                str = str.PadRight(strB.Length, ' ');

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > strB[i])
                {
                    donecekDeger = 1;
                    break;
                }
                else if (str[i] < strB[i])
                {
                    donecekDeger = -1;
                    break;
                }
                else if (str[i] == strB[i])
                    donecekDeger = 0;
            }

            return donecekDeger;
        }
        public static bool ExStartWith(this string str, string value)
        {
            bool donecekDeger = false;
            if (str.Length >= value.Length)
            {
                string a = ExSubstring(str, 0, value.Length);
                if (a == value)
                    donecekDeger = true;

            }
            else
                donecekDeger = false;

            return donecekDeger;
        }
        public static bool ExContains(this string str, string value)
        {
            string deger = "";
            bool donecekDeger = false;
            if (str.Length >= value.Length)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (i + value.Length <= str.Length)
                    {
                        deger = ExSubstring(str, i, value.Length);
                        if (deger == value)
                        {
                            donecekDeger = true;
                            break;
                        }
                    }
                    else
                        break;
                }
            }
            else
                donecekDeger = false;
            return donecekDeger;
        }
        public static int ExLastIndexOf(this string str, char value)
        {
            int donecekDeger = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == value)
                    donecekDeger = i;
            }
            return donecekDeger;
        }
        public static int ExLastIndexOf(this string str, string value)
        {
            int donecekDeger = -1;
            for (int i = 0; i <= str.Length - value.Length; i++)
            {
                string a = ExSubstring(str, i, value.Length);
                if (a == value)
                    donecekDeger = i;
            }
            return donecekDeger;
        }
        public static int ExLastIndexOf(this string str, char value, int startindex)
        {
            int donecekDeger = -1;
            int index = 0;

            if (str.Length >= startindex)
                for (int i = 0; i < index; i++)
                {
                    if (value == str[i])
                        donecekDeger = i;
                }
            else
                throw new Exception("startindex içinde arama yaptırılacak metinden uzun olamaz.");

            return donecekDeger;
        }
        public static int ExLastIndexOf(this string str, string value, int startindex)
        {
            int donecekDeger = -1;
            int index = 0;

            if (str.Length >= startindex)
                for (int i = 0; i < index - value.Length; i++)
                {
                    string a = ExSubstring(str, i, value.Length);
                    if (a == value)
                        donecekDeger = i;
                }
            else
                throw new Exception("startindex içinde arama yaptırılacak metinden uzun olamaz.");


            return donecekDeger;
        }
        public static string ExRemove(this string str, int startIndex)
        {
            string donecekDeger = "";
            if (str.Length >= startIndex)
            {
                for (int i = 0; i < startIndex; i++)
                {
                    donecekDeger += str[i];
                }
            }
            else
                throw new Exception("StartIndex, string boyutuna eşit veya string boyutundan küçük olmalıdır.");
            return donecekDeger;
        }
        public static string ExRemove(this string str, int startIndex, int count)
        {
            string donecekDeger = "";
            if (str.Length >= startIndex + count)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (i < startIndex || i > startIndex + count - 1)
                        donecekDeger += str[i];
                    else
                       if (count == 0)
                        continue;
                    else
                        i += count - 1;
                }
            }
            else
                throw new Exception("Startindex ve count toplamı metnin uzunluğundan küçük olamlıdır...");
            return donecekDeger;
        }
        public static string ExReplace(this string str, char oldChar, char newChar)
        {
            char[] dizi = ExToCharArray(str);
            int deger = ExIndexOf(new string(dizi), oldChar);
            while (deger != -1)
            {
                int index = ExIndexOf(str, oldChar);
                dizi[index] = newChar;
                deger = ExIndexOf(new string(dizi), oldChar);
            }

            return new string(dizi);
        }
        public static string ExReplace(this string str, string oldValue, string newValue)
        {
            char[] dizi = str.ExToCharArray();
            char[] dizi1 = new char[0];
            int index = str.IndexOf(oldValue);
            int a = 0;


            while (index != -1)
            {
                Array.Resize(ref dizi1, str.Length - oldValue.Length + newValue.Length);
                for (int i = 0; i < dizi.Length; i++)
                {
                    if (i == index)
                    {
                        for (int j = 0; j < newValue.Length; j++)
                        {
                            dizi1[a] = newValue[j];
                            a++;
                        }
                        i += oldValue.Length - 1;
                    }
                    else
                    {
                        dizi1[a] = dizi[i];
                        a++;
                    }
                }
                str = new string(dizi1);
                Array.Resize(ref dizi, str.Length - oldValue.Length + newValue.Length);
                dizi = dizi1;
                a = 0;
                index = ExIndexOf(new string(dizi), oldValue);
            }


            return new string(dizi1);
        }
        public static string[] ExSplit(this string str, char chr)
        {
            string[] stringDizi = new string[0];
            string geciciString = str;
            int index = ExIndexOf(str, chr);
            int a = 0;
            int kackere = 0;
            int uzunluk = 0;

            while (index != -1)
            {
                Array.Resize(ref stringDizi, stringDizi.Length + 1);
                stringDizi[stringDizi.Length - 1] = ExSubstring(geciciString, a, index - uzunluk);
                kackere++;
                uzunluk = stringDizi[stringDizi.Length - 1].Length;
                a = index;
                geciciString = ExRemove(geciciString, index, 1);
                index = ExIndexOf(geciciString, chr);
                if (index == -1)
                {

                    Array.Resize(ref stringDizi, stringDizi.Length + 1);
                    stringDizi[stringDizi.Length - 1] = ExSubstring(geciciString, a, geciciString.Length - a);
                }
            }

            return stringDizi;
        }
        public static string ExInsert(this string str, int startIndex, string value)
        {
            string donecekDeger = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length==startIndex)
                {
                    donecekDeger =str+ value;
                    break;
                }
                else if (i != startIndex)
                {
                    donecekDeger += str[i];
                }
                else
                {
                    for (int j = 0; j < value.Length; j++)
                    {
                        donecekDeger += value[j];
                    }
                    donecekDeger += str[i];
                }
                    
            }
            return donecekDeger;
        }
        public static string ExTrim(this string str)
        {
            string donecekDeger = "";
            bool bastaBittimi = false;
            bool sondaBittimi = false;
            int bastakiBoslukSayisi = 0;
            int sondakiBoslukSayisi = 0;

            for (int i = 0; i <str.Length; i++)
            {
                if (str[i] == ' ' && !bastaBittimi)
                {
                    bastakiBoslukSayisi++;                    
                }
                else
                    bastaBittimi = true;

                if (str[str.Length - i - 1] == ' ' && !sondaBittimi)
                {
                    sondakiBoslukSayisi++;
                }
                else
                    sondaBittimi = true;
            }
            donecekDeger = ExRemove(str,0,bastakiBoslukSayisi);
            donecekDeger = ExRemove(donecekDeger,donecekDeger.Length-sondakiBoslukSayisi,sondakiBoslukSayisi);

            return donecekDeger;
        }
    }
}
