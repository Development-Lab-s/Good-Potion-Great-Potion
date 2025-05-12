using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _00.Work.CheolYee._03._Scripts.Customer.TestCreate
{
    public class CreateToMain : MonoBehaviour
    {
        public void InToMainSecne()
        {
            SceneManagerScript.Instance.isFinishedCrafting = true;
            SceneManagerScript.Instance.isSuccessCrafting = true;
            SceneManager.LoadScene(3);
        }
    }
}
