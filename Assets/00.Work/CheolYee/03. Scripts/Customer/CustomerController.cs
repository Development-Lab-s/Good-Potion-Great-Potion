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
        
        private Coroutine _typingCoroutine;
        

        private void Awake()
        {
            customerChatUI.SetActive(false);
        }


        private void Start()
        {
            TimerManager.Instance.OnTimerFinished += ResetButtons; // 타이머 종료 이벤트에 대화창 끄는거 넣기
            
            
            CustomerAnimAndRendererSetting();
            StartCoroutine(SceneManagerScript.Instance.isFinishedCrafting //만약 제작이 끝났다면?
                ? CustomerExitRoutine() // 맞다면 이거 실행
                : CustomerEnterRoutine()); // 아니라면 이거 실행
        }

        private void OnDisable()
        {
            TimerManager.Instance.OnTimerFinished -= ResetButtons; // 구독 해제
        }

        private void CustomerAnimAndRendererSetting() //애니메이터와 랜더러를 둘 다 재할당 하는 메서드
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
                    Debug.LogWarning("SpriteRenderer 재할당 실패: 태그가 올바른지 확인하세요.");
                }
                else
                {
                    CustomerChatManager.Instance.GetCustomerSprite(); //스프라이트 설정
                }
            }
        }

        public void OnClickYes() // yes버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            // 넘어가기 전에 손님의 정보 저장 (힌트 없음)
            SceneManagerScript.Instance.currentCustomerData = 
                CustomerChatManager.Instance.customerDataSo; //넘어가기 전에 손님의 정보 저장
            SceneManagerScript.Instance.LoadToScene(2);
            Debug.Log("제작 씬으로 이동합니다");
        }

        public void OnClickWhat() // what 버튼을 눌렀을 때 실행
        {
            whatButton.gameObject.SetActive(false); //네?버튼과
            yesButton.gameObject.SetActive(false); //네(처음)버튼을 비활성화
            
            realYesButton.gameObject.SetActive(true); //네(마지막) 버튼과
            whatButton2.gameObject.SetActive(true); //네?(2번째) 활성화
            
            StopTypingCorutine();
            _typingCoroutine = StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedHint,
                CustomerChatManager.Instance.customerDataSo.waitingChatTime)); // 힌트 대사 TMP출력
            
            TimerManager.Instance.LessTimer(3); // 디메리트 타이머 3초 감소
        }
        
        public void OnClickWhat2() // what2 버튼을 눌렀을 때 실행
        {
            whatButton.gameObject.SetActive(false); //네?버튼 비활성화
            
            noButton.gameObject.SetActive(true); //아니요 버튼을 활성화
            
            StopTypingCorutine();
            _typingCoroutine = StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedHint2,
                CustomerChatManager.Instance.customerDataSo.waitingChatTime)); // 힌트 대사 TMP출력
            
            TimerManager.Instance.LessTimer(3); // 디메리트 타이머 3초 감소
        }
        
        public void OnClickNo() // no 버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            
            StartCoroutine(CustomerExitRoutine());
        }

        private IEnumerator CustomerEnterRoutine() //손님 등장 루틴
        {
            CustomerChatManager.Instance.GetRandomCustomerData(); //손님의 데이터를 돌려
            
            Debug.Log("손놈이 등장했다");
            CustomerChatManager.Instance.PlayEnterAnimation();// 등장 애니메이션 실행
            CustomerChatManager.Instance.PlayIdleAnimation();// 등장 애니메이션 실행

            yield return new WaitForSeconds(0.5f); // 1단기다려
            
            //버튼 세팅
            whatButton.gameObject.SetActive(true);
            yesButton.gameObject.SetActive(true);
            realYesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);

            StopTypingCorutine();
            _typingCoroutine = StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedLine, //메인 대사 출력
                CustomerChatManager.Instance.customerDataSo.waitingChatTime));
        }

        private void ResetButtons() // 모든 버튼 UI를 끄는 메서드
        {
            CustomerChatManager.Instance.PlayExitAnimation();
            customerChatUI.SetActive(false);
        }

        private IEnumerator CustomerExitRoutine() //손님 퇴장 루틴
        {
            Debug.Log("퇴장 루틴");
            CustomerChatManager.Instance.PlayIdleAnimation();// 가만히 있는 애니메이션 실행
            //버튼 세팅
            customerChatUI.SetActive(true);
            whatButton.gameObject.SetActive(false);
            whatButton2.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(false);
            realYesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            
            if (SceneManagerScript.Instance.isSuccessCrafting) //만약 포션 만드는데에 성공했다면
            {
                StopTypingCorutine();
                yield return _typingCoroutine = StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedExitLine, //퇴장 대사(긍정) 출력
                    CustomerChatManager.Instance.customerDataSo.waitingChatTime));
                MoneyManager.Instance.AddMoney(SceneManagerScript.Instance.currentCustomerData.price); //돈UI에 추가
                SceneManagerScript.Instance.toDayTotalMoney += //오늘 번 돈 +포션 가격해준다
                    SceneManagerScript.Instance.currentCustomerData.price;
            }
            else if (!SceneManagerScript.Instance.isSuccessCrafting)
            {
                StopTypingCorutine();
                yield return _typingCoroutine = StartCoroutine(TypingChat(CustomerChatManager.Instance.SelectedForcedExitLine, //퇴장 대사(부정) 출력
                    CustomerChatManager.Instance.customerDataSo.waitingChatTime));
            }
            
            yield return new WaitForSeconds(1f);
            
            customerChatUI.SetActive(false);
            CustomerChatManager.Instance.PlayExitAnimation();// 퇴장 애니메이션 실행
            
            yield return new WaitForSeconds(1.5f);
            
            //여기에 손님 정보 초기화하고 다시 손님 오게하면 됨
            if (EndCustomerCycle()) // 손님 사이클이 끝났는가?
                TimerManager.Instance.SetTimer(1); // 끝났다면 타이머 종료(하루 종료)
            else
                StartCoroutine(CustomerEnterRoutine()); // 끝나지 않았다면 다시 실행
            //만약 오늘 손님이 다 왔다면 하루 종료하면 됨
        }

        private void StopTypingCorutine()
        {
            if (_typingCoroutine != null)
                StopCoroutine(_typingCoroutine);
        }

        private bool EndCustomerCycle() //손님 오늘 몇명왔나 확인하는 메서드
        {
            int maxCustomersThisWeek = 4 + SceneManagerScript.Instance.currentWeek; //총 손님 수 계산식

            if (++SceneManagerScript.Instance.customerIndexToDay < maxCustomersThisWeek) 
                //현재 손님수 +1 이 총 손님수보다 크면 true 작으면 false반환
            {
                return false;
            }
            
            return true;
        }
        

        private IEnumerator TypingChat(string line, float time) // 타이핑 모션(대사와, 타이핑 대기시간 받아옴)
        {
            mainText.text = null;

            foreach (var text in line)
            {
                mainText.text += text;
                yield return new WaitForSeconds(time);
            }
        }
    }
}
