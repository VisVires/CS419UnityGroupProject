using UnityEngine;
using System.Collections;

public class endDestroy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject currentMonster;
        if (col.gameObject.name == "Golem" || col.gameObject.name == "Ninja" || col.gameObject.name == "Zombie")
        {
            Debug.Log("Enter");
            currentMonster = col.gameObject;  
        }
    }
}
