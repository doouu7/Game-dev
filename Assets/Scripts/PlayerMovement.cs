using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private bool grounded = false;

    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 20f;

    [Header("Rotation (physics)")]
    [SerializeField] private float jumpAngularImpulse = 100f; // torque impulse (tweak) 
    [SerializeField] private float maxAngularVelocity = 180f; // clamp angular velocity (deg/sec) 
    [SerializeField] private float rotationDamping = 400f;    // dampen when grounded (deg/sec^2) 
    [SerializeField] private float inputThreshold = 0.1f;     // how much horizontalInput counts as left/right 

    private float horizontalInput = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {

    }

    private void Awake()
    {
        //Grab reference(s) for rigidbody
        body = GetComponent<Rigidbody2D>();

        //Ensure we can rotate freely 
        body.freezeRotation = false;                               //Rigidbody2D property; rotation is allowed 
        body.interpolation = RigidbodyInterpolation2D.Interpolate; //Smoothens motion 

    }

    // Update is called once per frame 
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //[-1,1]

        //Left & Right movement (arrow_keys) 
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        //Jump 
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump(horizontalInput);
    }

    // FixedUpdate runs (default) 50Hz
    private void FixedUpdate()
    {
        // Clamp angular velocity to avoid wild spinning 
        if (Mathf.Abs(body.angularVelocity) > maxAngularVelocity)
            body.angularVelocity = Mathf.Sign(body.angularVelocity) * maxAngularVelocity;

        if (grounded) //Damp angular velocity toward zero 
        {
            // Smoothly reduce angular velocity magnitude (deg/sec) 
            float av = body.angularVelocity;
            float sign = Mathf.Sign(av);
            float newMag = Mathf.MoveTowards(Mathf.Abs(av), 0f, rotationDamping * Time.fixedDeltaTime);
            body.angularVelocity = newMag * sign;
        }
    }

    private void Jump(float horizontalInput)
    {
        // vertical impulse (set velocity for deterministic jump) 
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        grounded = false;

        // If input is significantly left/right, apply an angular impulse so the player rotates in-air 
        if (horizontalInput > inputThreshold)
        {
            body.AddTorque(-jumpAngularImpulse, ForceMode2D.Impulse); // Jumping right -> rotate negative Z (clockwise) 
        }
        else if (horizontalInput < -inputThreshold)
        {
            body.AddTorque(jumpAngularImpulse, ForceMode2D.Impulse); // Jumping left -> rotate positive Z (counter-clockwise) 
        }
        // else: small input -> no torque (jump straight up) 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    //OPTIONAL: visualize current angular velocity in the inspector 
    private void OnGUI()
    {
        // GUI.Label(new Rect(10, 10, 300, 20), "AngularVelocity: " + body.angularVelocity.ToString("F1")); 
    }
}