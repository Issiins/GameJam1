using DefaultNamespace;
using Enviroment;
using UnityEngine;

namespace Environment
{
    [RequireComponent(typeof(Collider2D))]
    public class DoorButton : MonoBehaviour
    {
        [SerializeField] private Interactable _finishDoor;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") || _finishDoor == null) return;
            if(SoundManager.Instance != null)
                SoundManager.Instance.PlayButtonClick();
            _finishDoor.Trigger(true);
            _finishDoor.Trigger();
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player") || _finishDoor == null) return;
            _finishDoor.Trigger(false);
            _finishDoor.Trigger();
        }
    }
}