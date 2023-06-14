using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class Sounds : MonoBehaviour
    {
        public static Sounds Instance;

        public AudioSource Engine { get; private set; }
        public AudioSource DropFuel { get; private set; }
        public AudioSource DropCargo { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            Engine = CreateAudio("AFX/rally-car", true, true);
            DropFuel = CreateAudio("AFX/water_drop", false, false);
            DropCargo = CreateAudio("AFX/drop-havest", false, false, 0.2f);
        }

        private AudioSource CreateAudio(string path, bool playOnAwake, bool isLooped, float volume = 1)
        {
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.clip = Resources.Load<AudioClip>(path);
            audio.playOnAwake = playOnAwake;
            audio.loop = isLooped;
            audio.volume = volume;

            return audio;
        }

        private void Start()
        {
            SetEnginePitch(0);
        }

        /// <summary>
        /// value 0...1
        /// </summary>
        /// <param name="pitch"></param>
        public void SetEnginePitch(float pitch)
        {
            // the experimentally found value of normal sound is in the range of 0,7...0.9
            Engine.pitch = Mathf.Clamp01(pitch) * 0.2f + 0.7f;
        }
    }
}