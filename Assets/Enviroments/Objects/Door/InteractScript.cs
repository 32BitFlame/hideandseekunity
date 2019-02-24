using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractScript : MonoBehaviour
{
    private Animator a;
    void Start()
    {
        a = GetComponent<Animator>();
    }
    public void Interact(Vector3 position)
    {
            Vector3 relative = (position - transform.position).normalized;
            if (Vector3.Dot(relative, transform.forward) > 0)
            {
                a.SetTrigger("OpeningFront");
            }
            else
            {
                //rotationDirection = -1;
            }
    }
}
