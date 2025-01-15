using UnityEngine;
using UnityEngine.SceneManagement;

public class Fundido : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string nextScene;
    private SpriteRenderer sprite;
    private Animator anim;
    public bool activar=true;
    private GameObject gObject;
    [SerializeField] private string postAccidente;
    void Start()
    {
        gObject = gameObject.GetComponent<GameObject>();
        anim = GetComponentInParent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //UIManager.instance.hideObjects();
        GameManager.GetInstance().setState(GameManager.GameStates.Manual);
    }

    // Update is called once per frame
    void Update()
    {
        if (activar)
        {


            if (DialogManager.Instance.fin())
            {
                GameManager.GetInstance().setState(GameManager.GameStates.Manual);
                anim.SetBool("Trans", true);
                activar = false;

            }
        }

    }
    public void active()
    {
        activar = true;
    }
    public void setInactive()
    {

        SceneManager.LoadScene(nextScene);

    }
}
