using NAudio.Wave;

namespace Chord_Finder_Core.Helpers
{
    public static class AudioProcessor
    {
        public static List<float[]> LoadAudioInChunks(string filePath, int windowSize = 4096)
        {
            using var reader = new AudioFileReader(filePath);
            var samples = new List<float>();

            float[] buffer = new float[reader.WaveFormat.SampleRate]; // Buffer for 1 second
            int bytesRead;
            while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                samples.AddRange(buffer.Take(bytesRead));
            }

            
            List<float[]> chunks = new();
            for (int i = 0; i < samples.Count; i += windowSize)
            {
                chunks.Add(samples.Skip(i).Take(windowSize).ToArray());
            }
            return chunks;
        }
    }
}
