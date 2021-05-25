using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : EntityLife {

    protected override void Dye()
    {
        Destroy(gameObject);
    }
}
