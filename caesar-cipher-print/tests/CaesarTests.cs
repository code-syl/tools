using caesar_cipher_print;
using FluentAssertions;

namespace tests;

public class CaesarTests
{
    private readonly CaesarCipher _defaultCaesar;
    private const string DefaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string DefaultCipher = "ABC";

    private readonly string[] _testCipherPossibilities =
    [
        "ABC", "BCD", "CDE", "DEF", "EFG", "FGH", "GHI", "HIJ",
        "IJK", "JKL", "KLM", "LMN", "MNO", "NOP", "OPQ", "PQR",
        "QRS", "RST", "STU", "TUV", "UVW", "VWX", "WXY", "XYZ",
        "YZA", "ZAB"
    ];

    public CaesarTests()
    {
        _defaultCaesar = new CaesarCipher
        {
            Alphabet = DefaultAlphabet
        };
    }
    
    [Fact]
    public void SanityTest()
    {
        // Assert
        1.Should().Be(1);
    }

    [Fact]
    public void DefaultsShouldReturnCorrectPossibilities()
    {
        // Arrange
        
        // Act
        var result = _defaultCaesar.Possibilities(DefaultCipher);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Length.Should().Be(DefaultAlphabet.Length);
        result.Should().BeEquivalentTo(_testCipherPossibilities);
    }
}