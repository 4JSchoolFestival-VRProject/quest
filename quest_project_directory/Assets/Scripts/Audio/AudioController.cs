using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        public static AudioController singleton;
        private AudioSource m_AudioSource;

        [SerializeField] private List<AudioClip> m_BGMList = new List<AudioClip>();
        [SerializeField] private List<AudioClip> m_SEList = new List<AudioClip>();

        public List<AudioClip> BGMList { get { return m_BGMList; } }
        public List<AudioClip> SEList { get { return m_SEList; } }

        private void Awake()
        {
            if (singleton != null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                return;
            }
            singleton = this;
            DontDestroyOnLoad(gameObject);

            m_AudioSource = GetComponent<AudioSource>();
        }

        public void PlayBGM(int n)
        {
            if (m_BGMList.Count <= n) return;

            m_AudioSource.clip = m_BGMList[n];
            m_AudioSource.Play();
        }

        public void StopBGM()
        {
            m_AudioSource.Stop();
        }
    }
}