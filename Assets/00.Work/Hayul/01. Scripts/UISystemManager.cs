using UnityEngine;

public class UISystemManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftUI, RightUI;

    public int rotateDirection = -1;
    private void Start()
    {
        RandomRotation();
    }

    public void RandomRotation()
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

    private void OnLeftUI() //반시계방향
    {
        RightUI.SetActive(false);
        LeftUI.SetActive(false);
        Debug.Log("반시계!");
        rotateDirection = 1; //반시계는 1
        RightUI.SetActive(true);
    }

    private void OnRightUI() //시계방향
    {
        RightUI.SetActive(false);
        LeftUI.SetActive(false);
        Debug.Log("시계!");
        rotateDirection = 0; //시계는 0
        LeftUI.SetActive(true);
    }
}
