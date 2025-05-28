using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.SFXManager
{
    public class SfxSliderFinder : MonoBehaviour
    {
        private void Start()
        {
            SFXManager.Instance.sfxSlider = gameObject.GetComponent<Slider>();
            SFXManager.Instance.ReassignUI();
        }
    }
}
