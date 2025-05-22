using TMPro;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class DayCountTextFinder : MonoBehaviour
    {
        void Start()
        {
            if (FadeManager.Instance.dayCountText == null && FadeManager.Instance.dayCountCanvasGroup == null)
            {
                FadeManager.Instance.dayCountText = gameObject.GetComponent<TextMeshProUGUI>();
                FadeManager.Instance.dayCountCanvasGroup = gameObject.GetComponent<CanvasGroup>();
            }
            gameObject.SetActive(false);
        }
    }
}