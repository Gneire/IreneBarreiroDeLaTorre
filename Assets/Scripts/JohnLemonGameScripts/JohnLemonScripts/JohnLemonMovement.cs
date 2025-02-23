using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{
    //Zona de variables globales

    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;
    // Creo una variable tipo Vector3 para guardar la dirección del movimiento
    // y decirle al Rigidbody hacia dónde se mueve Juanito.
    [SerializeField]
    private Vector3 _direction;
   
    //Variables para conseguir los componentes
    private Rigidbody _rb;
    private Animator _anim;
    private AudioSource _audioSource;

    //Variables para los ejes
    private float _horizontal,
                  _vertical;


    //Obtengo el "Rigidbody" y el "Animator" utilizando
    //el "GetComponent()" desde el "Awake()"
    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {

        Rotation();

    }

    void Update()
    {

        InputsPlayer();
        IsAnimated();
        AudioSteps();

    }


    //Creo método para las entradas de las teclas y lo llamo desde "Update()"
    private void InputsPlayer()
    {

        //Para las teclas A y D; así como flechas < >
        _horizontal = Input.GetAxis("Horizontal");
        //Para las teclas W y S; así como /\ V
        _vertical = Input.GetAxis("Vertical");
        //Nuevo vector para guardar estos datos
        _direction = new Vector3(_horizontal, 0.0f, _vertical);
        //Normalizo el Vector para que sea unitario, con el método "Normalize()"
        _direction.Normalize();

    }

    //Creo método para que Juanito se mueva y lo llamo desde el "Update()"
    private void IsAnimated()
    {

        // si es diferente a 0; osea que sí está en movimiento
        if(_horizontal != 0.0f || _vertical != 0.0f) 
        {
            _anim.SetBool("IsWalking", true);
        }
        // si no; osea si  está quieto
        else
        {
            _anim.SetBool("IsWalking", false);
        
        }

    }

    //Creo método para el clip de audio de los pasos y lo llamo desde el "Update()"
    private void AudioSteps() 
    {

        //Si hay movimiento
        if(_horizontal != 0.0f || _vertical != 0.0f)
        {

            if (_audioSource.isPlaying == false) 
            {

                _audioSource.Play();

            }
        }
        else 
        {

                _audioSource.Stop();
            
        }
        
    }


    //Método para que el Rigidbody se mueva igual que el clip de animación
    //Uso el método "MovePosition()" para mover el "Rigidbody" de forma suave
    //Fuera, en el Inspector en el componente Rigidbody activo "is Kinematic"
    //Lo hago desde otro método; el "OnAnimatorMove" (No lo hago desde el "FixedUpdate"
    //porque este se procesa antes de la máquina de estados)
    private void OnAnimatorMove()
    {

        //Aplico al MovePosition la velocidad y longitud de desplazamiento de Juanito
        // dentro del clip de animación (_anim.deltaPosition.magnitude) para que el
        // Rigidbody se desplace igual
        _rb.MovePosition(transform.position + (_direction * _anim.deltaPosition.magnitude));

    }


    //Método para la rotación de Juanito. Lo llamo desde el FixedUpdate
    //Utilizo  el "MoveRotation()" que necesita de un Quaternion (x,y,z y w)
    //Utilizo Vector3.RotateTowards y le digo posición actual, posicion deseada,
    // velocdad y magnitud del vector (0.0f)
    private void Rotation()
    {

        //Variable local tipo Vector 3 con los datos de rotación a dónde quiero ir 
        Vector3 desiredForwards = Vector3.RotateTowards (transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);
        //Variable local tipo Quaternion
        Quaternion rotation = Quaternion.LookRotation(desiredForwards); 
        _rb.MoveRotation (rotation);

    }


}
