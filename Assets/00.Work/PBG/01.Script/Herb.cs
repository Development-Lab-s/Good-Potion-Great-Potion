using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Herb : MonoBehaviour, Interactable
{
    private Camera cam;
    protected bool _isSet = false;

    protected virtual void Awake()
    {
        cam = Camera.main;
    }


    protected virtual void Update()
    {
        // 건물이 아직 활성화 되지 않았다면 마우스를 따라다니게 만들어봐
        if(_isSet == false)
        {
            Vector2 mousePosition = Mouse.current.position.value;
            transform.position = (Vector2)cam.ScreenToWorldPoint(mousePosition);
        }
    }

    public virtual void OnClickInteractable()   
    {   
        _isSet = true;    
    }
}
