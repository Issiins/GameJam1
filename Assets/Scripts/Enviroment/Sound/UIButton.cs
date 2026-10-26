using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class UIButton : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (SoundManager.Instance == null) return;
            SoundManager.Instance.PlayButtonHover();
        }
    }
}