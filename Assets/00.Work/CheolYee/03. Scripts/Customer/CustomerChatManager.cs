using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerChatManager : MonoBehaviour
    {
        public GameObject customerChatUI;
        public TextMeshPro mainText;
        public Button yesButton;
        public Button whatButton;
        
        private System.Action _onYesAction;
        private System.Action _onWhatAction;

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
            _onYesAction?.Invoke();
        }

        public void OnClickWhat()
        {
            customerChatUI.SetActive(false);
            _onWhatAction?.Invoke();
        }
    }
}
