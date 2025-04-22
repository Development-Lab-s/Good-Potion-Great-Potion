using UnityEngine;
using DG.Tweening;
public class GuideBookManager : MonoBehaviour
{
        
    [SerializeField] private CanvasGroup _GuideUI;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Close();
    }
    public void Open()
    {
        _GuideUI.DOFade(1, 0.1f);
        _GuideUI.blocksRaycasts = true;
    }
    public void Close()
    {
        _GuideUI.DOFade(0, 0.1f);
        _GuideUI.blocksRaycasts = false;
    }
}
