using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;
    [SerializeField] private HerbDataSO data;
    public void SetHerb()
    {    
        Herb newHerb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
        newHerb.Initialized(data);
    }
}
