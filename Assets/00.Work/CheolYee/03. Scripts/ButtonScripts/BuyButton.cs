using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private BuyMoneySO buyMoneySO;
    [SerializeField] private string herbName;     // 허브 이름 (예: "민들레")
    [SerializeField] private int herbPrice;       // 허브 가격
    [SerializeField] private int herbIndex;


    public void OnBuyButtonClicked()
    {
        MoneyManager.Instance.SpendMoney(herbPrice);
        Debug.Log($"{herbName} 구매 성공 - {herbPrice}원 차감");
    }
}
