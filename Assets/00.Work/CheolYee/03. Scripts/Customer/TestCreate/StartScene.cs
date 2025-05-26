using UnityEngine;
using UnityEngine.SceneManagement;

namespace _00.Work.CheolYee._03._Scripts.Customer.TestCreate
{
    public class StartScene : MonoBehaviour
    {
        public void ClickedStart()
        {
            SceneManager.LoadScene(6);
        }

        public void ClickedEnd()
        {
            Application.Quit();
        }
    }
}
