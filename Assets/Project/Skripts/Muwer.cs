using UnityEngine;
using System.Collections;

public class Muwer : MonoBehaviour {
    public AudioClip land;
    public AudioClip[] jump;
    public Animator anim;
    public Vector2 rut;
	public Vector3 muve;
	public float sensitivity = 1.1f;
	public Transform cam;
	public float speed = 6.0F;
	public float gravity = 20.0F;
    public float jumpSpeed = 10;
    public LayerMask mask;
    private Vector3 moveDirection = Vector3.zero;
    private bool grunded = true;
    public float spid { get; set; }
    public CharacterController controller { get; set; }
	public static Muwer rid {get; set;}

	void Awake(){
        spid = speed;
        cam = GameObject.FindGameObjectWithTag("Soul").transform;
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

    public void Jump()
    {
        Interface.rid.fli = true;
        if (grunded)
        {
            muve.y = jumpSpeed;
            int num = Random.Range(0, jump.Length);
            SoundPlayer.regit.sorse.PlayOneShot(jump[num]);
        }
    }
	void Update() {
        if (controller.enabled)
        {
            anim.SetBool("Jump", !grunded);
            Collider[] serch = Physics.OverlapSphere(anim.transform.position, 0.3f, mask);
            if (serch.Length > 0)
            {
                if (controller.velocity.y < -2)
                {
                    SoundPlayer.regit.sorse.PlayOneShot(land);
                }
                grunded = true;
            }
            else
            {
                grunded = false;
            }
            if (grunded)
            {
                if (controller.velocity.magnitude > 0.1f)
                {
                    anim.SetBool("Run", true);
                    anim.SetFloat("Speed", controller.velocity.magnitude / speed);
                    if (muve.magnitude > 0)
                    {
                        Vector3 rutnap = new Vector3(controller.velocity.x, 0, controller.velocity.z);
                        anim.transform.rotation = Quaternion.Lerp(anim.transform.rotation, Quaternion.LookRotation(rutnap), 10 * Time.deltaTime);
                        transform.rotation = Quaternion.Lerp(transform.rotation, cam.rotation, 10 * Time.deltaTime);
                    }

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
                muve.y = 0;
                moveDirection.y -= gravity * Time.deltaTime;
                if (controller.velocity.y < -20)
                {
                    if (Teleport.rid.position.y > 3)
                    {
                        Interface.rid.Down();
                    }
                }
            }
            cam.transform.Rotate(cam.up * sensitivity * rut.x);
            cam.transform.position = Vector3.Lerp(cam.transform.position, (transform.position + new Vector3(-controller.velocity.x / 2, 0, -controller.velocity.z / 2)), 5.5f * Time.deltaTime);
            controller.Move(moveDirection * Time.unscaledDeltaTime);
        }
        else
        {
            grunded = true;
            anim.SetBool("Run", false);
            //controller.Move(Vector3.zero);
        }
    }
}
