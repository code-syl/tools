namespace caesar_cipher_print;

public class CaesarCipher
{
    public required string Alphabet { get; init; }
    public string[] Possibilities(string input) => _getPossibilities(input, Alphabet);

    private static string[] _getPossibilities(string input, string alphabet)
    {
        var result = new string[alphabet.Length];
        result[0] = input;

        for (var i = 1; i < alphabet.Length; i++)
        {
            var shifted = new char[input.Length];
            for (var j = 0; j < input.Length; j++)
            {
                var index = alphabet.IndexOf(input[j]);
                if (index == -1)
                {
                    shifted[j] = input[j];
                    continue;
                }

                shifted[j] = alphabet[(index + i) % alphabet.Length];
            }

            result[i] = new string(shifted);
        }

        return result;
    }
}