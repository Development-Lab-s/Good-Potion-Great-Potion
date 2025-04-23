using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class ClockHand : MonoBehaviour
{
    private TimerLogic _timerLogic;
    private FinishRotation _finishRotation;
    private bool _finishCheck = false;
    private int _finishCount;

    
    private void Start()
    {
        _timerLogic = GameObject.FindAnyObjectByType<TimerLogic>();
        _finishRotation = GameObject.FindAnyObjectByType<FinishRotation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _finishCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _finishCheck = false;
        }
    }
    private void Update()
    {
        if (_finishCheck)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _timerLogic.ClockHandDir();
                _timerLogic.ClockHandSpeed();
                SquareScale();
                _finishCount++;
                _finishRotation.FinishRotaton(true);
            }
        }
        else
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Time.timeScale = 0;
            }
        }
        if (_finishCount == 3)
        {
            Time.timeScale = 0;
        }
    }
    private void SquareScale()
    {
        transform.localScale -= new Vector3(0.09f,0f,0f);
    }
}
