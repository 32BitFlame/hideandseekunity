using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controls : MonoBehaviour
{
    [SerializeField]
    public float mouseSpeed = 100.5f;
    [SerializeField]
    public float strength;
    private Transform tr;
    private GameObject plr;
    private Vector3 plr_position;
    private Vector3 newPosition;
    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        plr = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        mouseY += Input.GetAxis("MX") * mouseSpeed;
        mouseX += Input.GetAxis("MY") * mouseSpeed;
        mouseX = Mathf.Clamp(mouseX, -90f, 90f);
        plr_position = plr.transform.position;
        newPosition = plr_position;
        newPosition.y += 1f;
        tr.position = newPosition;
        RaycastHit interactObject;
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(transform.position, transform.forward, out interactObject, 9f, 9))
            {
                interactObject.transform.gameObject.SendMessage("Interact", transform.position, SendMessageOptions.RequireReceiver);
                print("hit");
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit rayHit;
            if ((Physics.Raycast(transform.position, transform.forward, out rayHit, 4f)))
            {
                if (rayHit.rigidbody != null)
                {
                    print("Boom!");
                    rayHit.rigidbody.AddForceAtPosition(transform.forward * strength, rayHit.point, ForceMode.Impulse);
                }
            }
        }
    }
    void FixedUpdate()
    {
        
        transform.eulerAngles = new Vector3(-mouseX, mouseY, 0f);
    }

    public float returnmouseY()
    {
        return mouseY;
    }
}
