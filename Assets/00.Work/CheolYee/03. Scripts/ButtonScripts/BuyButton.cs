using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    //BuyMoney SO �ҷ�����.
    [SerializeField] private BuyMoneySO buyMoneySO;

    [SerializeField] private string herbName;
    [SerializeField] private int price;
    public void OnBuyButtonClicked()             //Ŭ��������.
    {
        //���� ������� Ȯ��
        if (MoneyManager.Instance.Money < price)
        {
            Debug.Log("���� �����մϴ�.");
            return;
        }

        // 2. �� ����
        MoneyManager.Instance.SpendMoney(price);

        // 3. �κ��丮�� ��� �߰� (�̸��� ���� ��� ����)
        InventoryManager.Instance.AddHerb(herbName, price);

        // 4. ����� ���
        int total = InventoryManager.Instance.GetTotalSpentAll();
        int herbCount = InventoryManager.Instance.GetHerbCount(herbName);
        Debug.Log($"[{herbName}] ���� ����: {herbCount}�� / �� ��� �ݾ�: {total}��");
    }
}
