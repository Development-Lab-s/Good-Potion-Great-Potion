using System;
using System.Collections;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.Start
{
    public class BtnMotion : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] public float fadeDuration = 1f;

        private void Awake()
        {
            canvasGroup.interactable = false;
            canvasGroup.gameObject.SetActive(false);
        }

        public void FadeIn()
        {
            canvasGroup.gameObject.SetActive(true);
            StartCoroutine(Fade(canvasGroup, 0, 1));
        }
        
        private IEnumerator Fade(CanvasGroup cvg,float from, float to) // 페이드 설정 (form 부터 to까지 알파값 조정(0~1))
        {
            if (cvg == null)
            {
                Debug.LogWarning("Fade CanvasGroup이 없습니다.");
                yield break;
            }

            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                cvg.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
                yield return null;
            }

            cvg.alpha = to;

            if (cvg.alpha >= 0.99f)
            {
                cvg.interactable = true;
            }
        }
    }
}
