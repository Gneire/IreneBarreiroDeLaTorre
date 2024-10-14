using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EJERCICIO: Introduce número del 1 al 12 y di nombre del mes correspondiente
//variable número entero, pública y global para poder introducir.
//condicional muchas opciones --> Switch

public class Month : MonoBehaviour
{

    // Zona de variables globales
    public int MonthNumber;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Llamo al Método
        IsMonth();
    }

    // Creo el método
    private void IsMonth() 
    {

        switch (MonthNumber) 
        {
            case 1:
                Debug.Log (MonthNumber + " corresponde al mes de enero");
                break;

            case 2:
                Debug.Log (MonthNumber + " corresponde al mes de febrero");
                break;

            case 3:
                Debug.Log (MonthNumber + " corresponde al mes de marzo");
                break;

            case 4:
                Debug.Log (MonthNumber + " corresponde al mes de abril");
                break;

            case 5:
                Debug.Log (MonthNumber + " corresponde al mes de mayo");
                break;

            case 6:
                Debug.Log (MonthNumber + " corresponde al mes de junio");
                break;

            case 7:
                Debug.Log (MonthNumber + " corresponde al mes de julio");
                break;

            case 8:
                Debug.Log (MonthNumber + " corresponde al mes de agosto");
                break;

            case 9:
                Debug.Log (MonthNumber + " corresponde al mes de septiembre");
                break;

            case 10:
                Debug.Log (MonthNumber + " corresponde al mes de octubre");
                break;

            case 11:
                Debug.Log (MonthNumber + " corresponde al mes de noviembre");
                break;

            case 12:
                Debug.Log (MonthNumber + " corresponde al mes dediciembre");
                break;

            default:
                Debug.Log (MonthNumber + " no corresponde a ningún mes");
                break; 

        }

    }

   
}
