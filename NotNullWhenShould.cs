using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class NotNullWhenShould
{
    // A nullable argument won't be null when the method returns the specified bool value.
    // Opposite of MaybeNullWhen
    [Fact]
    public void ConditionalPostcondition_ANullableArgumentWontBeNullWhenTheMethodReturnsTheSpecifiedBoolValue()
    {
        // See also string.IsNullOrEmpty
        static bool ValidateName([NotNullWhen(false)] string? value) => value is not null;

        string? name = null;
        ValidateName(name);

        // Warning for null
        Assert.Throws<NullReferenceException>(() => name.StartsWith('A'));

        name = "Alice";
        ValidateName(name);

        // No warning here since it won't be null
        Assert.True(name.StartsWith('A'));
    }
}
