using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger3D : MonoBehaviour
{
    public bool backpressed;
    [SerializeField] public Vector3 lastpos;

    private void Start()
    {
        backpressed = false;
    }


    public void PreviousSceneLoad()
    {
        SceneManager.LoadScene("Chairwebgl");
        backpressed = true;
    }
}
