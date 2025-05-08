using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] BuyMoneySO moneySO;
    [SerializeField] private int index;
    [SerializeField] private string herbName;

    public void ItemBuy()
    {
        MoneyManager.Instance.SpendMoney(moneySO.value[index - 1]);
        InventoryManager.Instance.Addherb(herbName);
        Debug.Log($"{herbName}��(��) �����߽��ϴ�. ���� ����: {InventoryManager.Instance.GetHerbCount(herbName)}");
    }
}
