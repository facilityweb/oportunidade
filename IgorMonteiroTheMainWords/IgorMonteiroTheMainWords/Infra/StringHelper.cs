using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class StringHelper
    {
        public static string ReplaceAccents(this string text)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(text);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            return asciiStr;
        }
        public static IList<string> RemovePrepositions(this string text)
        {
            string[] removedWords = { "para","a", "ainda", "alem", "ambas", "ambos", "antes", "ao", "aonde", "aos", "apos", "aquele", "aqueles",
                    "as", "assim", "com", "como", "contra", "contudo", "cuja", "cujas", "cujo", "cujos", "da", "das", "de", "dela", "dele",
                    "deles", "demais", "depois", "desde", "desta", "deste", "dispoe", "dispoem", "diversa", "diversas", "diversos", "do", "dos",
                    "durante", "e", "ela", "elas", "ele", "eles", "em", "entao", "entre", "essa", "essas", "esse", "esses", "esta", "estas", "este",
                    "estes", "ha", "isso", "isto", "logo", "mais", "mas", "mediante", "menos", "mesma", "mesmas", "mesmo", "mesmos", "na", "nao", "nas",
                    "nem", "nesse", "neste", "nos", "o", "os", "ou", "outra", "outras", "outro", "outros", "pelas", "pelo", "pelos", "perante", "pois",
                    "por", "porque", "portanto", "propios", "proprio", "quais", "qual", "qualquer", "quando", "quanto", "que", "quem", "quer", "se",
                    "seja", "sem", "sendo", "seu", "seus", "sob", "sobre", "sua", "suas", "tal", "tambem", "teu", "teus", "toda", "todas", "todo",
                    "todos", "tua", "tuas", "tudo", "um", "uma", "umas", "uns", "aos", "às", "ao", "à", "aquele", "aqueles", "aquela", "aquelas", "àquilo",
                    "aquilo", "aonde", "do", "dos", "da", "das", "deste", "destes", "desta", "destas", "dum", "duns", "duma", "dumas", "dele", "deles",
                    "dela", "delas", "desse", "desses", "dessa", "dessas", "daquele", "daqueles", "daquela", "daquelas", "disso", "disto", "daquilo",
                    "daqui", "dai", "daí", "dali", "dalí", "dacolá", "donde", "doutro", "doutros", "doutrem", "no", "nos", "na", "nas", "num", "nuns",
                    "numa", "numas", "nele", "neles", "nela", "nelas", "nesse", "nesses", "nessa", "nessas", "neste", "nestas", "naquele", "naqueles",
                    "naquela", "naquelas", "nisto", "nisso", "naquilo", "noutro", "noutros", "noutra", "noutras", "noutrem", "pro", "pros", "pra", "pras",
                    "pelo", "pelos", "pela", "pelas", "dentre", "de", "em", "para", "per", "por", "que", "e", "com", "um", "uns", "uma", "umas", "as", "pode", "está" };

            foreach (var item in removedWords)
                text = text.Replace($" {item} ", " ");

            return text.Split(' ').ToList();
        }

        public static string RemoveSpecialChars(this string accentText)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in accentText)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c == ' '))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
