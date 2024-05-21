using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class MemberNotNullWhenShould
{
    // The listed member won't be null when the method returns the specified bool value.
    [Fact]
    public void MethodAndPropertyHelperMethods_TheListedMemberWontBeNullWhenTheMethodReturnsTheSpecifiedBoolValue()
    {
        var student = new Student();
        Assert.True(student.InitializeCode(true) && student.Code.StartsWith('1'));

        var student2 = new Student();
        Assert.Throws<NullReferenceException>(() => !student2.InitializeCode(false) && student2.Code.StartsWith("123"));
    }

    private class Student
    {
        public string? Code { get; set; }

        [MemberNotNullWhen(true, nameof(Code))]
        public bool InitializeCode(bool value)
        {
            if (value)
                Code = "123";

            return value;
        }
    }
}
