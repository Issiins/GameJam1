

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputAsset;
        private InputActionMap _inputMap;
        private InputAction _move;
        private InputAction _jump;
        public Vector2 Direction { get; private set; }
        
        public InputAction JumpAction => _jump;

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
                Debug.LogWarning("Input asset map does not exist");
                return;
            }
            SetInputActions();
        }
        private void SetInputActions()
        {
            _move = _inputMap.FindAction("Move");
            _jump = _inputMap.FindAction("Jump");
        }

        private void EnableActions()
        {
            _move.performed += OnMove;
            _move.canceled += OnMove;
        }

        private void DisableActions()
        {
            _move.performed -= OnMove;
            _move.canceled -= OnMove;
        }
        private void OnDisable()
        {
            DisableActions();
            _inputMap?.Disable();
        }
        
        private void OnEnable()
        {
            EnableActions();
            _inputMap?.Enable();
        }
        private void OnMove(InputAction.CallbackContext ctx)
        {
            Direction = ctx.ReadValue<Vector2>();
        }
    }
}