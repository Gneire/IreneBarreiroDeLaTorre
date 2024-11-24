using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    //Necesito crear dos variables flotantes tipo "horizontal" y "vertical"
    //Necesito determinar a qué velocidad ("_speed")
    //Necesito determinar grados que gira ("_turnSpeed")



    //Zona de variables globales

    //Para programar las animaciones 
    private Animator _anim;
   


    //Para los desplazamientos
    private float _horizontalMove,
                  _verticalMove,
                  _speed = 0.8f,
                  _turnSpeed = 90.0f;

    //Creo las variables "Raycast" que necesito para el salto
    [Header ("Raycast")]
    private Ray _ray;
    //Para saber con qué estoy golpeando
    private RaycastHit _hit;
    //para saber si estoy en el suelo
    //es decir, si puedo saltar
    private bool _isGrounded;
    //para saber si puedo saltar
    private bool _canPlayerJump;
    //para coger el componente "Rigidbody"
    private Rigidbody _rb;
    
    //la capa dónde quiero que actue el "Raycast"
    //fuera le indicaré que es la del "Ground"
    public LayerMask GroundMask;

    //La longitud del "Raycast"; le doy el valor fuera.
    public float RayLength;

    //para añadirle la fuerza al salto desde fuera
    public float JumpForce;
    



    private void Awake()
    {
        //para obtener los componentes de la animación
        _anim = GetComponent<Animator>();
        

        //para obtener el componente del Rigidbody
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AnimatingAttack();
        }
        InputPlayer();
        Move();
        Turn();
        CanJump();
        AnimatingWalk();

    }
  
    //Creo métodos de una sola funcionalidad y los llamo en "Update"
    //para que "eschuche" todo el tiempo
    private void InputPlayer()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _verticalMove * _speed * Time.deltaTime);
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up * _horizontalMove, _turnSpeed * Time.deltaTime);
    }

    private void AnimatingWalk ()
    {
        //si el "player" se está moviendo
        if (_verticalMove !=0)
        {
            _anim.SetBool("isMoving", true);
        }
        //Si la vertical es cero, está parado
        else
        {
            _anim.SetBool("isMoving", false);
        }
    }

    private void AnimatingAttack()
    {
        Debug.Log("estoy atacando");
        _anim.SetTrigger("isAttacking");

    }

    //Creo el método que gestiona todas las "Physics", el "FixedUpdate"
    //llamo aquí a los métodos y los creo fuera
    private void FixedUpdate()
    {
        LaunchRaycast();
        if (_canPlayerJump==true)
        {
            //para que no siga saltando
            _canPlayerJump = false;
            //llama al método
            Jump (); 
        }
    }

    private void LaunchRaycast()
    {
        //el punto de pivote
        _ray.origin = transform.position;
        //hacia abajo; por eso es negativo
        _ray.direction = - transform.up;

        if (Physics.Raycast (_ray, out _hit, RayLength))
        {
            //puedo saltar
            _isGrounded = true;
            
        }
        else 
        {
            _isGrounded = false;
        }
    }


    //para ver si puedo saltar
    private void CanJump()
    {
        //si quiero y puedo saltar, uso la tecla espaciadora y es verdadero
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded ==true)
        {
            _canPlayerJump = true;
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * JumpForce);
    }

}
