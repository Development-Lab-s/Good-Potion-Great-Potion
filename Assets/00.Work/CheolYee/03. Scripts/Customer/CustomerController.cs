using System;
using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
    public class CustomerController : MonoBehaviour
    {
        public static CustomerController Instance {get; private set;}
        
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        
        public CustomerDataSo customerData;

        private static readonly int Enter = Animator.StringToHash("Enter");
        private static readonly int Exit = Animator.StringToHash("Exit");

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                if (Instance != this)
                    Destroy(this.gameObject);
            }
        }

        public void SetCustomerSprite(CustomerDataSo data)
        {
            customerData = data;
            spriteRenderer.sprite = customerData.customerSprite;
        }

        public string GetChatLine() // 현재 손님의 대사를 랜덤으로 가져오는 메서드
        {
            string currentLine = customerData.mainLines
                [Random.Range(0, customerData.mainLines.Length)];
            
            return currentLine;
        }
        
        public string GetPotion() // 현재 손님이 주문하는 포션을 랜덤으로 가져오는 메서드
        {
            string currentPotion = customerData.requiredPotions;
            
            return currentPotion;
        }
        
        public void PlayEnterAnimation()
        {
            animator.SetTrigger(Enter);
        }

        public void PlayExitAnimation()
        {
            animator.SetTrigger(Exit);
        }

    }
}
