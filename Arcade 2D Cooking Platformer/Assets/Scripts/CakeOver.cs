using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeOver : MonoBehaviour
{
    public static CakeOver instance; //A static reference of the class

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject CakeGameObject;

    private void Awake()
    {
        if (instance == null)
        {
            //Set an instance of it
            instance = this;
        }

        animator = GetComponent<Animator>();
    }

    public void GameCompleted()
    {
        animator.SetTrigger("openOven");
        CakeGameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.SetAtCakeOver(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.SetAtCakeOver(false);
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

}
