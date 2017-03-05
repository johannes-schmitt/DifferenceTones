using System;

namespace DifferenceTone.Core
{
    public static class Calculations
    {
        public static Tone DifferenceTone(Tone tone1, Tone tone2)
        {
            return new Tone(Math.Abs(tone1.Frequency - tone2.Frequency));
        }
    }
}
