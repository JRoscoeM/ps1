// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright 2024 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> Roscoe Moedl </authors>
// <date> 1/9/2025 </date>

namespace CS3500.FormulaTests;

using CS3500.Formula1;

/// <summary>
///   <para>
///     The following class shows the basics of how to use the MSTest framework,
///     including:
///   </para>
///   <list type="number">
///     <item> How to catch exceptions. </item>
///     <item> How a test of valid code should look. </item>
///   </list>
/// </summary>
[TestClass]
public class FormulaSyntaxTests
{
    /// <summary>
    ///   <para>
    ///     This test makes sure the right kind of exception is thrown
    ///     when trying to create a formula with no tokens.
    ///   </para>
    ///   <remarks>
    ///     <list type="bullet">
    ///       <item>
    ///         We use the _ (discard) notation because the formula object
    ///         is not used after that point in the method.  Note: you can also
    ///         use _ when a method must match an interface but does not use
    ///         some of the required arguments to that method.
    ///       </item>
    ///       <item>
    ///         string.Empty is often considered best practice (rather than using "") because it
    ///         is explicit in intent (e.g., perhaps the coder forgot to but something in "").
    ///       </item>
    ///       <item>
    ///         The name of a test method should follow the MS standard:
    ///         https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    ///       </item>
    ///       <item>
    ///         All methods should be documented, but perhaps not to the same extent
    ///         as this one.  The remarks here are for your educational
    ///         purposes (i.e., a developer would assume another developer would know these
    ///         items) and would be superfluous in your code.
    ///       </item>
    ///       <item>
    ///         Notice the use of the attribute tag [ExpectedException] which tells the test
    ///         that the code should throw an exception, and if it doesn't an error has occurred;
    ///         i.e., the correct implementation of the constructor should result
    ///         in this exception being thrown based on the given poorly formed formula.
    ///       </item>
    ///     </list>
    ///   </remarks>
    ///   <example>
    ///     <code>
    ///        // here is how we call the formula constructor with a string representing the formula
    ///        _ = new Formula( "5+5" );
    ///     </code>
    ///   </example>
    /// </summary>

    // --- Tests for One Token Rule ---
    [TestMethod]
    [ExpectedException( typeof( FormulaFormatException ) )]
    public void FormulaConstructor_TestNoTokens_Invalid( )
    {
        _ = new Formula(string.Empty);
    }

    // --- Tests for Valid Token Rule ---
    [TestMethod]
    [ExpectedException ( typeof( FormulaFormatException ) )]
    public void FormulaConstructor_TestRowFirstVar_Invalid()
    {
        _ = new Formula("1a");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestNoRowVar_Invalid()
    {
        _ = new Formula("a");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestTwoColsVar_Invalid()
    {
        _ = new Formula("a1a");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestDollarSign_Invalid()
    {
        _ = new Formula("$12");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestComma_Invalid()
    {
        _ = new Formula("12,000");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestExclamation_Invalid()
    {
        _ = new Formula("100000!");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestHashSymbol_Invalid()
    {
        _ = new Formula("#12");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestPercentSymbol_Invalid()
    {
        _ = new Formula("79%");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestSemiColon_Invalid()
    {
        _ = new Formula("a12;");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestBackslash_Invalid()
    {
        _ = new Formula("12\\4");
    }
    /// <summary>
    /// Test that the constructor correctly recognizes a basic variable as being valid.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestGoodVariable_Valid()
    {
        _ = new Formula("a1");
    }
    /// <summary>
    /// Test that the constructor correctly recognizes <1 decimal numbers as being valid. With no Zero
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestDecimalNumUnderOneNoZero_Valid()
    {
        _ = new Formula(".5");
    }
    /// <summary>
    /// Test that the constructor correctly recognizes <1 decimal numbers as being valid. With Zero
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestDecimalNumUnderOneWithZero_Valid()
    {
        _ = new Formula("0.5");
    }
    /// <summary>
    /// Test that the constructor correctly recognizes >1 decimal numbers as being valid. With no Zero
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestDecimalNumOverOneNoZero_Valid()
    {
        _ = new Formula("5.");
    }
    /// <summary>
    /// Test that the constructor correctly recognizes >1 decimal numbers as being valid. With zero
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestDecimalNumOverOneWithZero_Valid()
    {
        _ = new Formula("5.0");
    }
    //[TestMethod]
    //public void FormulaConstructor_TestSimpleExpression_Valid()
    //{
    //    _ = new Formula("2+2");
    //}
    //[TestMethod]
    //public void FormulaConstructor_TestComplexExpression_Valid()
    //{
    //    _ = new Formula("(2+2) / 3 - (b6 * 3)");
    //}
    
    /// <summary>
    /// Test that the constructor correctly recognizes "E-Negative" scientific notation as valid
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestSmallScientificNotation_Valid()
    {
        _ = new Formula("12.4E-6");
    }
    /// <summary>
    /// Test that the constructor correctly recognizes "E-Positive" scientific notation as valid
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestBigScientificNotation_Valid()
    {
        _ = new Formula("34E17");
    }

    // --- Tests for Closing Parenthesis Rule
    [TestMethod]
    public void FormulaConstructor_TestTwoPairs_Valid()
    {
        _ = new Formula("((8+3)*9)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestTooManyClosingParens_InValid()
    {
        _ = new Formula("(8+3)*9)");
    }

    // --- Tests for Balanced Parentheses Rule

    /// <summary>
    /// Test that the constructor allows a valid expression contained within 3 sets of parens.
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestTripleParenPairs_Valid()
    {
        _ = new Formula("(((123*34)))");
    }
    [TestMethod]
    [ExpectedException (typeof(FormulaFormatException))]
    public void FormulaConstructor_TestTooManyOpenParens_InValid()
    {
        _ = new Formula("(((8+3)*34)");
    }

    // --- Tests for First Token Rule
    [TestMethod]
    [ExpectedException (typeof(FormulaFormatException))]
    public void FormulaConstructor_TestFirstIsCloseParen_Invalid()
    {
        _ = new Formula(")93*4");
    }
    [TestMethod]
    [ExpectedException (typeof(FormulaFormatException))]
    public void FormulaConstructor_TestFirstIsAdd_Invalid()
    {
        _ = new Formula("+43");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestFirstIsSubtract_Invalid()
    {
        _ = new Formula("-43");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestFirstIsDivide_Invalid()
    {
        _ = new Formula("/43");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestFirstIsMultiply_Invalid()
    {
        _ = new Formula("*43");
    }
    /// <summary>
    ///   <para>
    ///     Make sure a simple well formed formula is accepted by the constructor (the constructor
    ///     should not throw an exception).
    ///   </para>
    ///   <remarks>
    ///     This is an example of a test that is not expected to throw an exception, i.e., it succeeds.
    ///     In other words, the formula "1+1" is a valid formula which should not cause any errors.
    ///   </remarks>
    /// </summary>
    [TestMethod]
    public void FormulaConstructor_TestFirstTokenNumber_Valid( )
    {
        _ = new Formula( "1+1" );
    }

    // --- Tests for  Last Token Rule ---
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestLastIsOpenParen_Invalid()
    {
        _ = new Formula("93*4(");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestLastIsAdd_Invalid()
    {
        _ = new Formula("43+");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestLastIsSubtract_Invalid()
    {
        _ = new Formula("43-");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestLastIsDivide_Invalid()
    {
        _ = new Formula("43/");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestLastIsMultiply_Invalid()
    {
        _ = new Formula("43*");
    }

    // --- Tests for Parentheses/Operator Following Rule ---
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestAddFollowsOpenParen_Invalid()
    {
        _ = new Formula("(+32)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestSubtractFollowsOpenParen_Invalid()
    {
        _ = new Formula("(-32)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestMultiplyFollowsOpenParen_Invalid()
    {
        _ = new Formula("(*32)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestDivideFollowsOpenParen_Invalid()
    {
        _ = new Formula("(/32)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestAddFollowsMultiply_Invalid()
    {
        _ = new Formula("(12*+65)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestSubtractFollowsOpenDivide_Invalid()
    {
        _ = new Formula("(12/-65)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestMultiplyFollowsOpenAdd_Invalid()
    {
        _ = new Formula("(12+*65)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestDivideFollowsSubtract_Invalid()
    {
        _ = new Formula("(12-/65)");
    }

    // --- Tests for Extra Following Rule ---
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVarFollowsNum_InValid()
    {
        _ = new Formula("67ABC123");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestOpenParenFollowsNum_InValid()
    {
        _ = new Formula("67(2+3)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestNumFollowsNum_InValid()
    {
        _ = new Formula("67 76");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVarFollowsVar_Invalid()
    {
        _ = new Formula("A12 BC3");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestOpenParenFollowsVar_Invalid()
    {
        _ = new Formula("C13(1+2)");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestNumFollowsVar_Invalid()
    {
        _ = new Formula("F32 13");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestNumFollowsCloseParen_Invalid()
    {
        _ = new Formula("(12*3)6");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestVarFollowsCloseParen_Invalid()
    {
        _ = new Formula("(12*3)c2");
    }
    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FormulaConstructor_TestOpenParenFollowsCloseParen_Invalid()
    {
        _ = new Formula("(12*3)(31)");
    }
}