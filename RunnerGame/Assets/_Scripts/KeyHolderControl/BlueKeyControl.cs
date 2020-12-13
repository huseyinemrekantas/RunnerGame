using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeyControl : MonoBehaviour
{
    
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Blue")
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
