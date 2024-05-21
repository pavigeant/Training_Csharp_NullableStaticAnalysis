using System.Diagnostics.CodeAnalysis;

namespace Training_Csharp_NullableStaticAnalysis;

public class MemberNotNullShould
{
    // The listed member won't be null when the method returns.
    [Fact]
    public void MethodAndPropertyHelperMethods_TheListedMemberWontBeNullWhenTheMethodReturns()
    {
        var student = new Student();

        Assert.Throws<NullReferenceException>(() => student.Code.StartsWith("123"));

        student.InitializeCode();

        // No warning here since it won't be null after calling InitializeCode
        Assert.True(student.Code.StartsWith('1'));
    }

    private class Student
    {
        public string? Code { get; set; }

        [MemberNotNull(nameof(Code))]
        public void InitializeCode()
        {
            Code = "123";
        }
    }
}
