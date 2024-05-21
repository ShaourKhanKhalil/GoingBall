using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    public Rigidbody RigidBody;
    public Transform StartPOint;
    public Transform cameraTransform;
    public VariableJoystick variableJoystick;
    public float InputFakeHandleMoveSpeed;

    public AnimationCurve SpeedCurve;

    public Transform InnerBall;

    [Space]

    [SerializeField] public float SpeedofDampingInMoving;
    [SerializeField] public float SpeedofDampingInIdle;

    [Space]
    public float MaxForce;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 90;
    }

    void Update()
    {
        float moveHorizontal = variableJoystick.Horizontal;
        float moveVertical = variableJoystick.Vertical;

        Vector3 forward = cameraTransform.forward;
        Vector3 up = cameraTransform.up;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * moveVertical + right * moveHorizontal;

        RigidBody.AddForce(direction * MaxForce * SpeedCurve.Evaluate(variableJoystick.Speed) , ForceMode.Force);

        InnerBall.rotation = Quaternion.Euler(0, Vector2.Angle(variableJoystick.Direction, cameraTransform.up), 0);
        InnerBall.Rotate(RigidBody.velocity.magnitude, 0,0,Space.Self);
        
        InnerBall.transform.position = this.transform.position;

    }



    void Respawn()
    {
        RigidBody.isKinematic = true;
        RigidBody.isKinematic = false;

        transform.position = StartPOint.position;
        transform.rotation = StartPOint.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Respawn();
    }
}
