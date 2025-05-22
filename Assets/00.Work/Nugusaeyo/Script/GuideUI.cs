using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuideUI : MonoBehaviour
{
    [SerializeField] private  GuideBookSO _guideSO;

    [SerializeField] private int day;
    [SerializeField] private int unlockWeek;

    [SerializeField] private Image potionImg;
    [SerializeField] private Image slotImg1;
    [SerializeField] private Image slotImg2;
    [SerializeField] private Image slotImg3;
    [SerializeField] private Image slotBGImg1;
    [SerializeField] private Image slotBGImg2;
    [SerializeField] private Image slotBGImg3;
    [SerializeField] private Image slotNameBG1;
    [SerializeField] private Image slotNameBG2;
    [SerializeField] private Image slotNameBG3;

    [SerializeField] private Sprite slot1Frame;
    [SerializeField] private Sprite slot2Frame;
    [SerializeField] private Sprite slot3Frame;

    [SerializeField] private TextMeshProUGUI potionName;
    [SerializeField] private TextMeshProUGUI slotName1;
    [SerializeField] private TextMeshProUGUI slotName2;
    [SerializeField] private TextMeshProUGUI slotName3;
    private void Start()
    {
        unlockWeek = _guideSO.unlockWeek;
        day = SceneManagerScript.Instance.currentDay;

        if (day / 5 >= unlockWeek)
        {
            potionImg.sprite = _guideSO.potionImage;
            potionImg.SetNativeSize();
            potionName.text = _guideSO.potionName;

            slotImg1.sprite = _guideSO.slotImage1;
            slotImg2.sprite = _guideSO.slotImage2;
            slotImg3.sprite = _guideSO.slotImage3;
            slotName1.text = _guideSO.slotName1;
            slotName2.text = _guideSO.slotName2;
            slotName3.text = _guideSO.slotName3;
            slotBGImg1.sprite = slot1Frame;
            slotBGImg2.sprite = slot2Frame;
            slotBGImg3.sprite = slot3Frame;
        }
        else
        {
            potionImg.sprite = _guideSO.potionLockImg;
            potionName.text = _guideSO.potionLockName;
            slotImg1.sprite = _guideSO.slotLockImg;
            slotName1.text = _guideSO.slotLockName;
            slotImg2.sprite = _guideSO.slotLockImg;
            slotName2.text = _guideSO.slotLockName;
            slotImg3.sprite = _guideSO.slotLockImg;
            slotName3.text = _guideSO.slotLockName;
        }
    }

}
