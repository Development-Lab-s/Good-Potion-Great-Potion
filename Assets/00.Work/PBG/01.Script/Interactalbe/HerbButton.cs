using UnityEngine;
using UnityEngine.InputSystem;

public class HerbButton : MonoBehaviour
{
    [SerializeField] private Herb herb;

    public void SetHerb()
    {
        if(GameManager.Instance.moneyCount != 0)
        {
            if(herb._isHerb == false)
            {
            Herb MedicinalHerb = Instantiate(herb, Mouse.current.position.value, Quaternion.identity);
            }
        }
        herb._isHerb = true;
    }
}
