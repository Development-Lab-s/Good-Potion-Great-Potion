using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.Customer.Manager
{
    public class GameManagerScript : MonoBehaviour
    {
        public static GameManagerScript Instance {get; private set;}
        
        public CustomerDataSo currentCustomerData;

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
    }
}
