using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTanksHealth : MonoBehaviour
{
    //zona de variables globales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth; //para la salud máxima
    [SerializeField]
    private float _currentHealth; //para la salud actual
    [SerializeField]
    private float _damagePlayerShells; //para el daño que hacen las bolas enemigas

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _tankExplosion;
    [SerializeField]
    private ParticleSystem _shellExplosion;


    private void Awake()
    {
        _currentHealth = _maxHealth; //Máxima vida al principio
        _lifeBar.fillAmount = 1.0f; //va de 0 a 1 en la barra de la imagen en el Inspector
        //paro las explosiones al principio 
        _tankExplosion.Stop();
        _shellExplosion.Stop();


    }

    //hacemos un evento tipo "Trigger" para decirle que si la bala me toca,
    //tiene que restar a mis salud actual el daño de la bala enemiga y 
    //decirle cuando muero
    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("PlayerShell"))
        {
            _shellExplosion.Play(); //cuando nos da la bala 
            _currentHealth -= _damagePlayerShells;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);
            if (_currentHealth <= 0.0F) //si mi salud es menos o igual a cero 
            {
                _tankExplosion.Play(); //cuando morimos
                //mi tanque se destruye totalmente y que tarsde 1 segundo para verlo
                Destroy(gameObject, 1.0f);
            }


        }

    }

}
