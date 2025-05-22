using System.Collections;
using TMPro;
using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager
{
    public class TimerManager : MonoBehaviour
    {
        //전체 프로젝트에서 단 하나만 있는 TimerManager
        public static TimerManager Instance { get; private set; }
        
        public TextMeshProUGUI timerText; //시간을 표시할 TMP
        
        public float startSeconds = 120f; //시작 시간 (초)
        private float _remainingSeconds; //현재 타이머의 시간을 초로 저장
        private Coroutine _countDownCoroutine; //코루틴 실행 시 결과값 저장 (나중에 멈추려고 만듬)
        
        //타이머가 작동 중인지 아닌지 확인 밖에서는 읽어오기 가능, 이 안에서만 수정 가능
        private bool _isRunning;
        
        //delegate: 함수 자체를 변수처럼 저장하는 함수 포인터
        //TimerFinished는 반환값도 없고 매개변수도 없는 함수 저장 가능
        public delegate void TimerFinished();
        //OnTimerFinished: 이 delegate를 사용하는 이벤트 변수 (이 타이머가 끝났을 때 알려주는 이벤트)
        public event TimerFinished OnTimerFinished;
        
        private void Awake()
        {
            //만약 이미 인스턴스가 있다면 없애기
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
        
            //인스턴스가 없을 때 이걸로 지정
            Instance = this;
            //씬이 바뀌어도 사라지지 않게하기
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            StartTimer(startSeconds); //시작 시 시작 초로 타이머 시작
        }
        
        //타이머 시작 (어디서든 TimerManager.Instance.StartTimer()로 호출 가능)
        public void StartTimer(float setTime)
        {
            if (_isRunning) return; //이미 타이머가 돌아가고 있다면 무시
            
            _remainingSeconds = setTime; //시작 시간을 입력값으로 설정
            _countDownCoroutine = StartCoroutine(TimerCorutine()); //코루틴 시작해서 1초씩 감소
            _isRunning = true; //타이머 작동 중이라고 표시
        }

        public void RestartTimer()
        {
            if (_isRunning) return;
            
            StartTimer(_remainingSeconds);
        }
        
        //타이머 멈춤 (어디서든 TimerManager.Instance.StopTimer()로 호출 가능)
        public void StopTimer()
        {
            if (!_isRunning) return; //타이머가 돌고 있지 않다면 무시
            
            StopCoroutine(_countDownCoroutine); //타이머 코루틴 멈춤
            _isRunning = false; //타이머 작동 안하고 있다고 표시
        }

        public void LessTimer(float setTime) // 타이머의 시간을 뺄 수 있는 기능
        {
            _remainingSeconds -= setTime;
            UpdateTimerUI();
        }
        
        public void SetTimer(float setTime) // 타이머의 시간을 설정할 수 있는 기능
        {
            _remainingSeconds = setTime;
            UpdateTimerUI();
        }
        
        //타이머 동작
        private void UpdateTimerUI() //화면에 시간 표시하는 함수
        {
            int minutes = Mathf.FloorToInt(_remainingSeconds / 60); // 분
            int seconds = Mathf.FloorToInt(_remainingSeconds % 60); // 초
            timerText.text = $"{minutes:00}:{seconds:00}"; // 00:00처럼 나오게 표시
        }

        //타이머 초기화 (어디서든 TimerManager.Instance.SetTimerText(TMP 오브젝트)로 호출 가능)
        public void SetTimerText(TextMeshProUGUI newTimerText)
        {
            this.timerText = newTimerText; //씬 이동 시 새 UI 연결
        }

        private IEnumerator TimerCorutine() //1초씩 시간 감소 코루틴
        {
            while (_remainingSeconds > 0) //시간이 0보다 클 시 무한 반복
            {
                UpdateTimerUI(); //화면에 시간 보여주기
                yield return null; //1초 기다리기
                _remainingSeconds -= Time.deltaTime; //현재 타이머 시간 1초 감소
            }

            
            //타이머가 끝났을 시
            _remainingSeconds = 0; //혹시 음수가 되지 않도록 0으로 설정
            UpdateTimerUI(); //마지막 시간 업데이트 (00:00 보여주기)
            _isRunning = false; //타이머 작동 중지
            
            OnTimerFinished?.Invoke(); //등록된 이벤트 함수가 있다면 종료 이벤트 실행
        }
    }
}
