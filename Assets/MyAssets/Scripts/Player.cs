using UnityEngine;
using System.Collections;


/// <summary>
/// プレイヤーが操作するキャラクターだけが唯一もつクラス
/// </summary>
[AddComponentMenu("Character/Player")]
public class Player : MonoBehaviour {

    /// <summary>
    /// プレイヤーのroot階層にあるGameObject
    /// </summary>
    public static GameObject rootGameObject { get; private set; }
    
    /// <summary>
    /// プレイヤーのroot階層にあるGameObjectのインスタンス
    /// </summary>
    public static Player rootInstance { get; private set; }

    /// <summary>
    /// プレイヤーの手としてふるまうGameObject
    /// </summary>
    public static GameObject handGameObject { get; private set; }
    
    /// <summary>
    /// プレイヤーの手としてふるまうGameObjectのインスタンス
    /// </summary>
    public static CharacterHandController handInstance { get; private set; }

    /// <summary>
    /// プレイヤーが手に持っているギミックのGameObject
    /// </summary>
    public static GameObject grippingGameObject { get { return handInstance.GripGimmic; } }

    /// <summary>
    /// プレイヤーのキャラクターモーター
    /// </summary>
    public static CharacterMotor characterMoter { get { return rootInstance.GetComponent<CharacterMotor>(); } }

    void Awake()
    {
        // このコンポーネントがプレイヤーのroot階層にアタッチされているかどうかをチェック
        if (gameObject.tag != "Player")
            throw new UnityException("Playerがroot階層のオブジェクトでないオブジェクトにあるか、またはPlayerタグが設定されていません！");

        // 静的プロパティのセット
        Player.rootInstance = this;
        Player.rootGameObject = this.gameObject;
        Player.handInstance = transform.GetComponentInChildren<CharacterHandController>();
        Player.handGameObject = Player.handInstance.gameObject;

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
