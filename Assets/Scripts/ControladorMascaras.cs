using UnityEngine;

public class ControladorMascaras : MonoBehaviour
{
    public ControladorFase geral;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Player") && 
            geral.imagemObjetoSelecionado.sprite == gameObject.GetComponent<SpriteRenderer>().sprite)
        {
            geral.PosicionarObjeto(gameObject);
        }
    }
}
