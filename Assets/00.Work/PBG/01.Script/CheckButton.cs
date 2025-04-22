using UnityEngine;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;

    public void OnReset()
    {
        if(changeImageUi._isHerb == 3)
        changeImageUi._isHerb++;
    }
}
