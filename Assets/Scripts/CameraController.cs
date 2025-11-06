using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0.3f;
    [SerializeField] private float cameraWidth = 18.0f;
    private float currentPosX;
    private Vector3 cameraVelocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    void Start()
    {

    }

    private void Awake()
    {

    }

    // Update is called once per frame  
    private void Update() 
    {
        transform.position = Vector3.SmoothDamp(
                transform.position,
                new Vector3(currentPosX, transform.position.y, transform.position.z),
                ref cameraVelocity,
                //cameraSpeed * Time.deltaTime
                cameraSpeed //smoothTime
            );
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        if (_newRoom != null)
        {
            //TargetSnap
            float raxX = _newRoom.position.x;
            float snappedX = Mathf.Round(raxX / cameraWidth) * cameraWidth;
            currentPosX = snappedX;

            Debug.Log($"Camera target X: {currentPosX}");
            //currentPosX = _newRoom.position.x;
        }
    }
}