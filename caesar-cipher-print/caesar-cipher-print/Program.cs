using System.CommandLine;
using caesar_cipher_print;

const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
CaesarCipher caesar;

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
        caesar = new CaesarCipher
        {
            Alphabet = alphabet
        };
        var possibilities = caesar.Possibilities(cipher);
        Array.ForEach(possibilities, Console.WriteLine);
    },
    cipherOption, alphabetOption);

return rootCommand.Invoke(args);