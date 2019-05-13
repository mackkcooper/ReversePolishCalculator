using System;
using System.IO;
using FluentAssertions;
using Xunit;
using FakeItEasy;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FileLogger;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class RpnEngineTests
    {
        [Fact]
        public void RpnEngine_Add_Success()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "2 2 +";
            var output = new StringWriter();
            Console.SetOut(output);
            myRpnEngine.CalculateRpn(input);
            
            var stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
            output.ToString().Should().Be("4\r\n", "Because addition...");
        }
        [Fact]
        public void RpnEngine_Subtract_Success()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "8 2 -";
            var output = new StringWriter();
            Console.SetOut(output);
            myRpnEngine.CalculateRpn(input);

            var stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
            output.ToString().Should().Be("6\r\n", "Because subtraction...");
        }
        [Fact]
        public void RpnEngine_Multiply_Success()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "3 6 *";
            var output = new StringWriter();
            Console.SetOut(output);
            myRpnEngine.CalculateRpn(input);

            var stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
            output.ToString().Should().Be("18\r\n", "Because multiplication...");
        }
        [Fact]
        public void RpnEngine_Divide_Success()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "42 6 /";
            var output = new StringWriter();
            Console.SetOut(output);
            myRpnEngine.CalculateRpn(input);

            var stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
            output.ToString().Should().Be("7\r\n", "Because division...");
        }
        [Fact]
        public void RpnEngine_Power_Success()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "3 3 ^";
            var output = new StringWriter();
            Console.SetOut(output);
            myRpnEngine.CalculateRpn(input);

            var stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
            output.ToString().Should().Be("27\r\n", "Because power...");
        }
        [Fact]
        public void RpnEngine_BadInput_Exception()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "3 4 applesauce";
            Action act = () => myRpnEngine.CalculateRpn(input);
            act.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void RpnEngine_BadInput_Logger_Fatal()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "3 4 applesauce";
            try
            {
                myRpnEngine.CalculateRpn(input);
            }
            catch (Exception e)
            {
                A.CallTo(() => log.Fatal($"Could not parse [applesauce]")).MustHaveHappened();
            }
        }
        [Fact]
        public void RpnEngine_Calls_Logger_Debug()
        {
            Calculator calc = A.Fake<Calculator>();
            Logger log = A.Fake<Logger>();
            RpnEngine myRpnEngine = new RpnEngine(calc, log);

            string input = "2 2 +";
            myRpnEngine.CalculateRpn(input);
            A.CallTo(() => log.Debug("2")).MustHaveHappened();
        }
    }
}
