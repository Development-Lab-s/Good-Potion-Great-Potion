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
            StartCoroutine(CustomerRoutine());
        }

        public void OnClickYes() // yes버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            // 넘어가기 전에 손님의 정보 저장 (힌트 없음)
            SceneManagerScript.Instance.currentCustomerData = 
                CustomerChatManager.Instance.customerDataSo; //넘어가기 전에 손님의 정보 저장
            Debug.Log("제작 씬으로 이동합니다");
        }
        
        public void OnClickRealYes() // realYes버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            // 넘어가기 전에 손님의 정보 저장 (힌트 있음)
            SceneManagerScript.Instance.currentCustomerData = 
                CustomerChatManager.Instance.customerDataSo; // 넘어가기 전에 손님의 정보 저장
            Debug.Log("제작 씬으로 이동합니다");
        }

        public void OnClickWhat() // what 버튼을 눌렀을 때 실행
        {
            whatButton.gameObject.SetActive(false); //네?버튼과
            yesButton.gameObject.SetActive(false); //네(처음)버튼을 비활성화
            
            realYesButton.gameObject.SetActive(true); //네(마지막) 버튼과
            whatButton2.gameObject.SetActive(true); //네?(2번째) 활성화
            
            mainText.text = CustomerChatManager.Instance.SelectedHint; // 힌트 대사 TMP출력
            
            TimerManager.Instance.LessTimer(3); // 디메리트 타이머 3초 감소
        }
        
        public void OnClickWhat2() // what2 버튼을 눌렀을 때 실행
        {
            whatButton.gameObject.SetActive(false); //네?버튼 비활성화
            
            noButton.gameObject.SetActive(true); //아니요 버튼을 활성화
            
            mainText.text = CustomerChatManager.Instance.SelectedHint2; // 힌트 대사 TMP출력
            
            TimerManager.Instance.LessTimer(3); // 디메리트 타이머 3초 감소
        }
        
        public void OnClickNo() // no 버튼을 눌렀을 때 실행
        {
            customerChatUI.SetActive(false);
            CustomerChatManager.Instance.PlayExitAnimation();
        }

        private IEnumerator CustomerRoutine()
        {
            CustomerChatManager.Instance.PlayEnterAnimation();

            yield return new WaitForSeconds(1.5f);
            //버튼 세팅
            whatButton.gameObject.SetActive(true);
            yesButton.gameObject.SetActive(true);
            realYesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            
            mainText.text = CustomerChatManager.Instance.SelectedLine;
        }
    }
}
