using HashidsNet;

namespace ATSControlSystem.Domain.Entity;

public class BaseEntity
{
    public string Id { get; protected init; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    protected static class Code
    {
        private static Random _random = new Random();
        private static readonly string _lowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string _upperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _digits = "0123456789";

        public static string Create(
            string prefix = null,
            int length = 16,
            bool useLowerCase = true,
            bool useUpperCase = true,
            bool useDigits = true)
        {
            string empty = string.Empty;
            if (useLowerCase)
            {
                empty += Code._lowerCaseCharacters;
            }

            if (useUpperCase)
            {
                empty += Code._upperCaseCharacters;
            }

            if (useDigits)
            {
                empty += Code._digits;
            }

            string str = new Hashids(
                Guid.NewGuid().ToString(),
                length,
                empty
            ).Encode(
                (IEnumerable<int>)Enumerable.Range(0, 3).Select<int, int>(
                        (Func<int, int>)(r => Code._random.Next(100))
                    )
                    .ToList<int>());

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                str = prefix + str;
            }

            return str;
        }
    }
}