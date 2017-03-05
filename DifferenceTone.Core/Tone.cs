using System;

namespace DifferenceTone.Core
{
    public class PitchInfo
    {
        private const double PitchStandardFrequency = 440.0d;
        private static readonly double MiddleCFrequency = PitchStandardFrequency * Math.Pow(Math.Pow(2.0d, 1.0d / 12.0), -9);

        private PitchInfo(string label, decimal deriviation)
        {
            Label = label;
            Derivation = deriviation;
        }

        public static PitchInfo FromFrequency(decimal frequency)
        {
            var logNote = (decimal)((Math.Log((double)frequency) - Math.Log(MiddleCFrequency)) / Math.Log(2.0d)) + 4.0m;
            var octave = Math.Floor(logNote);
            var cents = 1200 * (logNote - octave);

            var notes = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

            if (cents >= 1150)
            {
                cents -= 1200;
                octave++;
            }

            for (var i = 0; i < notes.Length; i++)
            {
                if (cents >= -50 + (i * 100) && cents < 50 + (i * 100))
                {
                    cents -= (i * 100);
                    return new PitchInfo($"{notes[i]}{octave}", Math.Round(cents, 2));
                }
            }

            throw new Exception();
        }

        public string Label { get; }
        public decimal Derivation { get; set; }
    }

    public class Tone
    {
        public Tone(decimal frequency)
        {
            if (frequency < 0.0m)
            {
                throw new ArgumentException("Frequency can not be negative.", nameof(frequency));
            }

            Frequency = frequency;
        }

        public decimal Frequency { get; }
        public PitchInfo PitchInfo
        {
            get
            {
                return PitchInfo.FromFrequency(Frequency);
            }
        }
    }
}