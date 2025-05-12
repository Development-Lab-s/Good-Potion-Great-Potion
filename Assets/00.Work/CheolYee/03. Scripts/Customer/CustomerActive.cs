using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerActive : MonoBehaviour
    {
        [SerializeField] private GameObject customerChatUI;
        
        public void SetActiveChatUI()
        {
            customerChatUI.SetActive(true);
        }
        
        public void DeSetActiveChatUI()
        {
            customerChatUI.SetActive(false);
        }
    }
}
