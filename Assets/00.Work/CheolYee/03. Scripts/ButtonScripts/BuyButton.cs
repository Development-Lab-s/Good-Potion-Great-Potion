using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public void ItemBuy()
    {
        MoneyManager.Instance.SpendMoney(100);
    }
}
