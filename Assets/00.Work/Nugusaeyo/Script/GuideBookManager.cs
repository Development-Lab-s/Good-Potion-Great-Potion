using UnityEngine;
using DG.Tweening;
public class GuideBookManager : MonoBehaviour
{
        
    [SerializeField] private CanvasGroup _GuideUI;

    private void Start()
    {
        _GuideUI.DOFade(0, 0);
        _GuideUI.blocksRaycasts = true;
        _GuideUI.gameObject.SetActive(false);
    }
    public void Open()
    {
        _GuideUI.gameObject.SetActive(true);
        _GuideUI.DOFade(1, 0.1f);
        _GuideUI.blocksRaycasts = true;
    }
    public void Close()
    {
        _GuideUI.DOFade(0, 0.1f);
        _GuideUI.blocksRaycasts = false;
        _GuideUI.gameObject.SetActive(false);
    }
}
