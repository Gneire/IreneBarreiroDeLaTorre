using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerAttack : MonoBehaviour
{
    //Zona de variables globales
   
    //para instanciar directamente el Rigidbody de la bala y no tener que
    //conseguir este componente en el "Awake()" 
    [SerializeField]
    private Rigidbody _shellPrefab; // en vez de la variable tipo "GameObject"
    [SerializeField]
    private Transform _posShell; //para la posición desde la que instancio la bala
    [SerializeField]
    private float _launchForce; // para la fuerza con la que sale la bala

    //para hacer referencia al componente  "AudioSource" que colocamos en el "PosShell"
    [SerializeField]
    private AudioSource _audioSourceShell; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        InputPlayer();
    }

    //creo método para hacer que dispare desde el botón del ratón
    // y lo llamo desde el "Update()"
    private void InputPlayer() 
    {
        //si presiono botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            //llamo al método que hará que se disparen ( que se instancien) las balas
            Launch();
        }
    }

    private void Launch()
    {
        //instanciamos el "Rigidbody" de la bala
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);
        //suena el disparo
        _audioSourceShell.Play();
        //uso su velocidad para indicarle que salga hacia delante y con esta fuerza
        cloneShellPrefab.velocity = _posShell.forward * _launchForce;
    }
}
