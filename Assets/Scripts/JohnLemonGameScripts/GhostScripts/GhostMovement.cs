using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostMovement : MonoBehaviour
{

    //Zona de variables globales

    [Header ("WayPoints")]
    //"Array" de posiciones para la patrulla del fantasma.
    [SerializeField]
    private Transform[] _positionsArray;
    //Variable para la velocidad del movimiento del fantasma.
    [SerializeField]
    private float _speed;
    //Variable tipo Vector3 para almacenar la posici�n hacia la que se dirige
    private Vector3 _posToGo;
    //�ndice para controlar en que posici�n del "Array" est�.
    private int _i;
    //Variables para el "RayCast" y el "RayCastHit".

    [Header("RayCast")]
    private Ray _ray;
    private RaycastHit _hit;
    //Quiero darle una longitud de alcance al "Raycast" para que el fantasma
    //nos vea (y nos pille) a una distancia determinada y quiero probar desde fuera
    [SerializeField]
    private float _rayLenght;

    //Variable para conectar los scripts y manejarlos desde el GameManager
    public GameManagerScript GameManagerScript;


    //Empiezo a gestionar el "Array" desde el "Star()".
    void Start()
    {
        //El �ndice en el que empieza es cero.
        _i = 0;
        //Le digo a "_posToGo" que almacene la posici�n del "Array"
        //(en este caso 0) y que lo lleve a "_posToGo".
        _posToGo = _positionsArray[_i].position;

    }

    private void FixedUpdate()
    {

        DetectionJohnLemon();

    }

    void Update()
    {

        Move();
        ChangePosition();
        Rotate();

    }

    //Creo m�todo y lo llamo desde el Update
    private void Move()
    {
        //Posicion es hacia (el vector actual, el vector al que
        //quiero que vaya y la distancia m�xima).
        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);
    }

    //Creo m�todo para qwue vuelva y le aplico un "Vector3.Dinstance"
    //que devuelve la distancia entre dos vectores.
    private void ChangePosition()
    {

        //Si el fantasma ha llegado a su destino
        if (Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {
            //Comprobar si estoy en la �ltima casilla del "Array" (elemento1)
            if (_i == _positionsArray.Length -1)
            {
                //Vuelve a la casilla inicial del "Array".
                _i = 0;

            }
            else
            {

                _i++;

            }

            _posToGo= _positionsArray[_i].position; 

        }
    }

    //Creo m�todo para que rote y lo llamo desde el "Update()"
    private void Rotate()
    {

        transform.LookAt(_posToGo);

    }
    
    //Creo m�todo para lanzar el "Raycast" y lo llamo desde "FixedUpdate()"
    private void DetectionJohnLemon()
    {
        //Establezco desde d�nde y hacia qu� direcci�n (sumo 1 en el eje y)
        _ray.origin = new Vector3 (transform.position.x, transform.position.y + 1.0f,  transform.position.z);
        //Direcci�n del rayo
        _ray.direction = transform.forward;

        //Lanzo rayo y recojo la informaci�n del impacto
        if(Physics.Raycast (_ray,out _hit, _rayLenght))
        {
            //Compara si coincide etiqueta del player "JohnLemon"
            if (_hit.collider.CompareTag("JohnLemon"))
            {

                Debug.Log("Soy el fantasma y te he pillado");
                GameManagerScript.IsPlayerCaught = true;    



}

        }

    }

}
