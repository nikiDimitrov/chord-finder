using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

namespace Chord_Finder.Helpers
{
    public static class FrequencyAnalyzer
    {
        public static double[] ComputeFFT(float[] audioSamples, int sampleRate, int fftSize = 4096)
        {
            Complex[] fftBuffer = new Complex[fftSize];

            for(int i = 0; i < fftSize; i++)
            {
                fftBuffer[i] = new Complex(audioSamples[i], 0);
            }

            Fourier.Forward(fftBuffer, FourierOptions.Matlab);

            double[] magnitudes = new double[fftSize / 2];
            for(int i = 0; i < fftSize / 2; i++)
            {
                magnitudes[i] = fftBuffer[i].Magnitude;
            }

            return magnitudes;
        }

        public static List<double> GetTopFrequencies(double[] fftMagnitudes, int sampleRate, int fftSize, int topN = 3)
        {
            List<double> frequencies = new();
            int nyquist = sampleRate / 2; // Max frequency captured
            int binSize = nyquist / (fftSize / 2);

            var topIndices = fftMagnitudes
                .Select((magnitude, index) => new { Magnitude = magnitude, Index = index })
                .OrderByDescending(x => x.Magnitude)
                .Take(topN)
                .Select(x => x.Index)
                .ToList();

            foreach (var index in topIndices)
            {
                double freq = index * binSize;
                frequencies.Add(freq);
            }

            return frequencies;
        }
    }
}
