using UnityEngine;
using static StickDrag;

public class UISystemManager : MonoBehaviour
{
    [SerializeField] private GameObject LeftUI, RightUI;

    public RotationDirection currentDirection;
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

    private void OnLeftUI() //반시계방향
    {
        currentDirection = RotationDirection.CounterClockwise;
        Debug.Log(currentDirection);
        RightUI.SetActive(true);
    }

    private void OnRightUI() //시계방향
    {
        currentDirection = RotationDirection.Clockwise;
        Debug.Log(currentDirection);
        LeftUI.SetActive(true);
    }
    

}
