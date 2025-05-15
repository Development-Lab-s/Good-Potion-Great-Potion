using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class Herb : MonoBehaviour
{

    public HerbDataSO data {get; set;}
    [SerializeField] private SpriteRenderer imageCompo;
    [SerializeField] private PotButton potButton; 

    protected bool _isPot = false;
    private Camera cam;
    protected bool _isSet = false;
    [field : SerializeField] public bool _inHand {get; set;}


    
    public void Initialized(HerbDataSO data)
    {
        cam = Camera.main;
        this.data = data;
        imageCompo.sprite = data.herbIcon;
    }

    protected virtual void Update()
    {
        if(_isSet == false)
        {
            potButton.herbName = data.herbName;
            Vector2 mousePosition = Mouse.current.position.value;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
