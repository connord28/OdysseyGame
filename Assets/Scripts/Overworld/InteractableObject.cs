using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public void setSprite(Sprite tar)
    {
        GetComponent<SpriteRenderer>().sprite = tar;
    }

    public virtual void startInteraction() { }

    public virtual void endInteraction() { }
}
