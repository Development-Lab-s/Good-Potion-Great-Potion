using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [field: SerializeField] public int moneyCount {get; private set;} = 10;
    // 지금으로썬 읽기와 쓰기
    // 가져오는 것과 값을 설정, 지정하는 것
    // 그 두개를 함수로 바꿨다.

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void MoneyCountDown(int value)
    {
        moneyCount -= value;
    }

    public void MoneyCountUp(int value)
    {
        moneyCount += value;
    }

    public bool CheckMoneyCount()
    {
        return moneyCount == 0;
    }
}
