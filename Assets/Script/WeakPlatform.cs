using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
             StartCoroutine(Vanishing());
    }
    IEnumerator Vanishing()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(UnVanish());
        this.gameObject.SetActive(false);
        
        
    }
    IEnumerator UnVanish()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(true);

    }
}
