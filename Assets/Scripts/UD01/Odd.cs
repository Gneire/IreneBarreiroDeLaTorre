using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//EJERCICIO: muestra los n�meros impares entre el y al 100.
//Necesito un bucle que recorra n�meros del 0 al 100 + un if que me selecciones los impares.
//(Par --> % 2 == 0) --> (impar % 2 != 0)

public class Odd : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //llamo al m�todo
        GetOddNumbersFrom0To100();
    }

    // creo el m�todo
    private void GetOddNumbersFrom0To100()
    {
        //Variable local "i" Declaro,inicializo variable de incremento y contador; todo ya dentro del "for"
        //A�ado el condicional para que me muestre s�lo los impares

        for (int i = 0; i < 101; i++)
        {
            if (i % 2 != 0)
            {
                Debug.Log(i);
            }
        }
    }
}
