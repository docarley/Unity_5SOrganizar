using UnityEngine;

public class ControladorObjetos : MonoBehaviour
{
    public ControladorFase geral;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Player") &&
            geral.imagemObjetoSelecionado.sprite == null)
        {
            geral.PegarObjeto(gameObject);
        }
    }

}
