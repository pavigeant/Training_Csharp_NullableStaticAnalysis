using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class MaybeNullWhenShould
{
    // A non-nullable argument may be null when the method returns the specified bool value.
    // Opposite of NotNullWhen
    [Fact]
    public void ConditionalPostcondition_ANonNullableArgumentMayBeNullWhenTheMethodReturnsTheSpecifiedBoolValue()
    {
        static bool ValidateName([MaybeNullWhen(false)] string? value) => value is not null;

        string? name = null;
        
        // Warning for null
        Assert.Throws<NullReferenceException>(() => !ValidateName(name) && name.StartsWith('A'));

        name = "Alice";

        // No warning since what comes after ValidateName with a non null value will be considered not null
        Assert.True(ValidateName(name) && name.StartsWith('A'));
    }
}
