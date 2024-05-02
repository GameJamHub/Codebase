using UnityEngine;

namespace Codebase.Audio
{
    [System.Serializable]
    public class AudioClipReference
    {
        public AudioClip clip;
        public float volume = 1f;
        public float pitch = 1f;
    }
}

