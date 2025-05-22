using System.Collections;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using _00.Work.JaeHun._01._Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class FadeManager : MonoBehaviour
    {
        public static FadeManager Instance { get; private set; }
        
        [Header("TEXT UI")]
        [SerializeField] public Image backGroundImg;
        [SerializeField] public TextMeshProUGUI dayCountText;
        [SerializeField] public TextMeshProUGUI statisticText;
        [SerializeField] public TextMeshProUGUI revenueText;
        [SerializeField] public Button checkButton;
        
        [Header("Canvas Group")]
        [SerializeField] public CanvasGroup canvasGroup;
        [SerializeField] public CanvasGroup dayCountCanvasGroup;
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

        public IEnumerator FadeIn(CanvasGroup cvg) // 페이드인
        {
            cvg.gameObject.SetActive(true);
            yield return Fade(cvg,0, 1);
        }

        public IEnumerator FadeOut(CanvasGroup cvg) // 페이드 아웃
        {
            yield return Fade(cvg,1, 0);
        }
        public IEnumerator EndDayCycle()
        {
            StartCoroutine(FadeIn(canvasGroup));
            
            yield return new WaitForSeconds(1.5f);
            
            backGroundImg.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);
            
            statisticText.gameObject.SetActive(true);
            StartCoroutine(TypingChat(statisticText,$"구매한 허브의 개수: {InventoryManager.Instance.totalHerbCount}개\n" +
                                      $"알맞게 제조한 물약 수: {SceneManagerScript.Instance.isSuccessCraftingCount}개\n" +
                                      $"오늘 번 골드량: <color=#5dff4b>+{SceneManagerScript.Instance.toDayTotalMoney}</color>G\n" +
                                      $"오늘 사용한 골드량: <color=#FF0000>-{InventoryManager.Instance.totalSpentMoney}</color>G", 0.05f));
            yield return new WaitForSeconds(5f);
            
            revenueText.gameObject.SetActive(true);
            StartCoroutine(TypingChat(revenueText, 
                $"순수익: <color=#ffc000>{SceneManagerScript.Instance.toDayTotalMoney - InventoryManager.Instance.totalSpentMoney}</color>G",
                0.2f));
            
            yield return new WaitForSeconds(3f);
            
            checkButton.gameObject.SetActive(true);
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
        }
        
        private IEnumerator TypingChat(TextMeshProUGUI tmp, string line, float time) // 타이핑 모션(대사와, 타이핑 대기시간 받아옴)
        {
            tmp.text = "";
            int i = 0;

            while (i < line.Length)
            {
                // 태그 시작
                if (line[i] == '<')
                {
                    // 태그 전체 읽기
                    int tagEnd = line.IndexOf('>', i);
                    if (tagEnd != -1)
                    {
                        string colorTag = line.Substring(i, tagEnd - i + 1);
                        tmp.text += colorTag;
                        i = tagEnd + 1;
                        continue;
                    }
                }

                // 일반 문자 출력
                tmp.text += line[i];
                i++;
                yield return new WaitForSeconds(time);
            }
        }
    }
}
