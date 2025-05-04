using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
public class CustomerChatManager : MonoBehaviour
    {
        public static CustomerChatManager Instance {get; private set;} // 싱글톤
    
        public SpriteRenderer spriteRenderer; // 스프라이트 렌더러 (손님 스프라이트)
        public Animator animator; // 손님 애니메이션 실행을 위한 애니메이터
        public CustomerDataList customerDataList; // 리스트SO를 받아와서 주 별로 받아와 랜덤을 돌릴거임
        
        public CustomerDataSo customerDataSo; // 랜덤으로 돌린 손님의 진짜 데이터가 저장될 SO 저장변수

        private static readonly int Enter = Animator.StringToHash("Enter"); // 그냥 스트링으로 하는 거 보다 hash가 더 좋아서 함
        private static readonly int Exit = Animator.StringToHash("Exit"); // 그냥 스트링으로 하는 거 보다 hash가 더 좋아서 함 2

        private void Awake() // 싱글톤 기본
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

        private void Start()
        {
            GetRandomCustomerData();
        }

        public void GetRandomCustomerData()
        {
            switch (SceneManager.Instance.currentWeek) // 몇주차인지 switch 문으로 확인하기
            {
                case 1:
                {
                    customerDataSo = customerDataList.customerLists1Week // 손님의 데이터를 랜덤으로 뽑아와 변수에 저장
                        [Random.Range(0, customerDataList.customerLists1Week.Count)];
                    break; //스위치문 탈출
                }
                case 2:
                {
                    customerDataSo = customerDataList.customerLists2Week
                        [Random.Range(0, customerDataList.customerLists1Week.Count)];
                    break;
                }
                case 3:
                {
                    customerDataSo = customerDataList.customerLists3Week
                        [Random.Range(0, customerDataList.customerLists1Week.Count)];
                    break;
                }
            }
        }

        public void SetCustomerSprite() // 현재 손님의 스프라이트를 설정하는 메서드
        {
            spriteRenderer.sprite = customerDataSo.customerSprite; // SO에 있는 sprite를 렌더러 스프라이트로 바꿔줌
        }

        public string GetChatLine() // 현재 손님의 대사를 랜덤으로 가져오는 메서드
        {
            string currentLine = customerDataSo.mainLines // 현재 출력된 대사를 SO에서 랜덤으로 받아와 currentLine 변수에 저장
                [Random.Range(0, customerDataSo.mainLines.Length)];
        
            return currentLine; // 가져온 대사 데이터 리턴
        }
    
        public string GetPotion() // 현재 손님이 주문하는 포션을 가져오는 메서드
        {
            string currentPotion = customerDataSo.requiredPotions; //현재 손님에게 저장된 SO를 받아와 currentPotion 변수에 저장
        
            return currentPotion; // 포션 데이터 리턴
        }
    
        public void PlayEnterAnimation()
        {
            animator.SetTrigger(Enter); // 손님 등장 애니메이션 재생
        }

        public void PlayExitAnimation()
        {
            animator.SetTrigger(Exit); // 손님 퇴장 애니메이션 재생
        }
    }
}
