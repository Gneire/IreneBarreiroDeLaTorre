using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //zona de variables globales

    //El sistema de particulas va a ser una explosi�n que esta vez
    //voy a reproducir y parar (en vez de instanciar y destruir)
    [SerializeField]
    private ParticleSystem _explosionShell;
    private AudioSource _audioSource;
    // Creo las variables que necesito para hacer que la bala
    // no rebote despu�s de impactar (para 
    private Collider _coll; 
    private Renderer _rend; 


   
    private void Awake()
    {
        //Consigo el componente "AudioSource" desde el "Awake()"
        _audioSource = GetComponent<AudioSource>();
        //Consigo los componentes del "Collider" y "Rendered" desde el "Awake()"
        _coll = GetComponent<Collider>();
        _rend = GetComponent<Renderer>();
    }

    //Utilizo el "OnCollision()" para programar lo que pasa al chocar la bala
    private void OnCollisionEnter(Collision infoCollision) //cuando impacta
    {
        _coll.enabled = false; // desactiva el collider y ya no puede chocar m�s
        _rend.enabled = false; //desactiva la malla de visualizaci�n de la bala
        _explosionShell.Play(); //la explosi�n se reproduce
        _audioSource.Play(); // suena el audio de la explosi�n
        Destroy(gameObject, 0.5f); // tras medio segundo se destruye la bala
    }

   
}
