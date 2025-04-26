using UnityEngine;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private ChangeImageUi changeImageUi;
    [SerializeField] private GameManager gameManager;

    public void OnReset()
    {
        if(gameManager._canProduce)
        {
            gameManager.CheckCombination();  // 제작이 가능한 상황이면 조합식 감지 후 초기화
            changeImageUi._isHerb = 4;
        }                                      
    }
}
