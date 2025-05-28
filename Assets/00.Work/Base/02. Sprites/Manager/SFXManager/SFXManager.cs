using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.SFXManager
{
    public class SFXManager : MonoBehaviour
    {
        public static SFXManager Instance { get; private set; }

        [Header("SFX List")]
        [SerializeField] private AudioClip[] sfxClips;
        
        [Header("UI")]
        public Slider sfxSlider; //메뉴의 슬라이더
        public Image volumeIcon; // 볼륨 아이콘
        public Sprite volumeMute; // 볼륨 0일때
        public Sprite volumeLow; // 볼륨 작을 때
        public Sprite volumeMid; // 볼륨 반일 때
        public Sprite volumeHigh; // 볼륨 높을 때

        private AudioSource _audioSource;

        private void Awake()
        {
            // 싱글톤 패턴
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
                _audioSource = gameObject.AddComponent<AudioSource>();
                _audioSource.playOnAwake = false;
            }
            else
            {
                Destroy(gameObject); // 중복 방지
            }
        }

        private void Start()
        {
            if (Instance != null)
            {
                Instance.ReassignUI();
            }
            
            float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
            sfxSlider.value = savedVolume;
            _audioSource.volume = savedVolume;
            UpdateVolumeIcon(savedVolume);

            sfxSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        public void Play(int index)
        {
            if (index < 0 || index >= sfxClips.Length)
            {
                Debug.LogWarning("잘못된 효과음 인덱스");
                return;
            }

            PlayClip(sfxClips[index]);
        }
        
        public void PlayClip(AudioClip clip)
        {
            if (_audioSource.isPlaying)
                _audioSource.Stop(); // 이전 효과음 정지

            _audioSource.clip = clip;
            _audioSource.Play();
        }
        
        public void OnVolumeChanged(float value) //볼륨이 변경되었다면
        {
            _audioSource.volume = value;
            PlayerPrefs.SetFloat("SFXVolume", value);
            UpdateVolumeIcon(value);
        }
        
        public void ReassignUI()
        {
            if (sfxSlider != null)
            {
                float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
                sfxSlider.value = savedVolume;
                sfxSlider.onValueChanged.RemoveListener(OnVolumeChanged); // 중복 방지
                sfxSlider.onValueChanged.AddListener(OnVolumeChanged);
            }

            UpdateVolumeIcon(_audioSource.volume);
        }

        private void UpdateVolumeIcon(float volume)
        {
            if (volumeIcon == null) return; // 볼륨 아이콘이 널이라면 되돌려준다
            
            if (volume <= 0.01f) //볼륨이 0.01보다 작으면 뮤트 아이콘
                volumeIcon.sprite = volumeMute;
            else if (volume <= 0.4f) //볼륨이 0.4보다 작으면 낮은 볼륨 아이콘
                volumeIcon.sprite = volumeLow;
            else if (volume <= 0.8f) //볼륨이 0.8보다 작으면 중간 볼륨 아이콘
                volumeIcon.sprite = volumeMid;
            else //볼륨이 0.8보다 크면 높은 볼륨 아이콘
                volumeIcon.sprite = volumeHigh;
        }
    }
}
