

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputAsset;
        private InputActionMap _inputMap;
        private InputActionMap _uiMap;
        private InputAction _move;
        private InputAction _jump;
        private InputAction _pause;
        public Vector2 Direction { get; private set; }
        
        public InputAction JumpAction => _jump;
        public event Action OnPauseTriggered;

        private void Awake()
        {
            if (_inputAsset == null)
            {
                Debug.LogWarning("Input asset was not set");
                return;
            }
            _inputMap = _inputAsset.FindActionMap("Player");
            if (_inputMap == null)
            {
                Debug.LogWarning("Input 'Player' asset map does not exist");
                return;
            }
            _uiMap = _inputAsset.FindActionMap("UI");
            if (_inputMap == null)
            {
                Debug.LogWarning("Input 'UI' asset map does not exist");
                return;
            }
            SetInputActions();
        }
        private void SetInputActions()
        {
            _move = _inputMap.FindAction("Move");
            _jump = _inputMap.FindAction("Jump");
            _pause = _uiMap.FindAction("Game Pause");
        }

        private void EnableActions()
        {
            EnablePlayerInputs();
            EnableGamePauseInput();
        }

        public void EnableGamePauseInput()
        {
            _move.performed += OnMove;
            _pause.performed += OnPause;
            _pause.Enable();
        }

        public void EnablePlayerInputs()
        {
            _move.performed += OnMove;
            _move.canceled += OnMove;
        }
        private void DisableActions()
        {
            DisablePlayerInputs();
            DisableGamePauseInput();
        }

        public void DisableGamePauseInput()
        {
            _pause.performed -= OnPause;
        }

        public void DisablePlayerInputs()
        {
            _move.performed -= OnMove;
            _move.canceled -= OnMove;
        }
        private void OnDisable()
        {
            DisableActions();
            _inputMap?.Disable();
            _uiMap?.Disable();
        }
        
        private void OnEnable()
        {
            EnableActions();
            _inputMap?.Enable();
        }

        private void OnPause(InputAction.CallbackContext ctx) => OnPauseTriggered?.Invoke();
        private void OnMove(InputAction.CallbackContext ctx)
        {
            Direction = ctx.ReadValue<Vector2>();
        }
        public void DisableInputs() => OnDisable();
        public void EnableInputs() => OnEnable();
    }
}