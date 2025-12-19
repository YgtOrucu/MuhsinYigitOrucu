using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public static class ValidationMessages
    {
        public static string NotEmpty(string name)
            => $"{name} kısmı boş bırakılamaz.";

        public static string OnlyLetters(string Matches)
            => $"{Matches} kısmı sadece harflerden oluşmalıdır.";

        public static string MinLength(int length)
            => $"En az {length} karakter olmalıdır.";

        public static string MaxLength(int length)
            => $"En fazla {length} karakter olabilir.";
    }
}
