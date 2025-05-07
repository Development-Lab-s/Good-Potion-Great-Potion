using System;
using UnityEngine;

namespace _00.Work.CheolYee._05._SO.CustomerChatSO
{
    [CreateAssetMenu(fileName = "CustomerDataSO", menuName = "SO/CustomerDataSO")]
    public class CustomerDataSo : ScriptableObject
    {
        [Header("Renderer")]
        public Sprite customerSprite;
        [Header("Lines")]
        public string[] mainLines;
        public string[] hint;
        public string[] hint2;
        public string[] exitLines;
        public string[] forcedExitLines;
        [Header("PotionData")]
        public string requiredPotions;

        [ContextMenu("Create Line")]
        public void CreateLine()
        {
            Array.Resize(ref mainLines, mainLines.Length + 1);
            Array.Resize(ref hint, hint.Length + 1);
            Array.Resize(ref hint2, hint2.Length + 1);
            Array.Resize(ref exitLines, exitLines.Length + 1);
            Array.Resize(ref forcedExitLines, forcedExitLines.Length + 1);
        }
        
        [ContextMenu("Remove Line")]
        public void RemoveLine()
        {
            Array.Resize(ref mainLines, mainLines.Length - 1);
            Array.Resize(ref hint, hint.Length - 1);
            Array.Resize(ref hint2, hint2.Length - 1);
            Array.Resize(ref exitLines, exitLines.Length - 1);
            Array.Resize(ref forcedExitLines, forcedExitLines.Length - 1);
        }
    }
}
