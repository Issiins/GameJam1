

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputAsset;
        private InputActionMap _inputMap;
        public InputAction Move { get; private set; }
        public InputAction Jump { get; private set; }

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
            Move = _inputMap.FindAction("Move");
            Jump = _inputMap.FindAction("Jump");
        }

        private void OnDisable()
        {
            _inputMap?.Disable();
        }

        private void OnEnable()
        {
            _inputMap?.Enable();
        }
    }
}