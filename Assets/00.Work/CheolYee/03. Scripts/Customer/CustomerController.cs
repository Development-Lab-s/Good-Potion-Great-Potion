using System.Collections;
using _00.Work.Base._02._Sprites.Manager;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject customerChatUI;
        [SerializeField] private TextMeshProUGUI mainText;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button realYesButton;
        [SerializeField] private Button whatButton;
        [SerializeField] private Button whatButton2;
        [SerializeField] private Button noButton;

        private void Awake()
        {
            customerChatUI.SetActive(false);
        }


        private void Start()
        {
            CustomerAnimAndRendererSetting();
            StartCoroutine(SceneManagerScript.Instance.isFinishedCrafting //만약 제작이 끝났다면?
                ? CustomerExitRoutine() // 맞다면 이거 실행
                : CustomerEnterRoutine()); // 아니라면 이거 실행
        }

        private static void CustomerAnimAndRendererSetting()
        {
            if (CustomerChatManager.Instance.animator == null)
            {
                CustomerChatManager.Instance.animator = GameObject.FindWithTag("CustomerAnimator")?.GetComponent<Animator>();
                if (CustomerChatManager.Instance.animator == null)
                {
                    Debug.LogWarning("Animator 재할당 실패: 태그가 올바른지 확인하세요.");
                }
            }

            if (CustomerChatManager.Instance.spriteRenderer == null)
            {
                CustomerChatManager.Instance.spriteRenderer = GameObject.FindWithTag("CustomerRenderer")?.GetComponent<SpriteRenderer>();
                if (CustomerChatManager.Instance.spriteRenderer == null)
                {
                    Debug.LogWarning("Animator 재할당 실패: 태그가 올바른지 확인하세요.");
                }
            }
        }

        public void OnClickYes() // yes버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            // 넘어가기 전에 손님의 정보 저장 (힌트 없음)
            SceneManagerScript.Instance.currentCustomerData = 
                CustomerChatManager.Instance.customerDataSo; //넘어가기 전에 손님의 정보 저장
            SceneManagerScript.Instance.LoadToScene("TestCreate");
            Debug.Log("제작 씬으로 이동합니다");
        }

        public void OnClickWhat() // what 버튼을 눌렀을 때 실행
        {
            whatButton.gameObject.SetActive(false); //네?버튼과
            yesButton.gameObject.SetActive(false); //네(처음)버튼을 비활성화
            
            realYesButton.gameObject.SetActive(true); //네(마지막) 버튼과
            whatButton2.gameObject.SetActive(true); //네?(2번째) 활성화
            
            StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedHint,
                CustomerChatManager.Instance.customerDataSo.waitingChatTime)); // 힌트 대사 TMP출력
            
            TimerManager.Instance.LessTimer(3); // 디메리트 타이머 3초 감소
        }
        
        public void OnClickWhat2() // what2 버튼을 눌렀을 때 실행
        {
            whatButton.gameObject.SetActive(false); //네?버튼 비활성화
            
            noButton.gameObject.SetActive(true); //아니요 버튼을 활성화
            
            StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedHint2,
                CustomerChatManager.Instance.customerDataSo.waitingChatTime)); // 힌트 대사 TMP출력
            
            TimerManager.Instance.LessTimer(3); // 디메리트 타이머 3초 감소
        }
        
        public void OnClickNo() // no 버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            StartCoroutine(CustomerExitRoutine());
        }

        private IEnumerator CustomerEnterRoutine()
        {
            CustomerChatManager.Instance.PlayEnterAnimation();// 등장 애니메이션 실행

            yield return new WaitForSeconds(0.5f); // 1단기다려
            
            //버튼 세팅
            whatButton.gameObject.SetActive(true);
            yesButton.gameObject.SetActive(true);
            realYesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            
            StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedLine, //메인 대사 출력
                CustomerChatManager.Instance.customerDataSo.waitingChatTime));
        }

        private IEnumerator CustomerExitRoutine()
        {
            Debug.Log("퇴장 루틴");
            //버튼 세팅
            customerChatUI.SetActive(true);
            whatButton.gameObject.SetActive(false);
            whatButton2.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(false);
            realYesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            
            if (SceneManagerScript.Instance.isSuccessCrafting) //만약 포션 만드는데에 성공했다면
            {
                StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedExitLine, //퇴장 대사(긍정) 출력
                    CustomerChatManager.Instance.customerDataSo.waitingChatTime));
            }
            else
            {
                StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedForcedExitLine, //퇴장 대사(부정) 출력
                    CustomerChatManager.Instance.customerDataSo.waitingChatTime));
            }
            
            yield return new WaitForSeconds(2f);
            
            CustomerChatManager.Instance.PlayExitAnimation();// 퇴장 애니메이션 실행
            
            yield return new WaitForSeconds(1f);
            EndCustomerCycle();
        }

        private void EndCustomerCycle() //손님 오늘 몇명왔나 확인하는 메서드
        {
            int maxCustomersThisWeek = 4 + SceneManagerScript.Instance.currentWeek;

            if (SceneManagerScript.Instance.customerIndexToDay <= maxCustomersThisWeek)
            {
                SceneManagerScript.Instance.customerIndexToDay++;
            }
            else
            {
                SceneManagerScript.Instance.FinishTimer();
            }
        }
        

        private IEnumerator TypingChat(string line, float time) // 타이핑 모션(대사와, 타이핑 대기시간 받아옴)
        {
            mainText.text = null;

            foreach (var t in line)
            {
                mainText.text += t;
                yield return new WaitForSeconds(time);
            }
        }
    }
}
