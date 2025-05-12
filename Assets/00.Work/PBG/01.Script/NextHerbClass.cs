using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NextHerbClass : MonoBehaviour
{
    [SerializeField] private int _page;
    [SerializeField] GameObject herbPanel1;
    [SerializeField] GameObject herbPanel2;
    [SerializeField] GameObject herbPanel3;
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
                    herbPanel1.SetActive(true);
                    herbPanel2.SetActive(false);
                    herbPanel3.SetActive(false);
                    break;
                }
                case 1:
                {
                    herbPanel2.SetActive(true);
                    herbPanel1.SetActive(false);
                    herbPanel3.SetActive(false);
                    break;
                }
                case 2:
                {
                    herbPanel3.SetActive(true);
                    herbPanel1.SetActive(false);
                    herbPanel2.SetActive(false);
                    _page = -1;
                    break;
                }

                
            }
            _page++;
        }
    }
}
