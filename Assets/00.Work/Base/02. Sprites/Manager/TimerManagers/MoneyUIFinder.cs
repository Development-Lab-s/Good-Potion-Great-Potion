using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _00.Work.Base._02._Sprites.Manager.TimerManagers
{
    public class MoneyUIFinder : MonoBehaviour
    {
        void OnEnable()
        {
            //씬 로드 될 때 실행할 이벤트 등록
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            //씬이 다시 변경 될 때 자동 호출을 막기 위해 제거
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // 새로 로드된 씬에서 MoneyText를 찾아 연결
            var newMoneyText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
            if (newMoneyText != null)
            {
                TimerManager.Instance.timerText = newMoneyText;
            }
        }
    }
}
