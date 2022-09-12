using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralRecoil : MonoBehaviour
{
    Vector3 currentRotation, targetRotation, targetPosition, currentPosition, initialGunPosition;
    public Transform cam;

    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;

    [SerializeField] float kickBackZ;

    public float snapiness, returnAmount;

    // Start is called before the first frame update
    void Start()
    {
        initialGunPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
      targetRotation = Vector3.Lerp(targetRotation, Vector3.zero,Time.deltaTime * returnAmount);

      currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * snapiness);

      transform.localRotation = Quaternion.Euler(currentRotation);

      cam.localRotation = Quaternion.Euler(currentRotation);

        KickBack();

    }

    public void Recoil()
    {
        targetPosition -= new Vector3(0, 0, kickBackZ);
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        Debug.Log("REC");
    }

    public void KickBack()
    {
        targetPosition = Vector3.Lerp(targetPosition, initialGunPosition, Time.deltaTime * returnAmount);
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * snapiness);
        transform.localPosition = currentPosition;
    }
}
