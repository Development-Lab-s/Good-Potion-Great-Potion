using System;
using _00.Work.Base._02._Sprites.Manager;
using TMPro;
using UnityEngine;

public class SetTimeText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        TimerManager.Instance.SetTimerText(text);
    }
}
