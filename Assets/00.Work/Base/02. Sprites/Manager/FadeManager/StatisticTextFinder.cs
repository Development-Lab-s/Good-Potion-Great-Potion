using TMPro;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class StatisticTextFinder : MonoBehaviour
    {
        void Start()
        {
            if (FadeManager.Instance.statisticText == null)
            {
                FadeManager.Instance.statisticText = gameObject.GetComponent<TextMeshProUGUI>();
            }
            gameObject.SetActive(false);
        }
    }
}