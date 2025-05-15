using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;
    [SerializeField] private HerbDataSO data;
    private string herbName;
    public void SetHerb()
    {    
        if(herb._inHand == false)
        {
            Herb newHerb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
            newHerb.Initialized(data);
            
            herbName = data.herbName;
            
            InventoryManager.Instance.RevokeHerb(herbName);

            herb._inHand = true;
        }
    }
}
