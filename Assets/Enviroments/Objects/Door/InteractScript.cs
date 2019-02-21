using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float rotationEnd = 90f;
    [SerializeField]
    public bool interacted = false;

    public Dictionary<GameObject,bool> objectsInInteractRange;
    public Dictionary<GameObject, bool> mouseOver;
    private bool triggered;
    private bool mouseOn;
    private float rotationDirection;
    private float startRotation;
    private float currentRotation;
    private Vector3 newRotation;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        mouseOn = false;
        startRotation = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation = transform.localEulerAngles.y;
        if(interacted)
        {
            if( rotationDirection > 0)
            {
                if(currentRotation  < rotationEnd)
                {
                    newRotation.y += rotationSpeed;
                }
            }
            else
            {
                if (currentRotation > -rotationEnd)
                {
                    newRotation.y -= rotationSpeed;
                }
            }
        } else if(newRotation.y != startRotation)
        {
            if(currentRotation < startRotation)
            {
                newRotation.y += rotationSpeed;
            } else
            {
                newRotation.y -= rotationSpeed;
            }
        }
        newRotation.y = Mathf.Clamp(newRotation.y, -rotationEnd, rotationEnd);
    }
    private void Interact(Vector3 position)
    {
        Debug.Log("Interacted");
        if (interacted == false)
        {
            
            interacted = true;
            Vector3 relative = (position - transform.position).normalized;
            if (Vector3.Dot(relative, transform.forward) > 0)
            {
                rotationDirection = 1;
            }
            else
            {
                rotationDirection = -1;
            }

        }
        else
        {

            interacted = false;
            rotationDirection = 0;
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        objectsInInteractRange[collider.gameObject] = true;
    }
    private void OnTriggerExit(Collider collider)
    {
        objectsInInteractRange[collider.gameObject] = false;
    }
    private void OnMouseEnter()
    {
        
    }
}
