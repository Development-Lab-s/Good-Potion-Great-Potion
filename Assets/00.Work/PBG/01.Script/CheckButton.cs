using UnityEngine;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;

    public void OnReset()
    {
        if(HerbRecipeManager.Instance._canProduce)
        {
            HerbRecipeManager.Instance.CheckCombination();  // 제작이 가능한 상황이면 조합식 감지 후 초기화
            changeImageUi._isHerb = 4;
        }                                      
    }
}
