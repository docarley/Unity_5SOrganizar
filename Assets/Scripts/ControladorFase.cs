using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorFase : MonoBehaviour
{
    public Image imagemObjetoSelecionado;
    internal int ObjetosRestantes;
    internal float TempoRestante;

    public Text textoObjRestantes, textoTempoRestante;
    public Transform listaObjetos;
    public GameObject telaGanhou, telaPerdeu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Contar quantos objetos tem subordinados a "Coletaveis":
        ObjetosRestantes = listaObjetos.childCount;
        textoObjRestantes.text = "Itens a Coletar: " + ObjetosRestantes;

        TempoRestante = 30;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Código para diminuir o tempo restante:
        TempoRestante -= Time.deltaTime;
        textoTempoRestante.text = "Tempo restante: " + TempoRestante.ToString("00");   
        
        if (TempoRestante <= 0)
        {
            telaPerdeu.SetActive(true);
            Time.timeScale = 0;
            TempoRestante = 0;
        }
    }


    public void PegarObjeto(GameObject obj)
    {
        ObjetosRestantes -= 1;
        textoObjRestantes.text = "Itens a Coletar: " + ObjetosRestantes;

        imagemObjetoSelecionado.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        imagemObjetoSelecionado.preserveAspect = true;

        Destroy(obj);
    }

    public void PosicionarObjeto(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
        imagemObjetoSelecionado.sprite = null;

        if (ObjetosRestantes == 0)
        {
            telaGanhou.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PausarTempo()
    {
        if (Time.timeScale > 0)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
