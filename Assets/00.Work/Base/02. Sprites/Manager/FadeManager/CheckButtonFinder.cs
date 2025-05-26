using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class CheckButtonFinder : MonoBehaviour
    {
        void Start()
        {
            if (FadeManager.Instance.checkButton == null)
            {
                FadeManager.Instance.checkButton = gameObject.GetComponent<Button>();
            }
            gameObject.SetActive(false);
        }
    }
}
