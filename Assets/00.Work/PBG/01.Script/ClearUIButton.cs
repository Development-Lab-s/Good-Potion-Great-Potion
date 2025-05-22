using _00.Work.JaeHun._01._Scripts;
using UnityEngine;

public class ClearUIButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;
    public int i { get; set; }
    public void OnClear()
    {
        for (int i = 0; i < changeImageUi._isHerb; i++)
        {
            HerbRecipeManager.Instance.selectedHerbs.Clear();
            InventoryManager.Instance.AddHerb(changeImageUi.herbKeycode[i], 0);
        }

        changeImageUi._isHerb = 4;
    }
}
