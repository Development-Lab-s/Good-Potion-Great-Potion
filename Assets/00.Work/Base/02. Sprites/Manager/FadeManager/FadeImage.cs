using System.Collections;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class FadeImage : MonoBehaviour
    {
        void Start()
        {
            if (FadeManager.Instance.canvasGroup == null)
            {
                FadeManager.Instance.ReassignCanvasGroup(gameObject.GetComponent<CanvasGroup>());
            }
            gameObject.SetActive(false);
        }

        public void NextDayBtnClicked()
        {
            StartCoroutine(NextDayCycle());
        }
        
        private IEnumerator NextDayCycle()
        {
            if (SceneManagerScript.Instance.currentDay == 12) SceneManagerScript.Instance.LoadToScene(5);// 만약 끝났는데 12일이면 엔딩씬 가기
            if (MoneyManager.Instance.Money <= 0) SceneManagerScript.Instance.LoadToScene(5);
            
            //보이는 텍스트 다 끄기
            FadeManager.Instance.backGroundImg.gameObject.SetActive(false);
            FadeManager.Instance.revenueText.gameObject.SetActive(false);
            FadeManager.Instance.checkButton.gameObject.SetActive(false);
            FadeManager.Instance.statisticText.gameObject.SetActive(false);
            
            //몇일차인지 표시해주기
            FadeManager.Instance.dayCountText.text = $"{++SceneManagerScript.Instance.currentDay}일차";
            FadeManager.Instance.dayCountText.gameObject.SetActive(true);
            SceneManagerScript.Instance.ResetValues(); // 값들 초기화하기
            StartCoroutine(FadeManager.Instance.FadeIn(FadeManager.Instance.dayCountCanvasGroup));
            yield return new WaitForSeconds(3f);
            //페이드로 다음날 변환
            yield return StartCoroutine(FadeManager.Instance.FadeOut(FadeManager.Instance.dayCountCanvasGroup));
            FadeManager.Instance.dayCountText.gameObject.SetActive(false);

            
            
            TimerManager.Instance.StartTimer(300); //타이머 설정하기
            SceneManagerScript.Instance.isTimerFinished = false;
            Debug.Log("다음날 전환완료");
            FadeManager.Instance.backGroundImg.gameObject.SetActive(false);
            SceneManagerScript.Instance.LoadToScene(1); // 씬을 메인으로 옮겨버리기
        }
    }
}
