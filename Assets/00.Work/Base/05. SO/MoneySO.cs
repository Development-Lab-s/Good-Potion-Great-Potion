using UnityEngine;

namespace _00.Work.CheolYee._05._SO
{
    [CreateAssetMenu(fileName = "MoneySO", menuName = "Scriptable Objects/MoneySO")]
    public class MoneySo : ScriptableObject
    {
        public int money;

        public int Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}
