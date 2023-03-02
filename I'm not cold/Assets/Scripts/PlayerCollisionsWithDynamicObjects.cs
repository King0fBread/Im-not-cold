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
        if (collision.gameObject.GetComponent<MetallicObject>())
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerTouchedMetal);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerTouchedMetal);
        }
        if (collision.gameObject.GetComponent<WoodenPlanksObject>())
        {
            SoundsManager.instance.StopSound(SoundsManager.Sounds.PlayerTouchedPlanks);
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.PlayerTouchedPlanks);
        }
    }
}
