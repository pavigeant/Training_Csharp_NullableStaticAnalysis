using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class MaybeNullShould
{
    // A non-nullable parameter, field, property, or return value may be null.
    [Fact]
    public void Postcondition_ANonNullableReturnValueMayBeNull()
    {
        [return: MaybeNull]
        static T Find<T>(IEnumerable<T> sequence, Func<T, bool> predicate) => sequence.FirstOrDefault(predicate);

        var names = new List<string> { "Alice", "Bob", "Charlie" };
        var name = Find(names, n => n.StartsWith('D'));

        Assert.Null(name);
    }
}
