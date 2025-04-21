using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class Herb : MonoBehaviour
{

    protected HerbDataSO data;
    [SerializeField] private SpriteRenderer imageCompo; 


    protected bool _isPot = false;
    private Camera cam;
    protected bool _isSet = false;

    
    public void Initialized(HerbDataSO data)
    {
        cam = Camera.main;
        this.data = data;
        imageCompo.color = data.herbIcon;
    }

    protected virtual void Update()
    {
        if(_isSet == false)
        {
            Vector2 mousePosition = Mouse.current.position.value;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
