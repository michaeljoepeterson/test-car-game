using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool HasPackage = false;
    [SerializeField] float PackageDelay = 0;
    [SerializeField] Color32 HasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 NoPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer SpriteRender;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision occured");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PickupPackage(collision);
    }

    void RemovePackage(GameObject obj)
    {
        Destroy(obj, PackageDelay);
    }

    void UpdatePlayerColor(Color32 color)
    {
        SpriteRender.color = color;
    }

    void PickupPackage(Collider2D collision)
    {
        if (collision.gameObject.tag == "package" && !HasPackage)
        {
            Debug.Log("Packaged picked up");
            RemovePackage(collision.gameObject);
            HasPackage = true;
            UpdatePlayerColor(HasPackageColor);
        }
        if (collision.gameObject.tag == "customer" && HasPackage)
        {
            Debug.Log("Packaged delivered");
            HasPackage = false;
            UpdatePlayerColor(NoPackageColor);
        }
    }
}
