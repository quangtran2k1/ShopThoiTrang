using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShopThoiTrang
{
    public static class XString
    {
        public static String ToBase64(this String s)
        {
            if (s != null)
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                return Convert.ToBase64String(bytes);
            }
            return s;
        }

        public static String FromBase64(this String s)
        {
            if (s != null)
            {
                var bytes = Convert.FromBase64String(s);
                return Encoding.UTF8.GetString(bytes);
            }
            return s;
        }

        public static String ToMD5(this String s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var hash = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static string Str_Slug(string s)
        {
            String[][] symbols =
            {
                new String[] { "[áàảãạăắằẳẵặâấầẩẫậ]", "a" },
                new String[] { "[đ]", "d" },
                new String[] { "[éèẽẻẹêếềễểệ]", "e" },
                new String[] { "[íìĩỉị]", "i" },
                new String[] { "[óòõỏọôồốổỗộơờớởỡợ]", "o" },
                new String[] { "[úùũủụưừứửữự]", "u" },
                new String[] { "[ýỳỹỷỵ]", "y" },
                new String[] { "[\\s'\";']", "-" }
            };
            s = s.ToLower();
            foreach (var ss in symbols)
            {
                s = Regex.Replace(s, ss[0], ss[1]);
            }
            return s;
        }
    }
}