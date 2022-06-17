using Player;
using UnityEngine;

public class TestApplyEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerData>().BuffAttack(2,10);
    }
}
