using UnityEngine;

public class Mop : ClickableAndMoveableObject
{
    [SerializeField]
    private string[] cleanableDirtTypes; // Tipos de suciedad que esta mopa puede limpiar
    [SerializeField]
    private AudioSource mopSource;
    [SerializeField]
    private AudioClip mopSound;

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

    // Sobrescribe el m�todo OnClick para reproducir el sonido
    protected override void OnClick()
    {
        base.OnClick();

        if (mopSource != null && mopSound != null)
        {
            mopSource.clip = mopSound;
            mopSource.Play();
        }
    }

    protected override void OnClickUp()
    {
        base.OnClickUp();

        // Det�n el sonido si est� reproduci�ndose
        if (mopSource != null && mopSource.isPlaying)
        {
            mopSource.Stop();
        }
    }
}