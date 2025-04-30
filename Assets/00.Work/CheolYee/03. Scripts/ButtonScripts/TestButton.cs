using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts.ButtonScripts
{
    public class TestButton : MonoBehaviour
    {
        public void OnButtonClicked()
        {
            MoneyManager.Instance.AddMoney(100);
            Debug.Log($"돈 추가: {MoneyManager.Instance.Money}");
        }
    }
}
