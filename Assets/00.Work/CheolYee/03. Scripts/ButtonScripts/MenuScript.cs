using System;
using _00.Work.Base._02._Sprites.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.ButtonScripts
{
    public class MenuScript : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private Button mainButton;


        private void Start()
        {
            menu.SetActive(false);
        }

        public void MainMenu()
        {
            menu.SetActive(true);
            mainButton.gameObject.SetActive(false);
            TimerManager.Instance.StopTimer();
            Time.timeScale = 0;
        }
        
        public void ContinueButton()
        {
            Time.timeScale = 1;
            mainButton.gameObject.SetActive(true);
            menu.SetActive(false);
            TimerManager.Instance.RestartTimer();
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
