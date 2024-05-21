using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class NotNullIfNotNullShould
{
    // A return value, property, or argument isn't null if the argument for the specified parameter isn't null.
    [Fact]
    public void ConditionalPostcondition_AReturnValueOrPropertyOrArgumentIsntNullIfTheArgumentForTheSpecifiedParameterIsntNull()
    {
        // See also string.IsNullOrEmpty
        [return: NotNullIfNotNull(nameof(name))]
        static string? Welcome(string? name) => name is null ? null : $"Welcome {name}";

        var message = Welcome(null);

        // Warning for null
        Assert.Throws<NullReferenceException>(() => message.StartsWith("Welcome"));

        message = Welcome("Alice");

        // No warning here since it won't be null
        Assert.True(message[0..3] == "Wel");
    }
}
