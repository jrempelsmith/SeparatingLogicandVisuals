using UnityEngine;

public class Wall : MonoBehaviour, ICollidable
{
    void ICollidable.OnCollide(PlayerCollisionDetection player)
    {
        Debug.Log(player + " hit a wall!");
    }
}
