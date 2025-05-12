using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class FinishRotation : MonoBehaviour
{
    private bool _currentRotation = false;
    
    private void Start()
    {
        RandomPoint();
    }

    private void Update()
    {
        if (_currentRotation == true)
        {
            RandomPoint();
        }
    }

    public void FinishRotaton(bool value)
    {
        _currentRotation = value;
    }

    private void RandomPoint()
    {
        Vector3 angle = new Vector3(0, 0, Random.Range(30, 310));
        transform.Rotate(angle);
        _currentRotation = false;
    }
}
