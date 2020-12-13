using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedStart : MonoBehaviour
{
    void Start()
    {
        GameController.Instance.FixedStart();
    }

}
