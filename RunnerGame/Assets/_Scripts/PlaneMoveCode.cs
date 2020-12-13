using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveCode : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0,- 3);
    }
    private void Update()
    {
        if (GameController.Instance.GameOver==false)
        {
            
            if (200 > GameController.Instance.Score && GameController.Instance.Score > 100)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -4);
            }
            else if (200 < GameController.Instance.Score )
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -6);
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
    }

}
