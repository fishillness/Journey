using UnityEngine;

namespace Journey
{
    public class TEST : MonoBehaviour
    {
        [SerializeField] SoundPlayer player;
        [SerializeField] private SoundType soundType;


        [SerializeField] private MusicPlayer playerMusic;
        [SerializeField] private MusicType musicType;

        public void SoundButton()
        {
            player.Play(soundType);
        }

        public void MusicButton()
        {
            playerMusic.Play(musicType);
        }

        public void MusicStopButton()
        {
            playerMusic.Stop();
        }
    }
}
