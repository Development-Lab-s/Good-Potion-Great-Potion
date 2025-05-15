using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class FadeManager : MonoBehaviour
    {
        public static FadeManager Instance;
        
        [Header("TEXT UI")]
        [SerializeField] public Image backGroundImg;
        [SerializeField] public TextMeshProUGUI adjustmentText;
        [SerializeField] public TextMeshProUGUI statisticText;
        [SerializeField] public TextMeshProUGUI revenueText;
        
        [Header("Canvas Group")]
        [SerializeField] public CanvasGroup canvasGroup;
        [SerializeField] public float fadeDuration = 1f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        public void ReassignCanvasGroup(CanvasGroup newCanvasGroup)
        {
            canvasGroup = newCanvasGroup;
        }

        public IEnumerator FadeIn() // 페이드인
        {
            canvasGroup.gameObject.SetActive(true);
            yield return Fade(0, 1);
        }

        public IEnumerator FadeOut() // 페이드 아웃
        {
            yield return Fade(1, 0);
            canvasGroup.gameObject.SetActive(false);
        }

        private IEnumerator Fade(float from, float to) // 페이드 설정 (form 부터 to까지 알파값 조정(0~1))
        {
            if (canvasGroup == null)
            {
                Debug.LogWarning("Fade CanvasGroup이 없습니다.");
                yield break;
            }

            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
                yield return null;
            }

            canvasGroup.alpha = to;
        }
    }
}
