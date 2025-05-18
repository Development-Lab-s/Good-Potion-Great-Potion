using System;
using Unity.VisualScripting;
using UnityEngine;

public class RealHerb : Herb
{

    [SerializeField] private HerbButton herbButton;
    protected override void Update()
    {
        if(_isSet == false)
        {
            base.Update();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pot"))
        {
            _isPot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Pot"))
        {
            _isPot = false;
        }
    }

    public void OnMouseDown()
    {
        if (_isPot)
        {
            HerbRecipeManager.Instance.AddHerb(data);
        }
    }
}
