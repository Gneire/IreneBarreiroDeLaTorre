using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJohnLemon : MonoBehaviour
{

    //Zona de variables globales

    //Variable p�blica para obtener la "Transform" del "player".
    public Transform Target;

    [Header("Vector3")]
    //Variable para suavidad en la velocidad de seguimiento de la c�mara.
    [SerializeField]
    private float _smoothing;
    //Variable "Vector3" que ser� la distancia entre la c�mara y el "player".
    [SerializeField]
    private Vector3 _offset;


    //Damos valor a "_offset" en el "Start()" que ser� la resta 
    //entre la posici�n de la c�mara y la del "player".
    void Start()
    {
        
        _offset = transform.position - Target.position;

    }

    //Utilizamos "LateUpdate()", que se ejecuta en �ltimo lugar dentro del fotograma,
    //para esperar a que todos los movimientos del "player" est�n calculados.
    private void LateUpdate()
    {

        //Variable local para colocar la posici�n a la que queremos mover la c�mara
        //esto es posici�n del player + la distancia que queremos mantener.
        Vector3 desiredPosition = Target.position + _offset;
        //Movemos la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

    }
}
