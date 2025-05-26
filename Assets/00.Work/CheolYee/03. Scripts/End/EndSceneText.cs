using _00.Work.Base._02._Sprites.Manager;
using TMPro;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.End
{
    public class EndSceneText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] texts;
        [SerializeField] private float upSpeed = 3;

        private TextMeshProUGUI _currentText;
        
        private void Start()
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].gameObject.SetActive(false);
            }

            if (MoneyManager.Instance.Money >= 10000)
            {
                _currentText = texts[0];
            }
            else
            {
                _currentText = texts[1];
            }
            
            _currentText.gameObject.SetActive(true);
        }

        private void Update()
        {
            _currentText.gameObject.transform.position += Vector3.up * (Time.deltaTime * upSpeed);
        }
    }
}
