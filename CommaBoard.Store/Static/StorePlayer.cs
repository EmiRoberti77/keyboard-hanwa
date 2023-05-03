
using NAudio.Wave;

namespace CommaBoard.Store.Static
{
    public static class StorePlayer
    {
        public static string WavSoundJoystickDisconect = "";

        public static string WavSoundClientDisconect = "";

        public static int WavSoundVolume = 1;

        public static void PlaySound(string file)
        {
            WaveStream mainOutputStream = new WaveFileReader(file);
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);
            volumeStream.Volume = WavSoundVolume;
            WaveOutEvent player = new WaveOutEvent();

            player.Init(volumeStream);

            player.Play();
        }

    }
}