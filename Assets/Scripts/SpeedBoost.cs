using UnityEngine;

public class SpeedBoost : MonoBehaviour, ICollidable
{
    void ICollidable.OnCollide(PlayerCollisionDetection player)
    {
        Debug.Log("player hit a speed boost!");
    }
}
