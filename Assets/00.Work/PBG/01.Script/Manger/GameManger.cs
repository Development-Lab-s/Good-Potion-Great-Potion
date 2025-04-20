using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [SerializeField] private ChangeImageUi changeImageUi;
    

    private List<HerbDataSO> selectedHerbs = new List<HerbDataSO>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void AddHerb(HerbDataSO herbID)
    {
        Debug.Log(selectedHerbs.Count);
        if (selectedHerbs.Count >= 3) return;  //넣은 허브 갯수가 3이상이면 반환하고 3이라면 레시피 식별 후 다음으로 넘어감

        selectedHerbs.Add(herbID);
        changeImageUi.ShowResult(herbID);
        Debug.Log("선택된 허브: " + herbID);

        if (selectedHerbs.Count == 3)
        {
            CheckCombination();
        }
    }

    void CheckCombination()
    {
    //     if (selectedHerbs[0] == "A" && selectedHerbs[1] == "B" && selectedHerbs[2] == "C")
    //     {
    //         Debug.Log("성공");
    //     }
    //     else
    //     {
    //         Debug.Log("실패");
    //     }

        selectedHerbs.Clear(); // 다음 시도를 위해 초기화
    }

    
}
