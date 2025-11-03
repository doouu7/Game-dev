using UnityEngine;

public class TripWire : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;

    [SerializeField] private CameraController cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Triggered by: {collision.name}");

        if (collision.tag == "Player")
        {
            //Debug.Log($"TripWire ACTIVATED");
            float playerVelocityX = collision.attachedRigidbody?.linearVelocity.x ?? 0f;

            if (playerVelocityX > 0f)
            {
                //Debug.Log($"MoveToNewRoom(nextRoom)");
                cam.MoveToNewRoom(nextRoom);
            }
            else if (playerVelocityX < 0f)
            {
                //Debug.Log($"MoveToNewRoom(previousRoom)");
                cam.MoveToNewRoom(previousRoom);
            }
        }
        else
        {
            //Debug.Log($"TripWire NOT activated");
        }
    }
}