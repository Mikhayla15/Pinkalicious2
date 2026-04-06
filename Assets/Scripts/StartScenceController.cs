using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("startscene");
        }
    }
}
