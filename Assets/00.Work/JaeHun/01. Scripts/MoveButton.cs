using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveButton : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
