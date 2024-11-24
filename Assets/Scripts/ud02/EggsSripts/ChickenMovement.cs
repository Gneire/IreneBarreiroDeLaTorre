using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    
    //Necesito crear dos variables flotantes tipo "horizontal" y "vertical"
    //Necesito determinar a qué velocidad ("_speed")
    //Necesito determinar grados que gira ("_turnSpeed")
    //Creo el método y lo llamo en el "update" para que "eschuche" todo el tiempo
    //Uso "GetAxis" para ordenar los movimientos

    //Zona de variables globales

    private float _horizontalMove,
                  _verticalMove,
                  _speed = 0.8f,
                  _turnSpeed = 90.0f; 

  

    void Update()
    {
        InputChicken();
        Move();
        Turn();
       
    }

    //Creo métodos de una sola funcionalidad y los llamo en Update
    private void InputChicken ()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");   
    }

    //indico que quiero hacer en las teclas, aplicando valores a los ejes
    private void Move()
    {
        transform.Translate(Vector3.forward * _verticalMove * _speed * Time.deltaTime);
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up * _horizontalMove, _turnSpeed * Time.deltaTime);        
    }
}
