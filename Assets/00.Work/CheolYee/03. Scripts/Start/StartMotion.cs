using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace _00.Work.CheolYee._03._Scripts.Start
{
    public class StartMotion : MonoBehaviour
    {
        public RectTransform titleTransform; // UI 타이틀 오브젝트
        public float dropDuration = 1.2f;     // 떨어지는 시간
        public float startYOffset = 300f;     // 시작 위치 오프셋

        
        public UnityEvent onStartMotion;
        private void Start()
        {
            Vector2 originalPos = titleTransform.anchoredPosition;
            titleTransform.anchoredPosition = originalPos + new Vector2(0, startYOffset);
            
            titleTransform.DOAnchorPos(originalPos, dropDuration)
                .SetEase(Ease.OutBack).OnComplete(() => onStartMotion?.Invoke());
        }
    }
}
