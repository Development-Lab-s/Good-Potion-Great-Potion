using UnityEngine;
using UnityEngine.InputSystem;

public class StickAnimation : MonoBehaviour
{
    private Animator _animator;
    private GameClearUI _gameClearUI;

    [SerializeField] private UISystemManager systemManager;

    SpriteRenderer spriteRenderer;

    private bool _isRotating;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _gameClearUI = GetComponent<GameClearUI>();
    }
    private void Update()
    {
        Move();
    }

    private static readonly int OnClick = Animator.StringToHash("OnClick");
    private static readonly int CounterOnClick = Animator.StringToHash("CounterOnClick");

    private void Move()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if(_isRotating == false)
            {
                RotatingTrue();
                _animator.SetTrigger(OnClick); // 시계방향 애니메이선 실행
            }
        }

        else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (_isRotating == false)
            {
                RotatingTrue();
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
}
