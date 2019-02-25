using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon
{
    public float damage;
    public float firerate;
    public float accuracy;
    public float range;
    public Weapon(float Damage, float Firerate, float Accuracy, float range)
    {
        this.damage = Damage;
        this.firerate = Firerate;
        this.accuracy = Accuracy;
        this.range = range;
    }
    public void fire(Vector3 currentPosition, Vector3 towards)
    {
        Vector3 target = towards.normalized * this.range;
    }
}
public class plr_move : MonoBehaviour
{
    [SerializeField]
    private float spd = 3.5f;
    [SerializeField]
    private float jsp = 30.5f;
    [SerializeField]
    private float airSpeed;
    [SerializeField]
    private int maximumj = 2;
    public float realSpd;
    private Transform tr;
    private Transform cam;
    private Vector3 rotate;
    private Vector3 Vector_Jump;
    private CharacterController character;
    private Rigidbody rb;
    private Vector3 Vector_X;
    private Vector3 Vector_Z;
    private Vector3 TotalMove;
    private Quaternion newRotation;
    private bool isFiring;
    private camera_controls cameraScript;
    private Vector3 bellow;
    int jumps;
    public bool interactPress;
    void Start()
    {
        transform.tag = "player";
        isFiring = false;
        realSpd = spd;
        tr = GetComponent<Transform>();
        rotate = new Vector3(0f,0f,0f);
        cam = this.gameObject.transform.GetChild(0);
        cameraScript = cam.GetComponent<camera_controls>();
        Vector_Jump.y = jsp;
        character = GetComponent<CharacterController>();
        jumps = maximumj;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            interactPress = true;
        }
        else
        {
            interactPress = false;
        }
        bellow = new Vector3(transform.position.x, -50, transform.position.z);
        float xsp = Input.GetAxisRaw("Horizontal");
        float zsp = Input.GetAxisRaw("Vertical");
        Vector_X = transform.right * xsp;
        Vector_Z = transform.forward * zsp;
        TotalMove = (Vector_X + Vector_Z).normalized * spd;
        if (Input.GetKeyDown("space") && (jumps > 0))
        {
            print(jumps);
            rb.AddForce(Vector_Jump);
            jumps--;
        }
        //tr.eulerAngles = new Vector3(0, cameraScript.returnmouseY(), 0);

        if((Physics.Raycast(transform.position, bellow, 1.6f)) && (rb.velocity.y <= 0.03f) && (rb.velocity.y >= -0.03f))
        {
            jumps = maximumj;
            
        }
        if(Input.GetMouseButton(0))
        {

        }
    }
    void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(0, cameraScript.returnmouseY(), 0));
        if (TotalMove != Vector3.zero)
        {
            rb.MovePosition(rb.position + TotalMove * Time.fixedDeltaTime);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if ((Physics.Raycast(transform.position, bellow, 1.6f)))
        {
            jumps = maximumj;

        }
    }
}
