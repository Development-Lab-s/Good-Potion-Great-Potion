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

    public override void OnAttack()
    {
        if(_isSet == false)
        base.OnAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pot"))
        {
            if(!_isPot)
            _isPot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Pot"))
        {
            if(_isPot)
            _isPot = false;
        }
    }
}
