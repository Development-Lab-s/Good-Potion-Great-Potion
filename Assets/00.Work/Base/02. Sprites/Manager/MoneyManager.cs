using System;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager
{
    public class MoneyManager : MonoBehaviour
    {
        //전체 프로젝트에서 단 하나만 있는 GameManager
        public static MoneyManager Instance { get; private set; }

        [SerializeField] private int money;
        //다른 곳에서 돈 변수를 써야할 때 MoneyManager.money 사용 가능(얘 int형임))
        public int Money => money;

        //Money가 바뀌었을 때 모든 구독자들에게 방송하는 시스템
        public event Action<int> OnMoneyChanged;

        private void Awake()
        {
            //만약 이미 인스턴스가 있다면 없애기
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            //인스턴스가 없을 때 이걸로 지정
            Instance = this;
            //씬이 바뀌어도 사라지지 않게하기
            DontDestroyOnLoad(this.gameObject);
        }

        //돈 추가할 때 (어디서든 MoneyManager.Instance.AddMoney(돈 추가값(int형))로 사용 가능)
        public void AddMoney(int amount)
        {
            //돈 += 돈 추가값(int)
            money += amount;
            //구독자가 null이 아니라면(구독자가 이벤트 듣고 있으면), 실행해(돈이 바뀜)
            OnMoneyChanged?.Invoke(money);
        }

        //돈 추가할 때 (어디서든 MoneyManager.Instance.SpendMoney(돈 감소값(int형))로 사용 가능)
        public void SpendMoney(int amount)
        {
            //돈 += 돈 추가값(int)
            money -= amount;
            //구독자가 null이 아니라면(구독자가 이벤트 듣고 있으면), 실행해(돈이 바뀜, (방송을 한다))
            OnMoneyChanged?.Invoke(money);
        }

        //돈 추가할 때 (어디서든 MoneyManager.Instance.SetMoney(돈 설정값(int형))로 사용 가능)
        public void SetMoney(int value)
        {
            //돈 = 돈 설정값(int)
            money = value;
            //구독자가 null이 아니라면(구독자가 이벤트 듣고 있으면), 실행해(돈이 설정됨, (방송을 한다))
            OnMoneyChanged?.Invoke(money);
        }
    }
}
