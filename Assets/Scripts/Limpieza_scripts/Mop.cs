using UnityEngine;

public class Mop : ClickableAndMoveableObject
{
    [SerializeField]
    private string[] cleanableDirtTypes; // Tipos de suciedad que esta mopa puede limpiar


    // Verifica si puede limpiar el tipo de suciedad
    public bool CanClean(string dirtType)
    {
        foreach (string type in cleanableDirtTypes)
        {
            if (type == dirtType)
            {
                return true;
            }
        }
        return false;
    }

    // Sobrescribe el método OnClick para reproducir el sonido
    protected override void OnClick()
    {
        base.OnClick();

       
    }

    protected override void OnClickUp()
    {
        base.OnClickUp();

        
    }
}