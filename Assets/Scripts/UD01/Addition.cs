using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//EJERCICIO: introducir un n�mero y mostrar la suma de los n�meros del 1 al n�mero introducido.
//variable de tipo "int", global y p�blica para poder introducir
//seleccionar los n�meros del 1 hasta mi n�mero (bucle);
//sumarlos; necesito una variable local


public class Addition : MonoBehaviour
{
    //Zona variables globales
    public int MyNumber; 

    // Start is called before the first frame update
    void Start()
    {
        //llamo al m�todo
        GetAdittionFrom1ToMyNumber();
    }

    //Creo el m�todo
    private void GetAdittionFrom1ToMyNumber ()
    {
        //zona de variables locales 
        int addNumbers = 0; 
         
            

        //declaro, inicializo variable de incremento y pongo contador
        for (int i = 1; i <= MyNumber; i++)
        {
            addNumbers += i;
            Debug.Log(addNumbers);
        }
     
    } 
}
