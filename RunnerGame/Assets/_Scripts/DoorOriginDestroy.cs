using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOriginDestroy : MonoBehaviour
{
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag(transform.gameObject.tag))
        {
            Debug.Log(transform.parent.parent.gameObject.name+"+++++++++++++++++++++++++++");
            Destroy(transform.parent.parent.gameObject);
            
        }
    }
}
