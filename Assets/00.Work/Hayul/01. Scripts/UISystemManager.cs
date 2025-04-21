using UnityEngine;

public class UISystemManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftUI, RightUI;
    private void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            OnLeftUI();
        }
        else
        {
            OnRightUI();
        }
        
    }

    private void OnLeftUI()
    {
        LeftUI.SetActive(true);
    }

    private void OnRightUI()
    {
        RightUI.SetActive(true);
    }
    

}
