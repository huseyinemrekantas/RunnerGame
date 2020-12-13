using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneLevel2Code : MonoBehaviour
{
    [SerializeField] GameObject DoorOrigin;
    [SerializeField] GameObject childpar;

    GameObject childParent;
    int Spacer;

    private void Start()
    {
        childParent = Instantiate(childpar, new Vector3(0,0,0), Quaternion.identity);

        if (transform.childCount > 8)
        {
            Destroy(transform.GetChild(8).gameObject);
            GameController.Instance.deleteChildCount++;
        }

        doorPositionControl();
    }
    public void doorPositionControl()
    {
        for (int j = 0; j < 6; j++)
        {
            GameObject instantiatedObject = Instantiate(DoorOrigin, DoorOrigin.transform.position, Quaternion.identity, childParent.transform);
            instantiatedObject.transform.localPosition = new Vector3(DoorOrigin.transform.position.x, DoorOrigin.transform.position.y, DoorOrigin.transform.position.z + GameController.Instance.doorZ);
            childParent.transform.parent = transform;
            childParent.transform.localPosition = new Vector3(0, 0, GameController.Instance.deleteChildCount * -62);

            GameController.Instance.doorZ += 10.3f;

            for (int i = 0; i < 2; i++)
            {
                Spacer = Random.Range(0, 3);
                Vector3 temp = instantiatedObject.transform.GetChild(0).transform.position;
                instantiatedObject.transform.GetChild(0).transform.position = instantiatedObject.transform.GetChild(Spacer).transform.position;
                instantiatedObject.transform.GetChild(Spacer).transform.position = temp;
            }
        }

    }
}
