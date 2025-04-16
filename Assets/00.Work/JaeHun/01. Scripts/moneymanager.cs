using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] MoneyManagerSO goldSO;

    int money;

    private void Start()
    {
        money = goldSO.gold;

        goldSO.Test();
    }
}

