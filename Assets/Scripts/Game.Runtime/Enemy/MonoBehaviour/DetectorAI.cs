using Player;
using UnityEngine;

namespace Enemy.Core
{
    public class DetectorAI : MonoBehaviour
    {
        private MainPlayer _mainPlayer;

        public bool IsDetectedPlayer
        {
            get
            {
                return _mainPlayer != null;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                _mainPlayer = other.GetComponent<MainPlayer>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                _mainPlayer = null;
        }
    }
}