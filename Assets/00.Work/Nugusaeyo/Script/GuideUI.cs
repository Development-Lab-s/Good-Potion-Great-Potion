using UnityEngine;
using UnityEngine.UI;

public class GuideUI : MonoBehaviour
{
    [SerializeField] private  GuideBookSO _guideSO;

    [SerializeField] private Image potionImg;
    [SerializeField] private Image slotImg1;
    [SerializeField] private Image slotImg2;
    [SerializeField] private Image slotImg3;
    private void Start()
    {
        potionImg.sprite = _guideSO.potionImage;

        slotImg1.sprite = _guideSO.slotImage1;
        slotImg2.sprite = _guideSO.slotImage2;
        slotImg3.sprite = _guideSO.slotImage3;
    }

}
