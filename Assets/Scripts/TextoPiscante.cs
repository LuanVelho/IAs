using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextoPiscante : MonoBehaviour
{
    public TextMeshProUGUI texto; // Arraste o componente Text aqui no Inspector
    public float intervalo = 0.5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= intervalo)
        {
            texto.enabled = !texto.enabled;
            timer = 0f;
        }
    }
}