using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger3D : MonoBehaviour
{
    public bool backpressed;
    [SerializeField] public Vector3 lastpos;
    [SerializeField] public GameObject[] ViewModels;
    [SerializeField] public CameraOrbit Cam;

    private void Start()
    {
        backpressed = false;
        CheckNum();
    }

    public void CheckNum()
    {
        for (int i = 0; i < ViewModels.Length; i++)
        {
            ViewModels[i].SetActive(false);
        }
        ViewModels[GameManagerAuction.Instance.RefNum].SetActive(true);
        Cam.target = ViewModels[GameManagerAuction.Instance.RefNum].transform;
    }


    public void PreviousSceneLoad()
    {
        SceneManager.LoadScene("Chairwebgl");
        backpressed = true;
    }
}
