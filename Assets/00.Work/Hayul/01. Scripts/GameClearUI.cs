using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{

    public static GameObject Instance { get; private set; }

    public int RotaiteCount = 0;

    private void Start()
    {
        if (Instance = null)
        {
            Instance = this.gameObject;
        }
    }


    private void Awake()
    {
        gameObject.SetActive(false); // 내 게임 오브젝트를 비활성화
    }
    public void Back()
    {
        //SceneManager.LoadScene("GameScene"); 다음 씬 넣어야함.
    }
}
