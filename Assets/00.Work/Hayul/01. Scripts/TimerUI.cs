using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager.TimerManagers
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private float startTime = 120f;
        private void Start()
        {
            TimerManager.Instance.StartTimer(startTime);

            //델리게이트 이벤트가 호출 되었을 때 실행할 행동(람다식)
            TimerManager.Instance.OnTimerFinished += () =>
            {
                Debug.Log("타이머 종료");
            };
        }
    }
}
