using System;
using FluentAssertions;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Add(first, second);
            result.Should().Be(24, "Because addition...");
        }

        [Fact]
        public void Calculator_Multiply_Success()
        {
            var calc = new Calculator();
            var first = 24;
            var second = 3;
            var result = calc.Multiply(first, second);
            result.Should().Be(72, "Because multiplication...");
        }

        [Fact]
        public void Calculator_Divide_Success()
        {
            var calc = new Calculator();
            var first = 21;
            var second = 7;
            var result = calc.Divide(first, second);
            result.Should().Be(3, "Because division...");
        }

        [Fact]
        public void Calculator_Power_Success()
        {
            var calc = new Calculator();
            var first = 2;
            var second = 3;
            var result = calc.Power(first, second);
            result.Should().Be(8, "Because power...");
        }

        [Fact]
        public void Calculator_Minus_Success()
        {
            var calc = new Calculator();
            var first = 24;
            var second = 14;
            var result = calc.Subtract(first, second);
            result.Should().Be(10, "Because subtraction...");
        }
        [Fact]
        public void Calculator_Division_Zero_Exception()
        {
            var calc = new Calculator();
            var first = 20;
            var second = 0;
            Action act = () => calc.Divide(first, second);
            act.Should().Throw<ArgumentException>();
        }
    }
}
