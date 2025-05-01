using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerChatManager : MonoBehaviour
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
            GameManagerScript.Instance.currentCustomerData = CustomerController.Instance.customerData;
            Debug.Log("제작 씬으로 이동합니다");
        }

        public void OnClickWhat()
        {
            customerChatUI.SetActive(false);
            
            CustomerController.Instance.animator.SetTrigger(Enter);
        }
    }
}
