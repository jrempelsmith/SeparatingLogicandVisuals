using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    // This is going to control ONLY the visuals for the player
    // It has NOTHING to do with logic

    // However, it needs to know when something happened (i.e. in logic) in order to
    // know when to update the visual

    // In order to know when something happened, we will subscribe to the event

    [SerializeField] private PlayerCollisionDetection logic;
    private MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        // this line does NOT call the Logic_OnCollide method
        // instead, it SUBSCRIBES to the event, so that when the event is fired,
        // this method gets called automatically
        logic.OnCollide += Logic_OnCollide; 
    }

    private void OnDisable()
    {
        
    }

    // This is the method that will run in response to the event
    private void Logic_OnCollide(object sender, System.EventArgs e)
    {
        mr.material.color = Color.red;
    }
}
