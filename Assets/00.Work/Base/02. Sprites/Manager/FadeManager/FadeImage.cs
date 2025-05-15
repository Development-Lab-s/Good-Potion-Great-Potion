using UnityEngine;

namespace _00.Work.Base._02._Sprites.Manager.FadeManager
{
    public class FadeImage : MonoBehaviour
    {
        void Awake()
        {
            gameObject.SetActive(false);
            
            if (FadeManager.Instance != null)
            {
                FadeManager.Instance.ReassignCanvasGroup(gameObject.GetComponent<CanvasGroup>());
            }
        }
    }
}
