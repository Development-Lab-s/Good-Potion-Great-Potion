using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HerbRecipeManager : MonoBehaviour
{
    public static HerbRecipeManager Instance {get; private set;}


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
        else if (selectedHerbs.Count >= 1)
        {
            _canProduce = true; // 제작 버튼을 누를 수 있는 조건
        }
        selectedHerbs.Add(herbName);
        Debug.Log("선택된 허브: " + herbName);
    }

    public void CheckCombination()
    {
        
        HerbCombination(); //하급 포션 레시피

        _canProduce = false;
        selectedHerbs.Clear(); // 다음 시도를 위해 초기화
    }




    public void HerbCombination()
    {
        if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "RRP" && selectedHerbs[1].herbName == "E")
        {
            Debug.Log("회복 포션");
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "CSM" && selectedHerbs[1].herbName == "F")
        {
            Debug.Log("힘 포션");
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "D" && selectedHerbs[1].herbName == "SDR")
        {
            Debug.Log("정신정화포션");
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "F" && selectedHerbs[1].herbName == "SDR")
        {
            Debug.Log("속도증가포션");
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "CSM" && selectedHerbs[1].herbName == "B")
        {
            Debug.Log("활력포션");
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "C2" && selectedHerbs[1].herbName == "F2")
        {
            Debug.Log("기억력포션");
        }
        
        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "C2" && selectedHerbs[1].herbName == "H2")
        {
            Debug.Log("기억제거포션");
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "E2" && selectedHerbs[1].herbName == "B2")
        {
            Debug.Log("행운포션");
        }

        else if (selectedHerbs[0].herbName == "A2" && selectedHerbs[1].herbName == "B2" && selectedHerbs[2].herbName == "C")
        {
            Debug.Log("신경강화포션");
        }

        else if (selectedHerbs[0].herbName == "D2" && selectedHerbs[1].herbName == "SDR" && selectedHerbs[2].herbName == "F")
        {
            Debug.Log("고속점프포션");
        }

        else if (selectedHerbs[0].herbName == "B2" && selectedHerbs[1].herbName == "D" && selectedHerbs[2].herbName == "CSM")
        {
            Debug.Log("하루집중포션");
        }

        else if (selectedHerbs[0].herbName == "F2" && selectedHerbs[1].herbName == "E" && selectedHerbs[2].herbName == "RRP")
        {
            Debug.Log("불면회복포션");
        }

        else
        {
            Debug.Log("수상한 포션");
        }
        
    }
}
