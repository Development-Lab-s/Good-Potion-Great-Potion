using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;

    public void SetHerb()
    {    
        Debug.Log(1);
        Herb Herb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
    }
}
