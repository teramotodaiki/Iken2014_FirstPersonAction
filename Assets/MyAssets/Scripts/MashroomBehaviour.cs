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

    //public override void PickUp()
    //{
    //    // キノコが足元にある時に拾うと飛んでしまうため
    //    Player.characterMoter.SetVelocity(Vector3.zero);

    //    // 手に追従, 手と同じ位置に移動(相対位置をゼロに)
    //    transform.parent = Player.handGameObject.transform;
    //    transform.localPosition = Vector3.zero;

    //    // 重力をなくす
    //    rigidbody.useGravity = false;


    //    //手から離す時に物の速度を0にする
    //    transform.rigidbody.velocity = Vector3.zero;
    //}


}
