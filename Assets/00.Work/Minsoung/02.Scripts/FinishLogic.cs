using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class ClockHand : MonoBehaviour
{
    private CamShake _camShake;
    private TimerLogic _timerLogic;
    private FinishRotation _finishRotation;
    private bool _finishCheck = false;
    private int _finishCount;
    
    
    private void Awake()
    {
        _timerLogic = GameObject.FindAnyObjectByType<TimerLogic>();
        _finishRotation = GameObject.FindAnyObjectByType<FinishRotation>();
        _camShake = GameObject.FindAnyObjectByType<CamShake>();
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

    [SerializeField] ParticleSystem particlePrefab;
    [SerializeField] Transform particleTrm;
    private void Update()
    {
        if (_finishCheck)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _timerLogic.ClockHandDir();
                _timerLogic.ClockHandSpeed();

                ParticleSystem particle = Instantiate(particlePrefab);
                particle.gameObject.transform.position = particleTrm.position;
                particle.Play();
                SquareScale();
                _finishCount++;
                _finishRotation.FinishRotaton(true);
            }
        }
        else
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _timerLogic.ClockHandStop();
                _camShake.CameraShakeStop(false);
                SceneManagerScript.Instance.isFinishedCrafting = true;
                SceneManagerScript.Instance.isSuccessCrafting = false;
                SceneManagerScript.Instance.LoadToScene(0);
            }
        }
        if (_finishCount == 3)
        {
            _timerLogic.ClockHandStop();
            _camShake.CameraShakeStop(false);
            SceneManagerScript.Instance.LoadToScene(3);
        }
    }
    private void SquareScale()
    {
        transform.localScale -= new Vector3(0.01f,0f,0f);
    }
    
}
