using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private BuyMoneySO buyMoneySO;
    [SerializeField] private string herbName;     // ��� �̸� (��: "�ε鷹")
    [SerializeField] private int herbPrice;       // ��� ����
    [SerializeField] private int herbIndex;


    public void OnBuyButtonClicked()
    {
        MoneyManager.Instance.SpendMoney(herbPrice);
        Debug.Log($"{herbName} ���� ���� - {herbPrice}�� ����");
    }
}
