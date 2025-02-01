using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añado librería para usar las "Images"
using UnityEngine.UI;
//Añado librería para recargar el nivel
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{

    //Zona de variables globales

    [Header("Images")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;

    [Header("Buttons")]
    [SerializeField]
    //private GameObject _buttonStart;
    private GameObject _panelStart;
    
    [Header("Fade")]
    //Para la duración del "fade"
    [SerializeField]
    private float _fadeDuration;
    //El tiempo total que la imagen estará en la pantalla
    [SerializeField]
    private float _displayImageDuration;
    //Contador del tiempo para el "fade"
    private float _timer;

    //Para saber si el "player" ha llegado a la salida, si ha
    //sido pillado o si tengo que resetear el nivel.
    public bool IsPlayerAtExit,
                IsPlayerCaught;
      //          IsRestartLevel

    //Variables de audio para los sonidos;cuando nos pillan y cuando ganamos
    [Header("Audio")]
    //Sonido cuando nos pillan
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    [SerializeField]
    private AudioSource _audioSource;

    //Obtenemos el componente del "Audio Source" en el "Awake()".
    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
        
       

    }

    void Update()
    {
        if (IsPlayerAtExit)
        {

            Won();

        }
        else if (IsPlayerCaught) 
        {
            Caught();

        }

    }

    //Creo método para gestionar el audio cuando gano y lo llamaré en el "Update()"
    private void Won() 
    {
        //Hago que "_audioSource" coja el audio de "Won"
        _audioSource.clip = _wonClip;
        //si no se está reproduciendo
        if (_audioSource.isPlaying == false)
        {
            //entonces que se reproduzca
            _audioSource.Play();

        }

        //Contador para el "fade"
        _timer = _timer + Time.deltaTime;
        //Aumentamos poco a poco el canal alpha de la imagen
        _wonImage.color = new Color (_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer/_fadeDuration);

        //Para que la imagen se quede un tiempo en la pantalla
        if (_timer > _fadeDuration + _displayImageDuration) 
        {

            //Debug.Log("he ganado");
            _audioSource.Stop();
            ShowButtonStartAgain();
            

        }

    }

    private void ShowButtonStartAgain()
    {
        _panelStart.SetActive(true);
    }

    //Creo método para gestionar el audio cuando me pillan y lo llamaré en el "Update()".
    private void Caught()
    {
        //Hago que "_audioSource" coja el audio de "Caught"
        _audioSource.clip = _caughtClip;
        //si no se está reproduciendo
        if (_audioSource.isPlaying == false)
        {
            //entonces que se reproduzca
            _audioSource.Play();

        }

        //Contador para el "fade"
        _timer = _timer + Time.deltaTime;
        //Aumentamos poco a poco el canal alpha de la imagen
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer / _fadeDuration);

        //Para que la imagen se quede un tiempo en la pantalla
        if (_timer > _fadeDuration + _displayImageDuration)
        {
            //Debug.Log("he perdido");
            //Recargamos el nivel, colocada la escena previamente en
            //los "Build Settings" con el número 0
            SceneManager.LoadScene(0);

        }

    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("JohnLemon"))
        {

            //Debug.Log("Llegué a la salida.He ganado");
            IsPlayerAtExit = true;

        }
    }

    public void AfterFinishStartAgain()
    {
        Debug.Log("estoy pulsando el botón, debería cargarse la escena");
        SceneManager.LoadScene(0);
    }
        
}
