using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerController : MonoBehaviour
    {
        public GameObject customerChatUI;
        public TextMeshProUGUI mainText;
        public Button yesButton;
        public Button whatButton;
        
        private System.Action _onYesAction;
        private System.Action _onWhatAction;

        private static readonly int Enter = Animator.StringToHash("Enter");
        public void ShowChat(string text, System.Action onYes, System.Action onWhat)
        {
            mainText.text = text;
            customerChatUI.SetActive(true);

            _onYesAction = onYes;
            _onWhatAction = onWhat;
        }

        public void OnClickYes()
        {
            customerChatUI.SetActive(false);
            SceneManager.Instance.currentCustomerData = CustomerChatManager.Instance.customerDataSo; // 넘어가기 전에 손님의 정보 저장
            _onYesAction?.Invoke();
            Debug.Log("제작 씬으로 이동합니다");
        }

        public void OnClickWhat()
        {
            customerChatUI.SetActive(false);
            _onWhatAction?.Invoke();
            CustomerChatManager.Instance.animator.SetTrigger(Enter);
        }
    }
}
