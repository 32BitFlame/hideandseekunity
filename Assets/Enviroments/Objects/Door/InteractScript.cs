using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float rotationEnd = 90f;
    public int rotationDirection;
    public bool interacted;
    public Dictionary<GameObject, bool> objectsIn;
    void Start()
    {
        transform.tag = "door";
        try
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("player"))
            {
                objectsIn[obj] = false;
            }
        }
        catch
        {

        }
    }
    void Update()
    {
        try
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("player"))
            {
                //May need to change so that new objects are added
                if ((obj.GetComponent<plr_move>().interactPress == true) && (objectsIn[obj]))
                {
                    Interact(obj.transform.position);
                }
            }
        }
        catch
        {

        }
    }
    void Interact(Vector3 position)
    {
        Debug.Log("Interacted");
        if (interacted == false)
        {

            interacted = true;
            Vector3 relative = (position - transform.position).normalized;
            if (Vector3.Dot(relative, transform.forward) > 0)
            {
                print("Front");
                //Open Front
                rotationDirection = 1;
            }
            else
            {
                print("Back");
                //Open Back
                rotationDirection = -1;
            }

        }
    }
    void OnTriggerEnter(Collider objectEntered)
    {
        if (objectEntered.tag == "player")
        {
            objectsIn[objectEntered.gameObject] = true;
        }
    }
    void OnTriggerExit(Collider objectExited)
    {
        if (objectExited.tag == "player")
        {
            objectsIn[objectExited.gameObject] = false;
        }
    }
}
