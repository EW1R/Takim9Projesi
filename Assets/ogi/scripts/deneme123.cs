using UnityEngine;

public class Fireball : MonoBehaviour
{
    private bool isFalling = true; // Alev topu d���yor mu?

    void Update()
    {
        if (isFalling && transform.position.y <= 0f)
        {
            // Alev topu yere d��t�, burada kaybolabilir veya ba�ka bir i�lem yapabilirsiniz.
            Destroy(gameObject); // Alev topunu yok et
        }
    }

    // Alev topu bir �eye �arpt���nda �al��acak kod
    void OnTriggerEnter(Collider other)
    {
        if (isFalling)
        {
            if (other.tag == "Dusman")
            {
                // D��man� vurdu�unuzu i�aretlemek veya zarar vermek i�in burada kod ekleyebilirsiniz.
                Debug.Log("D��man vuruldu!");

                // D��man� yok etmek veya zarar vermek i�in burada kod ekleyebilirsiniz.
            }

            // Alev topunu yok etmek i�in kod
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Animator bile�enini al
        Animator animator = GetComponent<Animator>();

        // Alev topu yere d��t���nde "YereD��t�" tetikleyicisini etkinle�tir
        animator.SetTrigger("YereD��t�");

        // Alev topunu yok et
        Destroy(gameObject);
    }

}
