using _00.Work.Base._02._Sprites.Manager;
using _00.Work.Base._02._Sprites.Manager.FadeManager;
using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _00.Work.CheolYee._03._Scripts.Customer.Manager
{
    public class SceneManagerScript : MonoBehaviour
    {
        public static SceneManagerScript Instance {get; private set;}

        public int currentDay = 1; // 지금이 몇 일차인가?
        public int currentWeek = 1; // 지금이 몇 주차인가?
        public int customerIndexToDay = 1; // 이 손님은 오늘의 몇 번째 손님인가?
        public int isSuccessCraftingCount = 0; // 포션 제작 성공 횟수
        
        public bool isFinishedCrafting; // 포션 제작이 끝났는가?
        public bool isSuccessCrafting; // 포션 제작이 성공했는가?
        
        public int currentRandomIndex; //랜덤으로 대사 뽑는거라 이거도 가져옴
        public int toDayTotalMoney; //오늘의 총 번 돈
        public CustomerDataSo currentCustomerData; // 씬이 넘어가도 손님 정보가 저장되야하므로 이곳에 현재 정보 저장

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            TimerManager.Instance.OnTimerFinished += FinishTimer; // 타이머 종료 이벤트 구독
        }

        public void LoadToScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex); // 씬 인덱스으로 이동한다
        }

        public void ResetValues() // 다음날 갈 때 초기화될 값들을 한번에 초기화 및 설정
        {
            if (currentDay % 4 == 0) currentWeek++;
            customerIndexToDay = 0;
            isSuccessCrafting = false;
            isFinishedCrafting = false;
            toDayTotalMoney = 0;
            isSuccessCraftingCount = 0;
            InventoryManager.Instance.totalSpentMoney = 0;
            InventoryManager.Instance.totalHerbCount = 0;
        }
        
        public void FinishTimer() //타이머 끝났을 때 로직
        {
            Debug.Log("타이머가 종료되었습니다. 하루 영업 종료");
            StartCoroutine(FadeManager.Instance.EndDayCycle());
        }
    }
}
