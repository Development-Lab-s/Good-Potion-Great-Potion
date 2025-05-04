using System.Collections.Generic;
using UnityEngine;

namespace _00.Work.CheolYee._05._SO.CustomerChatSO
{
    [CreateAssetMenu(fileName = "CustomerDataList", menuName = "SO/CustomerDataList")]
    public class CustomerDataList : ScriptableObject
    {
        [Header("1Week")]
        public List<CustomerDataSo> customerLists1Week;
        [Header("2Week")]
        public List<CustomerDataSo> customerLists2Week;
        [Header("3Week")]
        public List<CustomerDataSo> customerLists3Week;
    }
}
