using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    public void BackButtonClicked()
    {
        SceneManagerScript.Instance.LoadToScene(0);
    }
}
