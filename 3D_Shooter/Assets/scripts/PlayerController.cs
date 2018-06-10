using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]  //обязательное подключение скрипта

public class PlayerController : MonoBehaviour {

    [SerializeField]      // поле speed можно редактировать в инспекторе, но для скрипта оно private
    private float speed = 5f;

	[SerializeField]     
	private float rotSpeed = 5f; //переменная вращения камеры

    private PlayerMotor motor;

    void Start()
    {
		motor = GetComponent<PlayerMotor>() ; //переменная скрипта PlayerMotor

    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

		Vector3 moveHor = transform.right * xMove;
		Vector3 moveVer = transform.forward * zMove;

		Vector3 velosity = (moveHor+moveVer).normalized * speed;

		motor.Move(velosity);
    /*вращение камеры и игрока влево-вправо*/
		float yRot = Input.GetAxisRaw("Mouse X");
		Vector3 rotation = new Vector3 (0f, yRot, 0f) * rotSpeed;
		motor.Rotate (rotation);
	/*вращение камеры вверх-вниз*/
		float xRot = Input.GetAxisRaw("Mouse Y");
		Vector3 camRotation = new Vector3 (xRot, 0f, 0f) * rotSpeed;
		motor.RotateCam (camRotation);
	
	}

}

