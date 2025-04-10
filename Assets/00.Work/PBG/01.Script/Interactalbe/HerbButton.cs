using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;

    public void SetHerb()
    {
        if(GameManager.Instance.moneyCount != 0)
        {
            Herb MedicinalHerb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
        }
    }
}
