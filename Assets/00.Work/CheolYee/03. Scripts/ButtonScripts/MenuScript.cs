using System;
using _00.Work.Base._02._Sprites.Manager;
using _00.Work.Base._02._Sprites.Manager.SoundManager;
using _00.Work.Base._05._SO;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.ButtonScripts
{
    public class MenuScript : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private Button mainButton;
        [SerializeField] private PlayerInputSO playerInput;
        
        private bool isPressedEsc = false;

        private void OnEnable()
        {
            playerInput.OnEscButtonPressed += ToggleMenuUI;
        }

        private void OnDisable()
        {
            playerInput.OnEscButtonPressed -= ToggleMenuUI;
        }


        private void Start()
        {
            menu.SetActive(false);
        }

        private void ToggleMenuUI()
        {
            isPressedEsc = !isPressedEsc;
            
            menu.SetActive(isPressedEsc);
            
            Time.timeScale = isPressedEsc ? 0 : 1;
            
            mainButton.gameObject.SetActive(!isPressedEsc);
            
            if(isPressedEsc) TimerManager.Instance?.StopTimer();
            else TimerManager.Instance?.RestartTimer();
        }

        public void MainMenu()
        {
            menu.SetActive(true);
            SoundManager.Instance.ReassignUI();
            mainButton.gameObject.SetActive(false);
            TimerManager.Instance?.StopTimer();
            Time.timeScale = 0;
        }
        
        public void ContinueButton()
        {
            isPressedEsc = !isPressedEsc;
            
            Time.timeScale = 1;
            mainButton.gameObject.SetActive(true);
            menu.SetActive(false);
            TimerManager.Instance?.RestartTimer();
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
