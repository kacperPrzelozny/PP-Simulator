using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(15, 0, 10, 10)]
    [InlineData(-5, 0, 10, 0)]
    public void Limiter_Test(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("aaaa", 5, 10, '#', "Aaaa#")]
    [InlineData("", 3, 5, '#', "###")]
    [InlineData("", 3, 5, ' ', "   ")]
    [InlineData("aaaaaaaa", 5, 7, '#', "Aaaaaaa")]
    [InlineData("aaaaa", 5, 5, '#', "Aaaaa")]
    public void Shortener_Test(string input, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(input, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}