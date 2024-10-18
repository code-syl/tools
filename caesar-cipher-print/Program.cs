using System.CommandLine;

const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

var rootCommand = new RootCommand(
    "Prints all possible caesar cipher possibilities."
);

var cipherOption = new Option<string>(
        ["--cipher", "-c"],
        "The cipher to print the possibilities of.")
    { IsRequired = true, AllowMultipleArgumentsPerToken = false };
rootCommand.Add(cipherOption);

var alphabetOption = new Option<string>(
        ["--alphabet", "-a"],
        description: "The alphabet to use for the cipher.",
        getDefaultValue: () => defaultAlphabet)
    { IsRequired = false, AllowMultipleArgumentsPerToken = false };
rootCommand.Add(alphabetOption);

rootCommand.SetHandler((cipher, alphabet) =>
    {
        var possibilities = GetCaesarCipherPossibilities(cipher, alphabet);
        Array.ForEach(possibilities, Console.WriteLine);
    },
    cipherOption, alphabetOption);

return rootCommand.Invoke(args);

string[] GetCaesarCipherPossibilities(string input, string alphabet)
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