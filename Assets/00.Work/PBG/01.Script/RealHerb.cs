using UnityEngine;

public class RealHerb : Herb
{

    protected override void Update()
    {
        _isSet = false;
        base.Update();
    }

    public override void OnClickInteractable()
    {
        base.OnClickInteractable();
    }
}
