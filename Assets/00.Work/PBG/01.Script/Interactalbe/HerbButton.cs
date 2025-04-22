using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;

    [SerializeField] private HerbDataSO data;
    public void SetHerb()
    {    
        Herb Herb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
        herb.Initialized(data);
    }
}
