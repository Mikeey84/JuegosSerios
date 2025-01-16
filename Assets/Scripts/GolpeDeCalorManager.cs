
using UnityEngine;

public class GolpeDeCalorManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _señor;
    // Start is called before the first frame update
    void Start()
    {
        _player.GetComponent<Lifeguard>().Grabbing(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = _player.transform.position;
        newPos.x += 1;
        _señor.transform.position = newPos;
    }
}
