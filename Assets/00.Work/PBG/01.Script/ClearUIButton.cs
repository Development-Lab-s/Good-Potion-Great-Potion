using UnityEngine;

public class ClearUIButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;

    public void OnClear()
    {
        changeImageUi._isHerb = 4;
    }
}
