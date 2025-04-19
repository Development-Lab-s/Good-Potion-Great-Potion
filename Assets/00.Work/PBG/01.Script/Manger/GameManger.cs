using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private List<string> selectedHerbs = new List<string>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void AddHerb(string herbID)
    {
        if (selectedHerbs.Count >= 3) return;

        selectedHerbs.Add(herbID);
        Debug.Log("선택된 허브: " + herbID);

        if (selectedHerbs.Count == 3)
        {
            CheckCombination();
        }
    }

    void CheckCombination()
    {
        if (selectedHerbs[0] == "A" && selectedHerbs[1] == "B" && selectedHerbs[2] == "C")
        {
            Debug.Log("성공");
        }
        else
        {
            Debug.Log("실패");
        }

        selectedHerbs.Clear(); // 다음 시도를 위해 초기화
    }

    
}
