using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionsWithDynamicObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<WoodenObject>())
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerTouchedWood);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerTouchedWood);
        }
        else if (collision.gameObject.GetComponent<MetallicObject>())
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerTouchedMetal);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerTouchedMetal);
        }
    }
}
