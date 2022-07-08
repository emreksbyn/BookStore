using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Persistence.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gelen string ifadeyi TryParse fonksiyonu ile int donusturuyoruz ve geriye kendimize donduruyoruz.
        /// </summary>
        /// <param name="parametre"></param>
        /// <returns></returns>
        public static int ToInt(this string parametre)
        {
            int.TryParse(parametre, out int id);
            return id;
        }

        /// <summary>
        /// Bu extension method aldigi 2 string ifadeyi kucuk harflere donusturdukten sonra iki ifade esitse true, degilse false doner.
        /// </summary>
        /// <param name="parametre"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        public static bool EqualNoCase(this string parametre, string toCompare)
        {
            return parametre?.ToLower() == toCompare?.ToLower();
        }

        // Gelen string ifadeye asagidaki method uygulanmadiginda "Em.re Kisaboyun-auth/or"
        public static string Slug(this string parametre)
        {
            var stringBuilder = new StringBuilder();
            foreach (char character in parametre)
            {
                if (character == '-' || !char.IsPunctuation(character))
                {
                    stringBuilder.Append(character);
                }
            }// foreach ifadesinden stringBuilder bu halde cikacak "Emre Kisaboyun-author"
            return stringBuilder.ToString().Replace(' ', '-').ToLower();
            // return edilecek deger "emre-kisaboyun-author"
        }
    }
}