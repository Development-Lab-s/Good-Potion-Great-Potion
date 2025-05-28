using _00.Work.Base._02._Sprites.Manager;
using _00.Work.Base._02._Sprites.Manager.SoundManager;
using _00.Work.Base._05._SO;
using _00.Work.CheolYee._03._Scripts.Customer.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Work.CheolYee._03._Scripts.ButtonScripts
{
    public class MenuScript : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private Button mainButton;
        [SerializeField] private PlayerInputSO playerInput;
        
        private bool _isPressedEsc = false;

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
            if (SceneManagerScript.Instance?.isTimerFinished == true) return;
            
            _isPressedEsc = !_isPressedEsc;
            
            menu.SetActive(_isPressedEsc);
            
            Time.timeScale = _isPressedEsc ? 0 : 1;
            
            mainButton.gameObject.SetActive(!_isPressedEsc);
            
            if(_isPressedEsc) TimerManager.Instance?.StopTimer();
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
            _isPressedEsc = !_isPressedEsc;
            
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
