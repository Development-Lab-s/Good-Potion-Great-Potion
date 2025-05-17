using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private HerbDataSO data;
    [SerializeField] private HerbButton herbButton;

    public void AAA()
    {
        InventoryManager.Instance.AddHerb(data.herbName, 0);
        herbButton.BBB();
    }
}
