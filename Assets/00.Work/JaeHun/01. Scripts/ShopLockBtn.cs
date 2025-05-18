using System;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace _00.Work.JaeHun._01._Scripts
{
    public class ShopLockBtn : MonoBehaviour
    {
        [SerializeField] private GameObject[] shopLockBtn;

        [SerializeField] private int week = 0;

        private void Start()
        {
            shopLockBtn[0].SetActive(false);
            shopLockBtn[1].SetActive(false);
            shopLockBtn[2].SetActive(false);
            
            week = SceneManagerScript.Instance.currentWeek;

            switch (week)
            {
                case 1:
                {
                    shopLockBtn[0].SetActive(true);
                    break;
                }
                case 2:
                {
                    for (int i = 0; i < week; i++)
                    {
                        shopLockBtn[i].SetActive(true);
                    }
                    break;
                }
                case 3:
                {
                    for (int i = 0; i < week; i++)
                    {
                        shopLockBtn[i].SetActive(true);
                    }
                    break;
                }
            }
        }
    }
}
