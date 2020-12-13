using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCreateCode : MonoBehaviour
{
    public GameObject RoadPrefab;
    public GameObject BackPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Limit")
        {

            Instantiate(RoadPrefab, new Vector3(0, 0, 62), Quaternion.identity);
        }
        if (other.tag=="DestroyLimit")
        {
            Destroy(transform.parent.gameObject);
        }
    }


}
