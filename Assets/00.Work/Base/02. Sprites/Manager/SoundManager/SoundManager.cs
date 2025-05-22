using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.SoundManager
{
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [Header("BGM Clips")]
    public AudioClip startBGM; //시작 시 브금
    public AudioClip mainBGM; // 메인 씬 들어갈 시 브금
    
    [Header("UI")]
    public Slider bgmSlider; //메뉴의 슬라이더
    public Image volumeIcon; // 볼륨 아이콘
    public Sprite volumeMute; // 볼륨 0일때
    public Sprite volumeLow; // 볼륨 작을 때
    public Sprite volumeMid; // 볼륨 반일 때
    public Sprite volumeHigh; // 볼륨 높을 때

    private AudioSource _audioSource; // 현재 오디오
    private string _currentScene; // 현재 씬

    void Awake() //싱글톤 기본
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _audioSource = gameObject.AddComponent<AudioSource>(); //오디오 소스 추가
            _audioSource.loop = true; // 브금 무한반복 온
            _audioSource.playOnAwake = false; // 어웨이크에 바로 재생 중지

            _currentScene = SceneManager.GetActiveScene().name; // 현재 씬 이름 가져와
            PlayBGMForScene(_currentScene); // BGM 시작하기

            SceneManager.sceneLoaded += OnSceneLoaded; // 씬 변경될 때 자동으로 실행되게 액션 구독해주기

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
        {
            // AudioManager에 할당
            if (Instance != null)
            {
                Instance.ReassignUI();
            }
            
            float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
            bgmSlider.value = savedVolume;
            _audioSource.volume = savedVolume;
            UpdateVolumeIcon(savedVolume);

            bgmSlider.onValueChanged.AddListener(OnVolumeChanged); // 슬라이더 자체 이벤트에 리스너로 볼륨 변경 추가
        }
        
        public void OnVolumeChanged(float value) //볼륨이 변경되었다면
        {
            _audioSource.volume = value;
            PlayerPrefs.SetFloat("BGMVolume", value);
            UpdateVolumeIcon(value);
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

        void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 씬이 변경되었을 때
        {
            if (scene.name == _currentScene) return; // 만약 씬 네임이 현재 씬과 같다면 리턴

            _currentScene = scene.name; //아니라면 현재 씬 이름을 current씬에 할당
            PlayBGMForScene(_currentScene); // BGM 플레이에 넘기기
        }
        
        public void ReassignUI()
        {
            if (bgmSlider != null)
            {
                float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
                bgmSlider.value = savedVolume;
                bgmSlider.onValueChanged.RemoveListener(OnVolumeChanged); // 중복 방지
                bgmSlider.onValueChanged.AddListener(OnVolumeChanged);
            }

            UpdateVolumeIcon(_audioSource.volume);
        }

        void PlayBGMForScene(string sceneName)
        {
            AudioClip clipToPlay = null;

            switch (sceneName)
            {
                case "Start":
                    clipToPlay = startBGM;
                    break;
                case "Tutorial":
                    clipToPlay = startBGM;
                    break;
                case "Main":
                    clipToPlay = mainBGM;
                    break;
                case "Create":
                    clipToPlay = mainBGM;
                    break;
                case "MiniGame1":
                    clipToPlay = mainBGM;
                    break;
                case "MiniGame2":
                    clipToPlay = mainBGM;
                    break;
                case "EndScene":
                    clipToPlay = startBGM;
                    break;
                // 필요 시 다른 씬도 추가
            }

            if (clipToPlay != null && _audioSource.clip != clipToPlay)
            {
                _audioSource.clip = clipToPlay;
                _audioSource.Play();
            }
        }
    }
}
