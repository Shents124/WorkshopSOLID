using Player;
using UnityEngine;
using UnityEngine.Events;

namespace EventSO
{
    [CreateAssetMenu(fileName = "PlayerDataEventSO", menuName = "EventSO/PlayerDataEventSO")]
    public class PlayerDataEventSO : ScriptableObject
    {
        public UnityAction<PlayerData> onRaisedEvent;

        public void RaiseEvent(PlayerData playerData)
        {
            onRaisedEvent?.Invoke(playerData);
        }
    }
}