using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerLogic : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private float _ClockHandDir =-1f;
    private float _Count;
    private float _ClockHandStop = 1f;

    private void Update()
    {
        Vector3 angle = new Vector3(0, 0, Time.deltaTime);
        transform.Rotate(angle * speed *_ClockHandDir * _ClockHandStop);
        _Count += Time.deltaTime;
        
    }
   
    public void ClockHandDir()
    {
        _ClockHandDir = _ClockHandDir * -1;
    }
    public void ClockHandSpeed()
    {
        speed += 40;
    }
    public void ClockHandStop()
    {
        _ClockHandStop = 0;
    }

}
