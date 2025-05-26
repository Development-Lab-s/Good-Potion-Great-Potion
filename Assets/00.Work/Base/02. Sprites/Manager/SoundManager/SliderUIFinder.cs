using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.SoundManager
{
    public class SliderUIFinder : MonoBehaviour
    {
        private void Start()
        {
            SoundManager.Instance.bgmSlider = gameObject.GetComponent<Slider>();
            SoundManager.Instance.ReassignUI();
        }
    }
}