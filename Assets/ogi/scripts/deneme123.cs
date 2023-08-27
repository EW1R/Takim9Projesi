using UnityEngine;

public class Fireball : MonoBehaviour
{
    private bool isFalling = true; // Alev topu düþüyor mu?

    void Update()
    {
        if (isFalling && transform.position.y <= 0f)
        {
            // Alev topu yere düþtü, burada kaybolabilir veya baþka bir iþlem yapabilirsiniz.
            Destroy(gameObject); // Alev topunu yok et
        }
    }

    // Alev topu bir þeye çarptýðýnda çalýþacak kod
    void OnTriggerEnter(Collider other)
    {
        if (isFalling)
        {
            if (other.tag == "Dusman")
            {
                // Düþmaný vurduðunuzu iþaretlemek veya zarar vermek için burada kod ekleyebilirsiniz.
                Debug.Log("Düþman vuruldu!");

                // Düþmaný yok etmek veya zarar vermek için burada kod ekleyebilirsiniz.
            }

            // Alev topunu yok etmek için kod
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Animator bileþenini al
        Animator animator = GetComponent<Animator>();

        // Alev topu yere düþtüðünde "YereDüþtü" tetikleyicisini etkinleþtir
        animator.SetTrigger("YereDüþtü");

        // Alev topunu yok et
        Destroy(gameObject);
    }

}
