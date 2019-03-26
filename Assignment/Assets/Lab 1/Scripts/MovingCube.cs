using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment1
{
    public class MovingCube : MonoBehaviour
    {
        
        public float Speed = 1;
        
        public GameObject target;
        public GameObject Bullet;
        public ParticleSystem muzzleFlash;
        private Rigidbody projectile;
        public float delay;
        private float speed = 50.0f;
        private float force = 1.0f;
        private double lastShot = 0;
        private double muzzleDelay = .1;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            lastShot += Time.deltaTime;
            if (lastShot >= muzzleDelay)
                muzzleFlash.Stop();
            if (target != null && Bullet != null)
            {
                if (Input.GetButton("Fire1")&&lastShot>=delay)
                //if (Input.GetKeyDown(KeyCode.Space))
                {
                    lastShot = 0;

                    GameObject bullet = (GameObject) Instantiate(Bullet, transform.position,
                                        transform.rotation);
                    
                    
                    muzzleFlash.Play();
                    
                    // If the local coordinate systems are not the same you need to rotate
                    // bullets toward the target				
                    // GameObject bullet = (GameObject) Instantiate(Bullet, transform.position, 
                    // Quaternion.LookRotation(relativePosition, Vector3.up));


                    Rigidbody brb = bullet.GetComponent<Rigidbody>();
                    //brb.useGravity = false;

                    brb.velocity = (target.transform.position - transform.position).normalized * speed;
                    //brb.AddForce((OtherCube.transform.position - transform.position).normalized * force);
                    //brb.velocity.Set(brb.velocity.x, 0f, brb.velocity.z);

                    Destroy(bullet, 3);
                }
            }
        }
    }
}
