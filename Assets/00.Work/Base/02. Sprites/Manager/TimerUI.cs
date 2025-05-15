using System;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private float startTime = 120f;
        private void Start()
        {
            TimerManager.Instance.StartTimer(startTime);

            //델리게이트 이벤트가 호출 되었을 때 실행할 행동(람다식)
            TimerManager.Instance.OnTimerFinished += OnTimerFinished;
        }

        private void OnTimerFinished()
        {
            Debug.Log("타이머 종료");
        }

        private void OnDisable()
        {
            TimerManager.Instance.OnTimerFinished -= OnTimerFinished;
        }
    }
}
