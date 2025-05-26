using System.Collections.Generic;
using System.Diagnostics.Tracing;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;

public class HerbRecipeManager : MonoBehaviour
{
    public static HerbRecipeManager Instance {get; private set;}


    public bool _canProduce = false;
    
    public string _potionName{get; set;}


    public List<HerbDataSO> selectedHerbs = new List<HerbDataSO>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
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
        Debug.Log("선택된 허브: " + herbName.herbName);
    }

    public void CheckCombination()
    {
        
        HerbCombination(); //포션 레시피

        _canProduce = false;
        selectedHerbs.Clear(); // 다음 시도를 위해 초기화
        Debug.Log(selectedHerbs.Count);
        
        SceneManagerScript.Instance.LoadToScene(3);
    }




    public void HerbCombination()
    {
        if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "RRP" && selectedHerbs[1].herbName == "GBR")
        {
            _potionName = "RRPGBR";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "CSM" && selectedHerbs[1].herbName == "RMB")
        {
            _potionName = "CSMRMB";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "BPR" && selectedHerbs[1].herbName == "SDR")
        {
            _potionName = "BPRSDR";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "RMB" && selectedHerbs[1].herbName == "SDR")
        {
            _potionName = "RMBSDR";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "CSM" && selectedHerbs[1].herbName == "SDR")
        {
            _potionName = "CSMSDR";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "DSR" && selectedHerbs[1].herbName == "ATA")
        {
            _potionName = "DSRATA"; 
        }
        
        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "DSR" && selectedHerbs[1].herbName == "DTA")
        {
            _potionName = "DSRDTA";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "TBR" && selectedHerbs[1].herbName == "BTA")
        {
            _potionName = "TBRBTA";
        }

        else if (selectedHerbs.Count == 2 && selectedHerbs[0].herbName == "SND" && selectedHerbs[1].herbName == "RSR")
        {
            _potionName = "SMDRSR";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "RGA" && selectedHerbs[1].herbName == "BTA" && selectedHerbs[2].herbName == "CSM")
        {
            _potionName = "RGABTACSM";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "PMR" && selectedHerbs[1].herbName == "SDR" && selectedHerbs[2].herbName == "RMB")
        {
            _potionName = "PMRSDRRMB";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "BTA" && selectedHerbs[1].herbName == "BPR" && selectedHerbs[2].herbName == "CSM")
        {
            _potionName = "BTABPRCSM";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "ATA" && selectedHerbs[1].herbName == "GBR" && selectedHerbs[2].herbName == "RRP")
        {
            _potionName = "ATAGBRRRP";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "SPD" && selectedHerbs[1].herbName == "DTA" && selectedHerbs[2].herbName == "TBR")
        {
            _potionName = "SPDDTATBR";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "SPD" && selectedHerbs[1].herbName == "RSR" && selectedHerbs[2].herbName == "BPR")
        {
            _potionName = "SPDRSRBPR";
        }

        else if (selectedHerbs.Count == 3 && selectedHerbs[0].herbName == "RSR" && selectedHerbs[1].herbName == "PST" && selectedHerbs[2].herbName == "SND")
        {
            _potionName = "RSRPSTSND";
        }

        else
        {
            _potionName = "FAILPOTION";
            Debug.Log(_potionName);
        }
        
    }
}
