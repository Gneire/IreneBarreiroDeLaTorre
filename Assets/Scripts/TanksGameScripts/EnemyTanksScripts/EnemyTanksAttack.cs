using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyTanksAttack : MonoBehaviour
{
    //Zona de variables globales
    
    [Header("Time")]
    [SerializeField]
    private float _timer; //para hacer el contador
    [SerializeField]
    private float _timeBetweenAttacks; //para tiempo entre disparos

    private bool _isAttack;//global para poder usarla en el "Update()" y en el "FixedUpdate()"

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody _shellEnemyPrefab; //para instanciar directamente el "Rigidbody"
    [SerializeField]
    private Transform _posShell; //para la posición desde dónde salen las balas
    [SerializeField]
    private float _launchForce; //para la fuerza de la bala
    //factor para controlar la fuerza de lanzamiento según la distancia del "player"
    [SerializeField]
    private float _factorLaunchForce; 

    //variables para detectar al player desde un "Raycast"
    [Header("RayCast")]
    private Ray _ray;
    private RaycastHit _hit;
    private float _distance;

    
    private void Awake()
    {
        //para asegurarme que esta variable booleana se inicializa como falsa
        _isAttack = false;
    }

    private void FixedUpdate()
    {
        if (_isAttack) // si es verdadera, osea está atacando
        {
            //llamo al método del lanzamiento
            Launch();
            //y vuelvo a hacer que sea falsa
            _isAttack=false;
        }
    }

    void Update ()
    {
        //Llamo al método del contador
        CountTimer(); 
    }

    //creo el método para el contador y lo llamo desde el "Update()"
    private void CountTimer()
    {
        _ray.origin = transform.position; //origen del rayo 
        _ray.direction = transform.forward; //hacia dónde se dirige

        //Al tiempo (_timer) que tengo ahora (que es 0), le sumo el tiempo del ordenador
        _timer+=Time.deltaTime; //lo mismo que --> _timer = _timer + Time.deltaTime

        if (Physics.Raycast (_ray, out _hit)) //si al lanzar el rayo lo detecta
        {
            //si el collider coincide con la etiqueta y el tiempo del contador es 
            //= o > que el tiempo que decido que haya entre disparos 
            if (_hit.collider.CompareTag ( "PlayerTank") && _timer >= _timeBetweenAttacks)
            {
                //entonces _timer vuelve a valer cero para volver a empezar
                _timer = 0.0f;
                _isAttack = true; //y convierto el boleano en verdadero
                _distance =_hit.distance; //saca la distancia desde el "player" al enemigo
            }

        } 
      
    }

    //Creo el método para instanciar directamente el Rigidbody y no tener que
    //obtener el componente  en el "Awake()"
    private void Launch() 
    {
        //creo la variable de la fuerza final
        float launchForceFinal = _launchForce * _distance * _factorLaunchForce;
        //añado la variable para instanciar el clon
        Rigidbody cloneShellPrefab = Instantiate(_shellEnemyPrefab, _posShell.position, _posShell.rotation);
        //y usar su velocidad para decir hacia donde y con que fuerza lanzar
        cloneShellPrefab.velocity = _posShell.forward * launchForceFinal;
    }

}
