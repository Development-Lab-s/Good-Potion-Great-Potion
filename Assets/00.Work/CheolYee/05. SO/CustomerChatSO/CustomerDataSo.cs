using UnityEngine;

namespace _00.Work.CheolYee._05._SO.CustomerChatSO
{
    [CreateAssetMenu(fileName = "CustomerDataSO", menuName = "SO/CustomerDataSO")]
    public class CustomerDataSo : ScriptableObject
    {
        public Sprite customerSprite;
        public string[] mainLines;
        public string requiredPotions;
    }
}
