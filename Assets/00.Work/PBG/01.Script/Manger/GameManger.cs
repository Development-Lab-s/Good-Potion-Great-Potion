using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}


    public bool _canProduce = false;
    

    private List<HerbDataSO> selectedHerbs = new List<HerbDataSO>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void AddHerb(HerbDataSO herbName)
    {
        Debug.Log(selectedHerbs.Count);
        if (selectedHerbs.Count > 2) 
            {
                Debug.Log("초과");
                return;  //넣은 허브 갯수가 3이상이면 반환하고 3이라면 레시피 식별 후 다음으로 넘어감
            }
        if (selectedHerbs.Count >= 1)
        {
            _canProduce = true; // 제작 버튼을 누를 수 있는 조건
        }
        selectedHerbs.Add(herbName);
        Debug.Log("선택된 허브: " + herbName);
    }

    public void CheckCombination()
    {
        if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "A" && selectedHerbs[1].herbName == "B")
        {
            Debug.Log("포션 1 성공");
        }
        else if (selectedHerbs[0].herbName == "A" && selectedHerbs[1].herbName == "B" && selectedHerbs[2].herbName == "C")
        {
            Debug.Log("포션 2 성공");
        }

        _canProduce = false;
        selectedHerbs.Clear(); // 다음 시도를 위해 초기화
    }

    
}
