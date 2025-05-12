using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Dictionary<string, int> herbCounts = new Dictionary<string, int>();
    private Dictionary<string, int> totalSpent = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void Addherb(string herbName, int price)
    {
        if (!herbCounts.ContainsKey(herbName))
        {
            herbCounts[herbName] = 0;
            totalSpent[herbName] = 0;
        }

        herbCounts[herbName]++;              // 수량 +1
        totalSpent[herbName] += price;       // 누적 지출액
    }

    public int GetHerbCount(string herbName)
    {
        return herbCounts.ContainsKey(herbName) ? herbCounts[herbName] : 0;
    }

    public int GetToTalSpent(string herbName)
    {
        return totalSpent.ContainsKey(herbName) ? totalSpent[herbName] : 0;
    }
}
