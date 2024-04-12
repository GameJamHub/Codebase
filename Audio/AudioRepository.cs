using UnityEngine;

namespace Codebase.Audio
{
    [CreateAssetMenu(menuName = "Codebase/Audio/AudioRepository", fileName = "AudioRepository", order = 0)]
    public partial class AudioRepository : ScriptableObject
    {
        public AudioClipReference backgroundMusic;
        public AudioClipReference buttonClickSFX;
        public AudioClipReference sceneLoadedSFX;
    }
}


