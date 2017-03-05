using DifferenceTone.Core;
using NUnit.Framework;

namespace DifferenceTonie.Core.UnitTest
{
    [TestFixture]
    public class CalculationsTest
    {
        [Test]
        public void DifferenceTone_FirstToneIsHigher_ReturnsCorrectDifferenceTone()
        {
            var tone1 = new Tone(440.0m);
            var tone2 = new Tone(330.0m);

            var differenceTone = Calculations.DifferenceTone(tone1, tone2);

            Assert.AreEqual(110.0m, differenceTone.Frequency);
        }

        [Test]
        public void DifferenceTone_SecondToneIsHigher_ReturnsCorrectDifferenceTone()
        {
            var tone1 = new Tone(330.0m);
            var tone2 = new Tone(440.0m);

            var differenceTone = Calculations.DifferenceTone(tone1, tone2);

            Assert.AreEqual(110.0m, differenceTone.Frequency);
        }

        [Test]
        public void DifferenceTone_BothTonesAreTheSame_ReturnsCorrectDifferenceTone()
        {
            var tone1 = new Tone(440.0m);
            var tone2 = new Tone(440.0m);

            var differenceTone = Calculations.DifferenceTone(tone1, tone2);

            Assert.AreEqual(0.0m, differenceTone.Frequency);
        }
    }
}
