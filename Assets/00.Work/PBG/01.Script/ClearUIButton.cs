using UnityEngine;

public class ClearUIButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;
    public int i { get; set; }
    public Object[] herbButton;
    public void OnClear()
    {
        for (int i = 0; i < changeImageUi._isHerb; i++)
        {
            InventoryManager.Instance.AddHerb(changeImageUi.herbKeycode[i], 0);
        }

        changeImageUi._isHerb = 4;
    }
}
