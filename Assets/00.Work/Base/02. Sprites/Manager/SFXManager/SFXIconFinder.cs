using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.SFXManager
{
    public class SfxIconFinder : MonoBehaviour
    {
        private void Start()
        {
            SFXManager.Instance.volumeIcon = gameObject.GetComponent<Image>();
        }
    }
}
