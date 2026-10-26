using UnityEngine;

namespace DefaultNamespace
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        private AudioSource _audioSource;
        public AudioClip _buttonHover;
        public AudioClip _jumpSound;
        public AudioClip _deathSound;
        public AudioClip _IGButtonPress;
        public AudioClip _levelComplete;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else 
                Destroy(gameObject);
            
        }
        
        public void PlayButtonHover() => PlaySound(_buttonHover);
        public void PlayJumpSound() => PlaySound(_jumpSound);
        public void PlayDeath() => PlaySound(_deathSound);
        public void PlayButtonClick() => PlaySound(_IGButtonPress);
        public void PlayWinSound() => PlaySound(_levelComplete);

        private void PlaySound(AudioClip clip)
        {
            if (clip != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(clip);
            }
        }
    }
}