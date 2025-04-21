using Unity.VisualScripting;
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


    public void OnSelect()
    {
        GameManager.Instance.AddHerb(data);
    }

    private void OnMouseDown()
    {
        if(_isPot)
        OnSelect(); // 클릭 시 선택 처리
    }
}
