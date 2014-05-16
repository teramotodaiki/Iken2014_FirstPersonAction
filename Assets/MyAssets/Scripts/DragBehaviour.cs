using UnityEngine;
using System.Collections;

/// <summary>
/// モノを引き摺る
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class DragBehaviour : BaseGimmicBehaviour {

    public CharacterMotor.CharacterMotorMovement DraggingMovement;
    private CharacterMotor.CharacterMotorMovement defaultMovement;


    public Vector3 DraggingHandPosition;
    private Vector3 defaultHandPosition;

    private SpringJoint springJoint;

	// Use this for initialization
	void Start () {
        springJoint = GetComponent<SpringJoint>(); // SpringJointを取得
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public override void PickUp()
    {

        // 足を遅くする
        defaultMovement = Player.characterMoter.movement;   // デフォルトを残しておく
        Player.characterMoter.movement = DraggingMovement;  // 設定値を入れる

        // 手の位置を変える
        defaultHandPosition = Player.handGameObject.transform.localPosition;     // デフォルトを残しておく
        Player.handGameObject.transform.localPosition = DraggingHandPosition;    // 設定値を入れる

        // 手に追従する
        transform.parent = Player.handGameObject.transform;
        transform.localPosition = Vector3.zero;
    }

    public override void PutDown()
    {
        base.PutDown();

        // 元に戻す
        Player.characterMoter.movement = defaultMovement;
        Player.handGameObject.transform.localPosition = defaultHandPosition;
        transform.position = springJoint.connectedBody.transform.position + Vector3.up * Player.handGameObject.transform.position.y; // 元々あった持ち手の位置
    }
}
