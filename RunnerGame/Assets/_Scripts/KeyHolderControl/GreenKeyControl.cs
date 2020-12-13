using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKeyControl : MonoBehaviour
{
    
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Green")
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
