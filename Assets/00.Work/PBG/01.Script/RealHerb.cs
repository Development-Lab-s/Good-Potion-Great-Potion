using UnityEngine;

public class RealHerb : Herb
{

    public string herbID; // 예: "A", "B", "C"
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


    public void OnSelect()
    {
        GameManager.Instance.AddHerb(herbID);
    }

    private void OnMouseDown()
    {
        if(_isPot)
        OnSelect(); // 클릭 시 선택 처리
    }
}
