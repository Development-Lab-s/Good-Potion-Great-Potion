using _00.Work.Base._02._Sprites.Manager;
using TMPro;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts
{
    public class GoldUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        private void Start()
        {
            moneyText.text = ($"{MoneyManager.Instance.Money}G");

            MoneyManager.Instance.OnMoneyChanged += UpdateUI;
        }

        private void UpdateUI(int money)
        {
            moneyText.text = ($"{money}G");
        }
    
        private void OnDestroy()
        {
            if (MoneyManager.Instance != null)
                MoneyManager.Instance.OnMoneyChanged -= UpdateUI;
        }
    }
}
