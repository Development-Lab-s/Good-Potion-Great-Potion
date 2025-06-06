using System;
using System.Collections.Generic;
using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

namespace _00.Work.JaeHun._01._Scripts
{
    public class InventoryManager : MonoBehaviour     //재료를 그냥 허브라고 썼으니 양해바람.
    {
        //전체 프로젝트에서 단 하나만 있는 GameManager
        public static InventoryManager Instance { get; private set; }

        //허브를 종류별로 다루기 위한코드.
        private Dictionary<string, int> herbInventory = new Dictionary<string, int>();

        // 전체 사용 금액
        public int totalSpentMoney = 0;
        // 총 구매한 허브 수
        public int totalHerbCount = 0;

        //Inventory가 바뀌었을 때 모든 구독자들에게 방송하는 시스템
        public event Action<string, int> OnHerbChanged;

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
        //재료추가
        public void AddHerb(string herbName, int price)     //재료추가.
        {
                
            if (herbInventory.ContainsKey(herbName))
            {
                if (herbInventory[herbName] >= 9)
                {
                    Debug.Log($"인벤토리가 최대입니다. : {herbName}");
                    return;
                }
                
                herbInventory[herbName]++;
            }
            else
            {
                herbInventory[herbName] = 1;
            }

            MoneyManager.Instance.SpendMoney(price);
            totalHerbCount++;
            totalSpentMoney += price;
            OnHerbChanged?.Invoke(herbName, herbInventory[herbName]);
        }
        //재료제거
        public bool RevokeHerb(string herbName)
        {
            if (herbInventory.ContainsKey(herbName) && herbInventory[herbName] > 0)
            {
                herbInventory[herbName]--;

                return true;
            }

            Debug.LogWarning($"'{herbName}' 허브가 인벤토리에 없습니다.");
            return false;

        }
    
    

        public int GetHerbCount(string herbName) //허브 이름
        {
            if (herbInventory.TryGetValue(herbName, out int count))
            {
                return count;
            }
            return 0;
        }

        public int GetTotalSpentAll()      //합산
        {
            return totalSpentMoney;
        }
    }
}