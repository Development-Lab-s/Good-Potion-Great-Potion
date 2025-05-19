using System;
using _00.Work.Base._02._Sprites.Manager.FadeManager;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using _00.Work.CheolYee._05._SO.CustomerChatSO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _00.Work.CheolYee._03._Scripts.Customer
{
public class CustomerChatManager : MonoBehaviour
    {
        public static CustomerChatManager Instance {get; private set;} // 싱글톤
        
        public CustomerDataList customerDataList; // 리스트SO를 받아와서 주 별로 받아와 랜덤을 돌릴거임
        
        public CustomerDataSo customerDataSo; // 랜덤으로 돌린 손님의 진짜 데이터가 저장될 SO 저장변수
        
        public SpriteRenderer spriteRenderer; // 스프라이트 렌더러 (손님 스프라이트)
        public Animator animator; // 손님 애니메이션 실행을 위한 애니메이터

        private int _randomIndex = -1; //대사 불러올 때 랜덤 값을 저장할 변수
        public string SelectedLine { get; private set; } // 랜덤값의 인덱스로 가져온 대사가 저장될 변수
        public string SelectedHint {get; private set;}// 랜덤값의 인덱스로 가져온 힌트가 저장될 변수
        public string SelectedHint2 {get; private set;}// 랜덤값의 인덱스로 가져온 힌트(2번째)가 저장될 변수
        public string SelectedExitLine {get; private set;}// 랜덤값의 인덱스로 가져온 퇴장 대사가 저장될 변수
        public string SelectedForcedExitLine {get; private set;}// 랜덤값의 인덱스로 가져온 강제퇴장 대사가 저장될 변수
        
        
        private static readonly int Enter = Animator.StringToHash("Enter"); // 스트링으로 하는 거 보다 hash가 더 좋아서 함
        private static readonly int Exit = Animator.StringToHash("Exit"); // 스트링으로 하는 거 보다 hash가 더 좋아서 함 2
        private static readonly int Idle = Animator.StringToHash("Idle"); // 스트링으로 하는 거 보다 hash가 더 좋아서 함 3

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
            if(SceneManagerScript.Instance.isFinishedCrafting) //포션 제작 완료라면 이거 실행안함
                return;
            
            
            GetRandomCustomerData();
        }
        

        public void GetRandomCustomerData()
        {
            switch (SceneManagerScript.Instance.currentWeek) // 몇주차인지 switch 문으로 확인하기
            {
                case 1:
                {
                    customerDataSo = customerDataList.customerLists1Week // 손님의 데이터(1주차)중 한명을
                        [Random.Range(0, customerDataList.customerLists1Week.Count)]; // 랜덤으로 뽑아와 변수에 저장
                    PickRandomLine(); // 대사랑 힌트도 뽑아서 변수저장
                    GetCustomerSprite(); // 스프라이트도 미리 바꿈
                    break; //스위치문 탈출
                }
                case 2:
                {
                    customerDataSo = customerDataList.customerLists2Week
                        [Random.Range(0, customerDataList.customerLists1Week.Count)];
                    PickRandomLine(); // 대사랑 힌트도 뽑아서 변수저장
                    GetCustomerSprite(); // 스프라이트도 미리 바꿈
                    break;
                }
                case 3:
                {
                    customerDataSo = customerDataList.customerLists3Week
                        [Random.Range(0, customerDataList.customerLists1Week.Count)];
                    PickRandomLine(); // 대사랑 힌트도 뽑아서 변수저장
                    GetCustomerSprite(); // 스프라이트도 미리 바꿈
                    break;
                }
            }
        }

        public void GetCustomerSprite() // 현재 손님의 스프라이트를 설정하는 메서드
        {
            spriteRenderer.sprite = customerDataSo.customerSprite; // SO에 있는 sprite를 렌더러 스프라이트로 바꿔줌
        }

        public void PickRandomLine()
        {
            _randomIndex = Random.Range(0, customerDataSo.mainLines.Length); // 랜덤으로 값 가져오기
            SceneManagerScript.Instance.currentRandomIndex = _randomIndex; //랜덤값을 저장후 보내줌
            SelectedLine = customerDataSo.mainLines[_randomIndex]; // 랜덤값의 인덱스에 해당하는 대사 가져오기
            SelectedHint = customerDataSo.hint[0]; // 힌트 가져오기
            SelectedHint2 = customerDataSo.hint2[0]; // 두번째 힌트 가져오기
            SelectedExitLine = customerDataSo.exitLines[0]; // 강제퇴장대사 가져오기
            SelectedForcedExitLine = customerDataSo.forcedExitLines[0]; // 강제퇴장대사 가져오기
        }
        
        public void PlayEnterAnimation()
        {
            animator.SetTrigger(Enter); // 손님 등장 애니메이션 재생
        }

        public void PlayExitAnimation()
        {
            animator.SetTrigger(Exit); // 손님 퇴장 애니메이션 재생
        }

        public void PlayIdleAnimation()
        {
            animator.SetTrigger(Idle); //손님 아이들 상태 재생
        }
    }
}
