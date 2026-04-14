using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
    }

    public float GetForwardSpeed()
    {
        return forwardSpeed;
    }
}
