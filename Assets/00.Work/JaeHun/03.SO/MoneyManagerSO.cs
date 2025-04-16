using UnityEngine;

[CreateAssetMenu(fileName = "GoldSO", menuName = "Scriptable Objects/GoldSO")]
public class MoneyManagerSO : ScriptableObject
{
    public int gold;

    public int TEST
    {
        get { return gold; }
        set { gold = value; }
    }

    public void Test()
    {
        Debug.Log(gold);
    }
}
