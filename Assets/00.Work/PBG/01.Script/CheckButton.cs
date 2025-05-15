using UnityEngine;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;
    [SerializeField] private HerbRecipeManager herbRecipeManager;

    public void OnReset()
    {
        if(herbRecipeManager._canProduce)
        {
            herbRecipeManager.CheckCombination();  // 제작이 가능한 상황이면 조합식 감지 후 초기화
            changeImageUi._isHerb = 4;
            Debug.LogWarning("엄");
        }                                      
    }
}
