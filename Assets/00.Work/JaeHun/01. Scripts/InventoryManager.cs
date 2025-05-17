using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour     //��Ḧ �׳� ����� ������ ���عٶ�.
{
    //��ü ������Ʈ���� �� �ϳ��� �ִ� GameManager
    public static InventoryManager Instance { get; private set; }

    //��긦 �������� �ٷ�� �����ڵ�.
    private Dictionary<string, int> herbInventory = new Dictionary<string, int>();

    // ��ü ��� �ݾ�
    private int totalSpentMoney = 0;
    // �� ������ ��� ��
    private int totalHerbCount = 0;

    //Inventory�� �ٲ���� �� ��� �����ڵ鿡�� ����ϴ� �ý���
    public event Action<int> OnHerbInventoryChanged;

    private void Awake()
    {
        //���� �̹� �ν��Ͻ��� �ִٸ� ���ֱ�
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        //�ν��Ͻ��� ���� �� �̰ɷ� ����
        Instance = this;
        //���� �ٲ� ������� �ʰ��ϱ�
        DontDestroyOnLoad(this.gameObject);
    }
    //����߰�
    public void AddHerb(string herbName, int price)     //����߰�.
    {
        if (herbInventory.ContainsKey(herbName))
        {
            herbInventory[herbName]++;
        }
        else
        {
            herbInventory[herbName] = 1;
        }

        totalHerbCount++;
        totalSpentMoney += price;

        OnHerbInventoryChanged?.Invoke(totalHerbCount);
    }
    //�������
    public bool RevokeHerb(string herbName, int price)
    {
        if (herbInventory.ContainsKey(herbName) && herbInventory[herbName] > 0)
        {
            herbInventory[herbName]--;
            totalHerbCount--;
            totalSpentMoney -= price;

            OnHerbInventoryChanged?.Invoke(totalHerbCount);
            return true;
        }

        Debug.LogWarning($"'{herbName}' ��갡 �κ��丮�� �����ϴ�.");
        return false;
    }

    public int GetHerbCount(string herbName)          //��᰹��
    {
        if (herbInventory.TryGetValue(herbName, out int count))
        {
            return count;
        }
        return 0;
    }

    public int GetTotalHerbCount()
    {
        return totalHerbCount;
    }

    public int GetTotalSpentAll()      //�ջ�
    {
        return totalSpentMoney;
    }
}
