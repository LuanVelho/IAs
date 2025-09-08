using UnityEngine;
using UnityEngine.SceneManagement;

public class numeroDeInimigos : MonoBehaviour
{
    void Update()
    {
        int inimigosRestantes = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (inimigosRestantes == 0)
        {
            SceneManager.LoadScene("You won"); // Troque pelo nome da próxima fase
        }
    }
}