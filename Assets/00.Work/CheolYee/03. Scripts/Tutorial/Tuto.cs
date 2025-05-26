using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.Tutorial
{
    public class Tuto : MonoBehaviour
    {
        [SerializeField] Image sourceImage;
        [SerializeField] Sprite[] tutoImage;
        [SerializeField] Button inToMain;
        [SerializeField] int currentImgIndex = 0;
        
        [Header("Image Change Buttons")]
        [SerializeField] Button nextButton;
        [SerializeField] Button beforeButton;

        private void Start()
        {
            sourceImage.sprite = tutoImage[currentImgIndex];
        }

        public void NextIMG()
        {
            
            if (currentImgIndex < tutoImage.Length - 1)
            {
                currentImgIndex++;
                sourceImage.sprite = tutoImage[currentImgIndex];
            }
            if (currentImgIndex == tutoImage.Length - 1) inToMain.gameObject.SetActive(true);
            else inToMain.gameObject.SetActive(false);
        }
        
        public void BeforeIMG()
        {
            inToMain.gameObject.SetActive(false);
            
            if (currentImgIndex > 0)
            {
                currentImgIndex--;
                sourceImage.sprite = tutoImage[currentImgIndex];
            }
        }
        
        public void InToMain()
        {
            SceneManager.LoadScene(1);
        }
    }
}
