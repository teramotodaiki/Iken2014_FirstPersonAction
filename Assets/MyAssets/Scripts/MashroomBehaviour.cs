using UnityEngine;
using System.Collections;

/// <summary>
/// マッシュルームのふるまいを定義するクラス
/// </summary>
public class MashroomBehaviour : BaseGimmicBehaviour {

    void Start()
    {

    }

    void Update()
    {
        if (IsGripped)
        {
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }
    }


}
