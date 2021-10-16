using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCorn : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "popper")
        {
            //Debug.Log("popper hit-" + "I am " + this.name);
            Transform prop = transform.GetChild(0);
            prop.parent = null;
            prop.gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }
    }
}
