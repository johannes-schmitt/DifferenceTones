using System;
using DifferenceTone.Core;
using NUnit.Framework;

namespace DifferenceTonie.Core.UnitTest
{
    [TestFixture]
    public class ToneTest
    {
        [Test]
        public void Constructor_FrequencyIsNegative_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Tone(-0.00000000000000000000001m));
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsPerfectConcertPitch_ReturnsA4()
        {
            var concertPitch = new Tone(440m);

            var note = concertPitch.PitchInfo;

            Assert.AreEqual("A4", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsPerfectMiddleC_ReturnsC4()
        {
            var middleCFrequency = 440.0d * Math.Pow(Math.Pow(2.0d, 1.0d / 12.0d), -9);
            var middleC = new Tone((decimal)middleCFrequency);

            var note = middleC.PitchInfo;

            Assert.AreEqual("C4", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsRoundedMiddleC_ReturnsC4()
        {
            var middleC = new Tone(261.625m);

            var note = middleC.PitchInfo;

            Assert.AreEqual("C4", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsRoundedG6_ReturnsG6()
        {
            var g6 = new Tone(1567.98m);

            var note = g6.PitchInfo;

            Assert.AreEqual("G6", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsRoundedG6Sharp_ReturnsG6Sharp()
        {
            var gSharp6 = new Tone(1661.22m);

            var note = gSharp6.PitchInfo;

            Assert.AreEqual("G#6", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsRoundedDMinus1_ReturnsDMinus1()
        {
            var dMinusOne = new Tone(9.177m);

            var note = dMinusOne.PitchInfo;

            Assert.AreEqual("D-1", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsRoundedG9_ReturnsG9()
        {
            var g9 = new Tone(12543.854m);

            var note = g9.PitchInfo;

            Assert.AreEqual("G9", note.Label);
            Assert.AreEqual(0.0m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsCloseToMiddleC_ReturnsMiddleC()
        {
            var g9 = new Tone(263);

            var note = g9.PitchInfo;

            Assert.AreEqual("C4", note.Label);
            Assert.AreEqual(9.07m, note.Derivation);
        }

        [Test]
        public void PitchInfoLabel_FrequencyIsCloseToQuarterTone_ReturnsProperTone()
        {
            var g9 = new Tone(254.18m);

            var note = g9.PitchInfo;

            Assert.AreEqual("C4", note.Label);
            Assert.AreEqual(-49.98m, note.Derivation);
        }
    }
}
