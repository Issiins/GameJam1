using UnityEngine;

namespace Enviroment
{
    public class Interactable : MonoBehaviour
    {
        protected bool Status { get; private set; }
        public virtual void Trigger(bool status)
        {
            if(Status == status) return;
            Status = status;
        }

        public virtual void Trigger()
        {
            
        }
    }
}