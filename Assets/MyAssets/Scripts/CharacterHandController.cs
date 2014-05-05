using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// キャラクターの手としてふるまう、アクションキーの行動を実装するクラス
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public class CharacterHandController : MonoBehaviour {

    /// <summary>
    /// 手の届く範囲内にある全てのギミックオブジェクト
    /// </summary>
    public List<GameObject> NearGimmicsAll { get; private set; }
    
    /// <summary>
    /// 最も手から近いギミックオブジェクト
    /// </summary>
    public GameObject NearestGimmic { get { return NearGimmicsAll.Count() < 1 ? null : NearGimmicsAll.OrderBy<GameObject, float>(gmObj => Vector3.Distance(gmObj.transform.position, transform.position)).First(); } }

    /// <summary>
    /// 手に握っているギミックオブジェクト
    /// </summary>
    public GameObject GripGimmic { get; private set; }

    public bool IsHandFree { get { return GripGimmic == null; } }

	// Use this for initialization
	void Start () {
        NearGimmicsAll = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        // PickUpを押され、何も持っておらず、近くにギミックがある時、その物を手にする
        if (Input.GetButtonDown("PickUp") && IsHandFree && NearestGimmic != null)
        {

            // ギミックを手にする
            GripGimmic = NearestGimmic;
            GripGimmic.SendMessage("PickUp"); // PickUpメソッドを呼び出す
        }
        // PutDownを押され、ギミックを手にしているとき、その物を手放す
        if (Input.GetButtonDown("PutDown") && !IsHandFree)
        {

            // ギミックを手放す
            GripGimmic.SendMessage("PutDown"); // PutDownメソッドを呼び出す
            GripGimmic = null;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gimmic")
        {
            // List<T>.Exists()メソッドを使用し、範囲内に入ったトリガーが、まだNearGimmicsAllに追加されていない場合...
            if (!NearGimmicsAll.Exists(gmObj => gmObj == other.gameObject))
            {

                // NearGimmicAllに追加
                NearGimmicsAll.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gimmic")
        {
            // List<T>.Exists()メソッドを使用し、範囲内に入ったトリガーが、すでにNearGimmicsAllに追加されている場合...
            if (NearGimmicsAll.Exists(gmObj => gmObj == other.gameObject))
            {

                // NearGimmicsAllから削除
                NearGimmicsAll.Remove(other.gameObject);
            }
        }
    }
}
