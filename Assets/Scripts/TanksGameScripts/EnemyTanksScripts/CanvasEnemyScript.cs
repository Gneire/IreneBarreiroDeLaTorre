using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemyScript : MonoBehaviour
{
    private void Update()
    {
        //para que mire todo el tiempo a la c�mara de la escena
        transform.LookAt(Camera.main.transform.position);
    }
    


}
