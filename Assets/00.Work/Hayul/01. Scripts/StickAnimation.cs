using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

public class StickAnimation : MonoBehaviour
{
    private Animator _animator;
    
    public int maxRotateCount = 3;
    public int rotateCount = 0;
    public int rotationRunCount = 0;
    public int currentDirection = -1;

    [SerializeField] private UISystemManager systemManager;
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private GameObject gameFailUI;

    SpriteRenderer spriteRenderer;

    private bool _isRotating;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }

    private static readonly int OnClick = Animator.StringToHash("OnClick");
    private static readonly int CounterOnClick = Animator.StringToHash("CounterOnClick");

    private void Move()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame && !SceneManagerScript.Instance.isTimerFinished)
        {
            if(_isRotating == false)
            {
                RotatingTrue();
                currentDirection = 0;
                _animator.SetTrigger(OnClick); // 시계방향 애니메이선 실행
            }
        }

        else if (Keyboard.current.aKey.wasPressedThisFrame && !SceneManagerScript.Instance.isTimerFinished)
        {
            if (_isRotating == false)
            {
                RotatingTrue();
                currentDirection = 1;
                _animator.SetTrigger(CounterOnClick); // 반시계방향 애니메이선 실행
            }
        }
    }

    public void RotatingTrue()
    {
        _isRotating = true;
    }

    public void RotatingFalse()
    {
        systemManager.RandomRotation();
        _isRotating = false;
    }

    public void CurrentDirection()
    {
        if (systemManager.rotateDirection == currentDirection)
        {
            rotationRunCount++; // 실행 횟수+
            rotateCount++; //같은 방향이면 맞은 실행횟수+
            Debug.Log("같은 방향입니다.");
        }
        else
        {
            rotationRunCount++; // 실행 횟수+
            Debug.Log("틀린 방향입니다.");
        }

        if (rotateCount == maxRotateCount && rotationRunCount == maxRotateCount)
        {
            gameClearUI.SetActive(true);
            Debug.Log("최종 성공했습니다.");
        }
        else if (rotationRunCount == maxRotateCount)
        {
            gameFailUI.SetActive(true);
            Debug.Log("최종 실패하였습니다.");
        }

        currentDirection = -1;
        RotatingFalse();
    }
}
