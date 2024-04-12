using System.Collections.Generic;
using System.Linq;
using Codebase.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace Codebase.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioMixer m_audioMixer;
        [SerializeField] private List<AudioMixerSnapshot> m_audioMixerSnapshots;
        [SerializeField] private AudioRepository m_audioRepository;

        private List<AudioMixerGroup> m_audioMixerGroups = new List<AudioMixerGroup>();

        public AudioRepository Audios => m_audioRepository;

        protected override void Init()
        {
            m_audioMixerGroups = m_audioMixer.FindMatchingGroups("").ToList();
        }

        public void PlayOneShotSFX(AudioClipReference audioClipReference, int channel,ulong delay = 0)
        {
            if (channel < 0 || channel >= m_audioMixerGroups.Count)
            {
                Debug.LogError("Invalid channel index.");
                return;
            }
            //TODO : Stop the Audio playing in a specific channel
            
            PlayAudio(audioClipReference, channel, delay);
        }

        public void PlaySFX(AudioClipReference audioClipReference, int channel,ulong delay = 0, bool isLooping = false )
        {
            if (channel < 0 || channel >= m_audioMixerGroups.Count)
            {
                Debug.LogError("Invalid channel index.");
                return;
            }
            //TODO : Stop the Audio playing in a specific channel
            
            PlayAudio(audioClipReference, channel, delay, isLooping);
        }
        
        public void PlayMusic(AudioClipReference audioClipReference, int channel,ulong delay = 0, bool isLooping = false )
        {
            if (channel < 0 || channel >= m_audioMixerGroups.Count)
            {
                Debug.LogError("Invalid channel index.");
                return;
            }
            //TODO : Stop the Audio playing in a specific channel
            
            PlayAudio(audioClipReference, channel, delay, isLooping);
        }

        private void PlayAudio(AudioClipReference audioClipReference, int channel, ulong delay = 0, bool isLooping = false)
        {
            GameObject tempAudio = new GameObject("tempAudio");
            AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
            audioSource.clip = audioClipReference.clip;
            audioSource.volume = audioClipReference.volume;
            audioSource.pitch = audioClipReference.pitch;
            audioSource.outputAudioMixerGroup = m_audioMixerGroups[channel];
            audioSource.Play(delay);
            audioSource.loop = isLooping;
            tempAudio.transform.parent = transform;
            Destroy(tempAudio, audioClipReference.clip.length);
        }
    }
}


