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
        if(_isSet == false)
        {
            Vector2 mousePosition = Mouse.current.position.value;
            transform.position = (Vector2)cam.ScreenToWorldPoint(mousePosition);
        }
    }

    public virtual void OnClickInteractable()
    {
        
    }
}
