using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool isCarryingPackage;
    SpriteRenderer _spriteRenderer;
    [SerializeField] Color32 defaultColor = new Color32(255,2,0,255);
    [SerializeField] Color32 packagedColor = new Color32(0, 255, 255, 255);

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collapsed!");        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !isCarryingPackage)
        {
            Debug.Log("You picked up the package!");
            //collision.gameObject.SetActive(false); //if i know i will use it, i must use this command
            Destroy(collision.gameObject, 0.5f); //otherwise, this command
            _spriteRenderer.color = packagedColor;
            isCarryingPackage= true;

        }

        if(collision.tag == "Customer" && isCarryingPackage)
        {
            Debug.Log("Package delivered!");
            isCarryingPackage= false;
            _spriteRenderer.color = defaultColor;
        }
    }
}
