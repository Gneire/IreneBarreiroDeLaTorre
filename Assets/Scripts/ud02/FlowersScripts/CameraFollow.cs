using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //zona variables globales 
    
    //para que acceda a la Transform del personaje, al "Target"
    public Transform Target;
    //para establecer una velocidad de seguimiento suave
    private float _smoothing;
    //para calcular la distancia entre cámara y "Target"
    private Vector3 _offset; 
    
    
    //lo inicializamos haciendo el cálculo en el "Start()"
    void Start()
    {
        _offset = transform.position - Target.position; 
        _smoothing = 0.5f;
    }

    // Para adaptarse al cambio de posición
    void Update()
    {
        Vector3 camPosition = Target.position + _offset;
        transform.position = Vector3.Lerp (transform.position,camPosition, _smoothing *Time.deltaTime);
    }
}
