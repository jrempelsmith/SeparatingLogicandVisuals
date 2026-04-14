using UnityEngine;
using static PlayerCollisionDetection;

public class PlayerVisual : MonoBehaviour
{
    // This is going to control ONLY the visuals for the player
    // It has NOTHING to do with controlling logic.
    // It only updates the visuals when events are fired in the logic side of the code.

    [SerializeField] private PlayerCollisionDetection logic;
    private MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        // This is not me watching a pewdiepie video.
        // Rather, this is me subscribing to the pewdiepie channel.

        // i.e., this line does NOT call the Logic_OnCollide method.
        // Instead, it SUBSCRIBES the Logic_OnCollide method to the OnCollide event.
        // That way, when the event is fired, the 'Logic_OnCollide' method gets called automatically.
        logic.OnCollide += Logic_OnCollide;
    }

    private void OnDisable()
    {
        logic.OnCollide -= Logic_OnCollide; // unsubscribe when this gameobject is disabled, to prevent my method from being called when disabled
    }

    // This is me watching a video from a youtube channel I subscribe to.
    // In other words, this is the method that will get called automatically when the event is fired.
    private void Logic_OnCollide(object sender, OnCollideEventArgs e)
    {
        // Differentiate between different types of ICollidables I might hit

        if (e.hitICollidable is SpeedBoost)
        {
            if (e.playerSpeedOnCollision > 10)
            {
                mr.material.color = Color.green;
            }
            else
            {
                mr.material.color = Color.blue;
            }
        }
        else if (e.hitICollidable is Wall)
        {
            mr.material.color = Color.red;
        }
    }
}
