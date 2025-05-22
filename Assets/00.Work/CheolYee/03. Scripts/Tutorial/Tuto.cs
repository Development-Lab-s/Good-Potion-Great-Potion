using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.Tutorial
{
    public class Tuto : MonoBehaviour
    {
        [SerializeField] Sprite[] tutoImage;
        [SerializeField] Button inToMain;
        
        [Header("Image Change Buttons")]
        [SerializeField] Button nextButton;
        [SerializeField] Button beforeButton;

        public void InToMain()
        {
            SceneManager.LoadScene(1);
        }
    }
}
