using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Week6
{
    public class PlayerController : MonoBehaviour

    {



        [SerializeField] InputAction moveAction;
        [SerializeField] InputAction jumpAction;


        PLayerControllerMappings mappings;
        Rigidbody rb;


        float jumpForce = 0f;
        const float SPEED = 5.5f;

        private InputAction move;
        private InputAction jump;
        private InputAction look;
        private void Awake()
        {
            mappings = new PLayerControllerMappings();
            rb = GetComponent<Rigidbody>();


        }
        private void OnEnable()
        {
            jumpAction = mappings.Player.Jump;
            moveAction.Enable();
            jumpAction.Enable();
            jumpAction.performed += Jump;

        }

        private void OnDisable()
        {
            moveAction = mappings.Player.Move;
            moveAction = mappings.Player.Jump;
            moveAction.Disable();
            jumpAction.Enable();
            jumpAction.performed -= Jump;
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //returns a vector2 with values of the format (x,y) where
            //x represents our input from A and D
            //y represents our input from W and S
            Vector2 input = moveAction.ReadValue<Vector2>();

            input *= SPEED;
            //  transform.position = new Vector3(transform.position.x + input.x
            //     ,transform.position.y
            //   ,transform.position.z + input.y);

            rb.velocity = new Vector3(input.x, rb.velocity.y, input.y);
        }


        bool IsGrounded()
        {
            int layerMask = 1 << 3;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow);
                return true;
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                return false;
            }

        }
        void Jump(InputAction.CallbackContext context)
        {
            if (IsGrounded() == false) return;
            rb.AddForce(Vector3.up * jumpForce);

        }


    }
}
