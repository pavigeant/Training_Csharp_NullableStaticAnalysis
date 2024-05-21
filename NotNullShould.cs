using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Training_Csharp_NullableStaticAnalysis;

public class NotNullShould
{
    // A non-nullable return value should never be null.
    [Fact]
    public void Postcondition_ANullableReturnValueWillNeverBeNull()
    {
        static void ThrowWhenNull([NotNull] object? value) =>
            _ = value ?? throw new ArgumentNullException(nameof(value));

        Assert.Throws<ArgumentNullException>(() =>
        {
            string? name = null;
            ThrowWhenNull(name);

            // Name is not null here (check tooltip)
            if (name == "Bob") { }
        });
    }
}

public class DoesNotReturnShould
{
    // A method or property never returns. In other words, it always throws an exception.
    [Fact]
    public void UnreachableCode_AMethodOrPropertyNeverReturnsInOtherWordsItAlwaysThrowsAnException()
    {
        [DoesNotReturn]
        static void FailFast() => throw new InvalidOperationException();

        string? name = null;
        Assert.Throws<InvalidOperationException>(() =>
        {
            if (name is null)
            {
                FailFast();
            }

            // containedField can't be null:
            name = name.Replace("A", "B");
        });
    }
}

public class DoesNotReturnIfShould
{
    // This method or property never returns if the associated bool parameter has the specified value.
    [Fact]
    public void UnreachableCode_ThisMethodOrPropertyNeverReturnsIfTheAssociatedBoolParameterHasTheSpecifiedValue()
    {
        static void FailFastIf([DoesNotReturnIf(true)] bool isNull)
        {
            if (isNull)
                throw new InvalidOperationException();
        };

        string? name = null;
        Assert.Throws<InvalidOperationException>(() => FailFastIf(name is null));

        name = "Alice";
        FailFastIf(name is null);

        Assert.True(name.StartsWith('A'));
    }
}