using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag(transform.gameObject.tag))
        {   
                
            //Puan Ekle
            GameController.Instance.scoreUp();
            KeyHolder.KeySpecifier();
        }
        else
        {
            GameController.Instance.GameOver = true;
            HUD.gameOverTrue();
        }        
        
    }
}
