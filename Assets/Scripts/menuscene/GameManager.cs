using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void StartGame()
    {
        Debug.Log("Start game");

        SceneManager.LoadScene("ArenaScene");
    }
}
