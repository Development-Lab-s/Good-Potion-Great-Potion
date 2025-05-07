using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour       //재료는 허브라고 통합해서 부를게.
{
    public static InventoryManager Instance;
    private Dictionary<string, int> herbInventory = new Dictionary<string, int>();//Dictionary는 허브 이름이랑 수량 저장하는거임.

    [SerializeField] private string[] herbNames;  //모든 허브를 배열에 넣어주기위한 배열.

    private void Awake()
    {
        if (Instance == null) Instance = this;    //이거는 다 알거라고 생각해.
        else Destroy(gameObject);                 //만약 모른다면 그냥 다른 씬 가도 유지하는거라 생각해

        foreach (string name in herbNames)      //허브네임에서 이름으로 검색하는거를 처음에는 0으로 만들어줘
        {                                       //좀 애매하긴 한데 그냥 Inspector에 입력된 허브 이름을 하나씩 가져와서, 각각 수량을 0으로 초기화 해준다고 생각해.
            herbInventory[name] = 0;
        }

    }
    public void Addherb(string herbName)         //더하기
    {
        if (herbInventory.ContainsKey(herbName))        //허브찾기
        {
            herbInventory[herbName]++;
            Debug.Log($"{herbName} +1 → 현재 수량: {herbInventory[herbName]}"); //이거는 걍 실험용임.
        }
    }
    public void RemoveHurb(string herbName)       //빼기
    {
        if (herbInventory.ContainsKey(herbName))
        {
            if (herbInventory[herbName] > 0)   //음수 방지
            {
                herbInventory[herbName]--;
                Debug.Log($"{herbName} -1 → 현재 수량: {herbInventory[herbName]}");
            }
        }
    }
    public int GetHerbCount(string herbName) //외부에서 현재 허브 수량을 확인 할 수 있는 함수
    {
        return herbInventory.ContainsKey(herbName) ? herbInventory[herbName] : 0; //없는 허브를 쓸라하면 0을 반환한다.
                                                                                  //인벤토리에서 찾으려는 허브가 있을경우 허브를 인벤토리에 넣는다. 아닐경우 0을 반환.
    }
}






