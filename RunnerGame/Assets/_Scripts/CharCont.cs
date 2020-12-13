using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour
{
    public int speed = 0;
    public float LeftLane=-1.5f;
    public float RightLane=1.5f;
    public float MiddleLane=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -1.5)
            {
                this.transform.Translate(Time.deltaTime * speed * -1,0,0);
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 1.5)
            {
                this.transform.Translate(Time.deltaTime * speed , 0,0);
            }
            
            
        }
    }
}
