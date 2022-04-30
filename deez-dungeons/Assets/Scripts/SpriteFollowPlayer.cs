using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollowPlayer : MonoBehaviour
{
    public Transform sprite;
    void Update()
    {
        sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
}
