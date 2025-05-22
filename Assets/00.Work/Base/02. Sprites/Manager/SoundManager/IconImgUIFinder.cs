using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.SoundManager
{
    public class IconImgUIFinder : MonoBehaviour
    {
        private void Start()
        {
            SoundManager.Instance.volumeIcon = gameObject.GetComponent<Image>();
        }
    }
}