using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class AllowNullShould
{
    // A non-nullable parameter, field, or property may be null.
    [Fact]
    public void Precondition_ANonNullableArgumentMayBeNull()
    {
        ScreenName = null;
        Assert.Equal("Bob", ScreenName);

        ScreenName = "Alice";
        Assert.Equal("Alice", ScreenName);
    }
    
    [AllowNull]
    public string ScreenName
    {
        get => _screenName;
        set => _screenName = value ?? "Bob";
    }

#pragma warning disable CS8618 // Warning disable to prevent warning from not being assigned during class initialization
    private string _screenName;
#pragma warning restore CS8618
}
