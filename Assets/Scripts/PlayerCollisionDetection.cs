using System;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;

    // A container class that carries information about the event
    public class OnCollideEventArgs : EventArgs
    {
        // put the fields that will carry event information
        public ICollidable hitICollidable; // what I hit
        public float playerSpeedOnCollision; // how fast
    }
    
    // The definition of the event
    public event EventHandler<OnCollideEventArgs> OnCollide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollidable hitICollidable))
        {
            // This is where the logic realizes it has hit something

            // Do logic-related stuff in response to a collision
            hitICollidable.OnCollide(this);

            // does pewdiepie call me when he publishes a video? NONONO
            //playerVisual.UpdateVisual(); 

            /*
             We are NOT going to control any visual, audio, etc here
             Instead, we will fire an event.
             The primary purpose of firing this event is to tell the audio, visual, etc.
             that this collision has happened
            */

            // One way to define OnCollideEventArgs:
            /*
            OnCollideEventArgs myEventArgs = new OnCollideEventArgs();
            myEventArgs.hitICollidable = hitICollidable;
            myEventArgs.playerSpeedOnCollision = GetComponent<Rigidbody>().linearVelocity.magnitude;
            myEventArgs.playerDirectionOnCollision = GetComponent<Rigidbody>().linearVelocity.normalized;
            */

            // But instead we will just define a new OnCollideEventArgs right where we fire the event
            // Here, pewdiepie is publishing a video. He doesn't know who is subscribed.
            OnCollide?.Invoke(this, new OnCollideEventArgs
            {
                hitICollidable = hitICollidable,
                playerSpeedOnCollision = playerMove.GetForwardSpeed()
            });
        }
    }
}
