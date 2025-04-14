using UnityEngine;

public class RealHerb : Herb
{

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {   
        if(_isSet == false)
            return;
    }
    public override void OnAttack()
    {
        if(_isSet == false)
        base.OnAttack();
    }
}
