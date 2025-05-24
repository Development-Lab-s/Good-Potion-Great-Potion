using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.Base._05._SO
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
    {
        private Controls _controls;
    
        public Action OnEscButtonPressed;
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnESC(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnEscButtonPressed?.Invoke();
            }
        }
    }
}
