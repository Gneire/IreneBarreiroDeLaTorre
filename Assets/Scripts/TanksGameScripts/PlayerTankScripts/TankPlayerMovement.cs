using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerMovement : MonoBehaviour
{
    //Zona de variables globales
    //Variables para el movimiento
    [Header("Movement")]
    [SerializeField]
    private float _speed; //para la velocidad lineal
    [SerializeField]
    private float _turnSpeed; //para la velocidad cuando gira
    private float _horizontal, //para relacionar los ejes y las teclas
                  _vertical;
    private Rigidbody _rb; //para obtener el "Rigidbody"

    //Variables para arrastrar los audios
    [Header("Audio")]
    [SerializeField]
    private AudioClip _idleAudio; //sonido cuando est� parado
    [SerializeField]
    private AudioClip _drivingAudio; //sonido cuando est� en marcha

    //para llegar al componente "AudioSource" y poder intercambiar los clips
    private AudioSource _audioSource; 


    
    private void Awake()
    {
        //Consigo el componente "Rigidbody" ya en el "Awake()"
        _rb = GetComponent<Rigidbody>();
        //Consigo el componente del "AudioSource" 
        _audioSource = GetComponent<AudioSource>();

    }


    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    
    void Update()
    {
        InputsPlayer();
        AudioTank();
    }

    //creo el m�todo para la entrada de las teclas y lo llamo desde el "Update()"
    private void InputsPlayer()
    {
        _horizontal = Input.GetAxis ("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    // creo el m�todo para gestionar los clips de audios y lo llamo desde el "Update()"
    private void AudioTank()
    {
        //compruebo si se est� moviendo o girando
        if (_vertical !=0.0f || _horizontal != 0.0f)
        {
            //y que adem�s no se est� reproduciendo ya, el clip de en marcha
            if (_audioSource.clip != _drivingAudio)
            {
                //entonces le digo que suene
                _audioSource.clip = _drivingAudio;
                _audioSource.Play();
            }

        }
        else //si est� parado
        {
            // y no se est� reproduciendo ya, el clip de parado
            if (_audioSource.clip != _idleAudio)
            {
                //entonces que suene
                _audioSource.clip = _idleAudio; 
                _audioSource.Play();    
            }
        }
    }


    //creo el m�todo para el movimiento, que llamo desde el "FixedUpdate()"
    //porque lo voy a mover a trav�s del "Rigidbody", osea por f�sicas
    // y usando el "MovePosition()" para que vaya suave.
    //Para ello activ� "Is Kinematic" en el "Rigidbody" del tanque.
    private void Move()
    {
        //creo un "Vector3" hacia delante ("direction") que vaya sumando
        //la posici�n de la "transform"para avanzar
        Vector3 direction = transform.forward *_vertical *_speed * Time.deltaTime;
        _rb.MovePosition(transform.position + direction);
    }

    //creo otro m�todo para el giro, ya que este necesita de un "Quaternion"
    // Uso "MoveRotation()" y tambi�n lo llamo desde el "FixedUpdate()"
    private void Turn() 
    { 
        //primero calculo los grados del giro
        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        //Uso el "Quaternion Euler" que me permite meter solo tres valores x,y,z;
        Quaternion turnRotation = Quaternion.Euler (0.0f,_horizontal,0.0f);
        //multiplico por el "Quaternion" para avanzar (girar)
        _rb.MoveRotation(transform.rotation * turnRotation);
    
    }
}
 