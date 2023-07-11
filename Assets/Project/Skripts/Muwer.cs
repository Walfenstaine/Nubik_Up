using UnityEngine;
using System.Collections;

public class Muwer : MonoBehaviour {
    public Animator anim;
    public Vector2 rut;
	public Vector3 muve;
	public float sensitivity = 1.1f;
	public Transform cam;
	public float speed = 6.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
    public float spid { get; set; }
    public CharacterController controller { get; set; }
	public static Muwer rid {get; set;}

	void Awake(){
        spid = speed;
		if (rid == null) {
			rid = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		rid = null;
	}

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update() {
        if (controller.isGrounded)
        {
            if (controller.velocity.magnitude > 0.1f)
            {
                anim.SetBool("Run", true);
                anim.SetFloat("Speed", controller.velocity.magnitude / speed);
                Vector3 rutnap = new Vector3(controller.velocity.x,0, controller.velocity.z);
                anim.transform.rotation = Quaternion.Lerp(anim.transform.rotation, Quaternion.LookRotation(rutnap), 10 * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, cam.rotation, 10 * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetFloat("Speed", 1);
            }
            moveDirection = muve;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

        }
        else
        {
            moveDirection.y -= gravity * Time.unscaledDeltaTime;
        }
        cam.transform.Rotate(cam.up * rut.x);
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, 5.5f * Time.deltaTime);
        controller.Move(moveDirection * Time.unscaledDeltaTime);
    }
}
