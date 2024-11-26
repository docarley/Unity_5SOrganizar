using UnityEngine;

public class ComportamentoPersonagem : MonoBehaviour
{
    public float velocidadePersonagem, forcaDoPulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Este código é para fazer o personagem ir para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 novaPos = new Vector3(velocidadePersonagem * Time.deltaTime, 0 , 0);
            transform.position += novaPos;

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Este código é para fazer o personagem ir para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 novaPos = new Vector3(velocidadePersonagem * Time.deltaTime, 0, 0);
            transform.position -= novaPos;

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Este código é para fazer o personagem pular
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 sentidoCima = new Vector2(0, 1);
            gameObject.GetComponent<Rigidbody2D>().AddForce(sentidoCima * forcaDoPulo);
        }

    }
}
