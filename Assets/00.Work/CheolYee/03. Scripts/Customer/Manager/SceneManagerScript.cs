using _00.Work.Base._02._Sprites.Manager;
using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _00.Work.CheolYee._03._Scripts.Customer.Manager
{
    public class SceneManagerScript : MonoBehaviour
    {
        public static SceneManagerScript Instance {get; private set;}

        public int currentDay = 1; // 지금이 몇 일차인가?
        public int currentWeek = 1; // 지금이 몇 주차인가?
        public int customerIndexToDay; // 이 손님은 오늘의 몇 번째 손님인가?
        public int isFinishedCrafting; // 포션 제작이 끝났는가?
        
        public CustomerDataSo currentCustomerData; // 씬이 넘어가도 손님 정보가 저장되야하므로 이곳에 현재 정보 저장

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                TimerManager.Instance.OnTimerFinished += FinishTimer; // 타이머 종료 이벤트 구독
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("씬 로드됨");
        }

        public void LoadToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName); // 씬 이름으로 이동한다
        }
        
        private void FinishTimer()
        {
            Debug.Log("타이머가 종료되었습니다. 하루 영업 종료");
            //여기에 onTImerFinished?.Invoke() 해서 한번에 실행되게 만들 수 있음
        }
        
        [SerializeField] private UnityEvent onTimerFinished; // 유니티 이벤트로 여러개 한번에 실행 가능
    }
}
