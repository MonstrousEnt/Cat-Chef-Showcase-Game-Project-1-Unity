using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredinets : MonoBehaviour
{
    [SerializeField] int FoundInhrdedinets = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FoundInhrdedinets += 1;
        Debug.Log("found one!");

        //Set UI


        gameObject.SetActive(false);
    }
}
