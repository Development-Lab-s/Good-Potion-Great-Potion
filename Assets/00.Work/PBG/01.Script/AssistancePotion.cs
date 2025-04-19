using UnityEngine;
using UnityEngine.UI; // 꼭 필요!

public class AssistancePotion : MonoBehaviour
{
    [SerializeField] private Image image;
    public bool _setColor = false;

    public void OnChanged()
    {
        if(!_setColor)
        {
            image.color = Color.yellow;
            _setColor = true;
        }
        else
        {
            image.color = Color.white;
            _setColor = false;
        }
    }
}
