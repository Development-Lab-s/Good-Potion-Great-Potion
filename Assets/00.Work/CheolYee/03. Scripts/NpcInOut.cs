using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;

namespace _00.Work.CheolYee._03._Scripts
{
    public class NpcInOut : MonoBehaviour
    {
        int a = MoneyManager.Instance.Money;

        private void Start()
        {
            Debug.Log(a);
            MoneyManager.Instance.AddMoney(100);
        }
    }
}
