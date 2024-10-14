using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//EJERCICIO: introducir un número y mostrar la suma de los números del 1 al número introducido.
//variable de tipo "int", global y pública para poder introducir
//seleccionar los números del 1 hasta mi número (bucle);
//sumarlos; necesito una variable local


public class Addition : MonoBehaviour
{
    //Zona variables globales
    public int MyNumber; 

    // Start is called before the first frame update
    void Start()
    {
        //llamo al método
        GetAdittionFrom1ToMyNumber();
    }

    //Creo el método
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
