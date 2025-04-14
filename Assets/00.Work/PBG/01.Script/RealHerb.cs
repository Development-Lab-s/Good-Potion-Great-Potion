using UnityEngine;

public class RealHerb : Herb
{

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
            Debug.Log(_isPot);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Pot"))
        {
            _isPot = false;
        }
    }

    public override void OnClickInteractable()
    {   
        Debug.Log("프리팹 클릭");
        base.OnClickInteractable();
    } 
}
