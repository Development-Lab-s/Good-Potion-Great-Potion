using System;
using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public abstract class Herb : MonoBehaviour
{

    public HerbDataSO data {get; set;}
    [SerializeField] private SpriteRenderer imageCompo;

    protected bool _isPot = false;
    private Camera cam;
    protected bool _isSet = false;
    public bool _inHand {get; set;}

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
            Vector2 mousePosition = Mouse.current.position.value;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
