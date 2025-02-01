using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJohnLemon : MonoBehaviour
{

    //Zona de variables globales

    //Variable pública para obtener la "Transform" del "player".
    public Transform Target;

    [Header("Vector3")]
    //Variable para suavidad en la velocidad de seguimiento de la cámara.
    [SerializeField]
    private float _smoothing;
    //Variable "Vector3" que será la distancia entre la cámara y el "player".
    [SerializeField]
    private Vector3 _offset;


    //Damos valor a "_offset" en el "Start()" que será la resta 
    //entre la posición de la cámara y la del "player".
    void Start()
    {
        
        _offset = transform.position - Target.position;

    }

    //Utilizamos "LateUpdate()", que se ejecuta en último lugar dentro del fotograma,
    //para esperar a que todos los movimientos del "player" estén calculados.
    private void LateUpdate()
    {

        //Variable local para colocar la posición a la que queremos mover la cámara
        //esto es posición del player + la distancia que queremos mantener.
        Vector3 desiredPosition = Target.position + _offset;
        //Movemos la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

    }
}
