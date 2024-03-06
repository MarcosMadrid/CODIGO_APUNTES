using System.Security.Cryptography;
using System.Text;

namespace MvcCoreCryptography.Helpers
{
    public class HelperCryptography
    {
        public static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";

            for (int i = 0; i < 50; i++)
            {
                int alert = random.Next(1, 255);
                char letra = Convert.ToChar(alert);
                salt += letra;
            }

            return salt;
        }

        public static bool CompareArrays(byte[] a, byte[] b)
        {
            bool iguales = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (!a[i].Equals(b[i]))
                    {
                        iguales = false;
                        return false;
                    }
                }
            }
            return iguales;
        }

        public static byte[] EncryptPassword(string password, string salt)
        {
            string contenido = password + salt;
            SHA512 sHA512 = SHA512.Create();
            byte[] salida = Encoding.UTF8.GetBytes(contenido);
            for (int i = 0; i <= 114; i++)
            {
                salida = sHA512.ComputeHash(salida);
            }
            sHA512.Clear();
            return salida;
        }
    }
}
