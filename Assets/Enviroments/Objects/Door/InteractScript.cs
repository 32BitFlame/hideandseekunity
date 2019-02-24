using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class toggle
{
    public bool state = new bool();
    public void Toggle()
    {
        if(state == false)
        {
            state = true;
        }
        else
        {
            state = false;
        }
    }

}
public class InteractScript : MonoBehaviour
{
    public bool locked;
    public toggle active;
    private Vector3 Angle;
    void FixedUpdate()
    {
        
    }
}
