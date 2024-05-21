using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class DisallowNullShould
{
    // A nullable parameter, field, or property should never be null.
    [Fact]
    public void Precondition_ANullableArgumentShouldNeverBeNull()
    {
        Assert.Throws< ArgumentNullException>(() => ScreenName = null);

        ScreenName = "Alice";
        Assert.Equal("Alice", ScreenName);
    }

    [DisallowNull]
    public string? ScreenName
    {
        get => _screenName;
        set => _screenName = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
    }

    private string? _screenName;
}