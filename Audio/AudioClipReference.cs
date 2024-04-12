using UnityEngine;

namespace Codebase.Audio
{
    [System.Serializable]
    public class AudioClipReference
    {
        public AudioClip clip;
        public float volume = 0f;
        public float pitch = 100f;
    }
}

