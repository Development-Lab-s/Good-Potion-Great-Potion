using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using _00.Work.JaeHun._01._Scripts;

public class NextHerbClass : MonoBehaviour
{
    [SerializeField] private int _page;
    [SerializeField] CanvasGroup herbPanel1;
    [SerializeField] CanvasGroup herbPanel2;
    [SerializeField] CanvasGroup herbPanel3;
    private bool state;
    
    void Start()
    {
        state = true;
    }

    public void NextPage()
    {
        if(state)
        {
            switch(_page)
            {
                case 0:
                {
                    herbPanel1.alpha = 1;
                    herbPanel1.interactable = true;
                    herbPanel1.blocksRaycasts = true;
                    herbPanel2.alpha = 0;
                    herbPanel2.interactable = false;
                    herbPanel2.blocksRaycasts = false;
                    herbPanel3.alpha = 0;
                    herbPanel3.interactable = false;
                    herbPanel3.blocksRaycasts = false;
                    break;
                }
                case 1:
                {
                    herbPanel2.alpha = 1;
                    herbPanel2.interactable = true;
                    herbPanel2.blocksRaycasts = true;
                    herbPanel1.alpha = 0;
                    herbPanel1.interactable = false;
                    herbPanel1.blocksRaycasts = false;
                    herbPanel3.alpha = 0;
                    herbPanel3.interactable = false;
                    herbPanel3.blocksRaycasts = false;
                    break;
                }
                case 2:
                {
                    herbPanel3.alpha = 1;
                    herbPanel3.interactable = true;
                    herbPanel3.blocksRaycasts = true;
                    herbPanel1.alpha = 0;
                    herbPanel1.interactable = false;
                    herbPanel1.blocksRaycasts = false;
                    herbPanel2.alpha = 0;
                    herbPanel2.interactable = false;
                    herbPanel2.blocksRaycasts = false;
                    _page = -1;
                    break;
                }

                
            }
            _page++;
        }
    }
}
