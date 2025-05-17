using TMPro;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class RevenueTextFinder : MonoBehaviour
    {
        void Start()
        {
            if (FadeManager.Instance.revenueText == null)
            {
                FadeManager.Instance.revenueText = gameObject.GetComponent<TextMeshProUGUI>();
            }
            gameObject.SetActive(false);
        }
    }
}