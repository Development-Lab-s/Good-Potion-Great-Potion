using _00.Work.Base._02._Sprites.Manager;
using _00.Work.JaeHun._01._Scripts;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    //BuyMoney SO 불러오기.
    [SerializeField] private BuyMoneySO buyMoneySO;

    [SerializeField] private string herbName;
    [SerializeField] private int price;
    public void OnBuyButtonClicked()             //클릭했을시.
    {
        //돈이 충분한지 확인
        if (MoneyManager.Instance.Money < price)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }

        // 2. 돈 차감
       

        // 3. 인벤토리에 허브 추가 (이름과 가격 모두 전달)
        
        
        InventoryManager.Instance.AddHerb(herbName, price);
        
        

        // 4. 디버그 출력
        int total = InventoryManager.Instance.GetTotalSpentAll();
        int herbCount = InventoryManager.Instance.GetHerbCount(herbName);
        Debug.Log($"[{herbName}] 현재 수량: {herbCount}개 / 총 사용 금액: {total}원");
    }
}