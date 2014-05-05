using UnityEngine;
using System.Collections;

/// <summary>
/// 全てのギミックが継承する基底クラス
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public abstract class BaseGimmicBehaviour : MonoBehaviour
{
    /// <summary>
    /// プレイヤーが近く（拾える範囲）にいる
    /// </summary>
    public bool IsPlayerNear { get { return Player.handInstance.NearestGimmic == null ? false : Player.handInstance.NearestGimmic.GetInstanceID() == this.gameObject.GetInstanceID(); } }
    /// <summary>
    /// ギミックがプレイヤーに手にされているかどうか
    /// </summary>
    public bool IsGripped { get { return Player.grippingGameObject == this.gameObject; } }

    /// <summary>
    /// 手に拾われた時に呼び出されるメソッド。overrideして使う
    /// </summary>
    public virtual void PickUp()
    {
        // 手に追従, 手と同じ位置に移動(相対位置をゼロに)
        transform.parent = Player.handGameObject.transform;
        transform.localPosition = Vector3.zero;

        // 重力をなくす
        rigidbody.useGravity = false;
    }

    /// <summary>
    /// 手放された時に呼び出されるメソッド。overrideして使う
    /// </summary>
    public virtual void PutDown()
    {

        // 追従関係をリセット
        transform.parent = null;

        // ちょっと投げ捨てる
        rigidbody.AddForce((Player.rootGameObject.transform.forward + Player.rootGameObject.transform.up) * 5f, ForceMode.VelocityChange);
        rigidbody.useGravity = true;
    }
}
