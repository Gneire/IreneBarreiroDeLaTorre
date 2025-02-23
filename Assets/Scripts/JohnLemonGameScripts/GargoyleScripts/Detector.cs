using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //Zona de variables globales
    //Variable tipo componente de recurso de escena 
    public GameManagerScript GameManagerScript;

    private void OnTriggerEnter(Collider infoAccess) 
    {
        if (infoAccess.CompareTag("JohnLemon"))
        {

            //Debug.Log("Te he pillado");
            GameManagerScript.IsPlayerCaught = true;

        }
        
    }

}
