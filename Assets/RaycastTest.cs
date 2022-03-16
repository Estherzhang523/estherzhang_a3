using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RaycastTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            print("R");
            Debug.DrawLine(this.gameObject.transform.position,this.gameObject.transform.position+(100.0f*this.gameObject.transform.forward),Color.red,100.0f);
            RaycastHit result;
            if (Physics.Raycast(this.gameObject.transform.position,this.gameObject.transform.forward,out result, Mathf.Infinity)){
                print("My ray hit: "+result.collider.gameObject.name);
            }
        }
    }
}
