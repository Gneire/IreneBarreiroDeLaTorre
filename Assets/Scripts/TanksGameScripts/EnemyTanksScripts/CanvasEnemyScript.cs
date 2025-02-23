using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemyScript : MonoBehaviour
{
    private void Update()
    {
        //para que mire todo el tiempo a la cámara de la escena
        transform.LookAt(Camera.main.transform.position);
    }
    


}
