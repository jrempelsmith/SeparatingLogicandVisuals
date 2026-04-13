using System;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    // Fields, methods, events

    public event EventHandler OnCollide;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit anything");

        if (other.TryGetComponent(out ICollidable hitICollidable))
        {
            // This is where the logic realizes it has hit something

            // Do logic-related stuff in response to a collision
            hitICollidable.OnCollide(this);

            Debug.Log("hit an icollidable");
            // We are NOT going to control any visual, audio, etc here
            // Instead, we will fire an event.
            // The primary purpose of firing this event is to tell the audio, visual, etc.
            // That this collision has happened
            OnCollide?.Invoke(this, EventArgs.Empty);


        }

        //ICollidable hitICollidable = other.GetComponent<ICollidable>();
        //// only perform this logic if we hit an ICollidable
        //if (hitICollidable != null)
        //{
        //    hitICollidable.OnCollide(this);
        //}
    }
}
