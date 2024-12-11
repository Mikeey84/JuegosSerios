using UnityEngine;

public class Dirt : MonoBehaviour
{
    private string dirtType;

    public void SetDirtType(string type)
    {
        dirtType = type;
    }

    public string GetDirtType()
    {
        return dirtType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si colisiona con una mopa
        Mop mop = collision.GetComponent<Mop>();
        if (mop != null)
        {
            if (mop.CanClean(dirtType))
            {
                // Limpia este objeto
                Destroy(gameObject);
            }
        }
    }
}
