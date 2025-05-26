using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class BackGroundImgFinder : MonoBehaviour
    {
        void Start()
        {
            if (FadeManager.Instance.backGroundImg == null)
            {
                FadeManager.Instance.backGroundImg = gameObject.GetComponent<Image>();
            }
            gameObject.SetActive(false);
        }
    }
}