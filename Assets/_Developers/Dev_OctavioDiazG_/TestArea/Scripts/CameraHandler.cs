using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
   public Transform targetTransform;
   public Transform cameraTransform; 
   public Transform cameraPivotTransform;
   private Transform playerTransform;
   
   
   [SerializeField]
   private Vector3 cameraTransformPosition;
   private LayerMask ignoreLayers;
   private Vector3 cameraFollowVelocity = Vector3.zero;
   
   public static CameraHandler singleton;
   
   public float lookSpeed = 0.1f;
   public float followSpeed = 0.1f;
   public float pivotSpeed = 0.03f;

   private float targetPosition;
   private float defaultPosition; 
   private float lookAngle;
   private float pivotAngle;
   public float minimumPivot = -35;
   public float maximumPivot = 35;
   
   public float cameraSphereRadius = 0.2f;
   public float cameraCollisionOffset = 0.2f; 
   public float minimumCollisionOffset = 0.2f;

   private void Awake()
   {
      singleton = this;
      playerTransform = transform;
      defaultPosition = cameraTransform.localPosition.z;
      //ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);
   }

   private void Start()
   {
      Application.targetFrameRate = 120;
   }

   public void FollowTarget(float delta)
   {
      Vector3 targetPosition = Vector3.SmoothDamp(playerTransform.position, targetTransform.position, ref cameraFollowVelocity, delta / followSpeed);
      playerTransform.position = targetPosition;
      HandleCameraCollisions(delta);  //doesnt work as intended 
   }
    
   public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
   {
      lookAngle += (mouseXInput * lookSpeed) / delta;
      pivotAngle -= (mouseYInput * pivotSpeed) / delta;
      pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);
      
      Vector3 rotation = Vector3.zero;
      rotation.y = lookAngle;
      Quaternion targetRotation = Quaternion.Euler(rotation);
      playerTransform.rotation = targetRotation;
      
      rotation = Vector3.zero;
      rotation.x = pivotAngle;
      targetRotation = Quaternion.Euler(rotation);
      cameraPivotTransform.localRotation = targetRotation;
   }

   private void HandleCameraCollisions(float delta)
   {
      targetPosition = defaultPosition;
      RaycastHit hit;
      Vector3 direction = cameraTransform.position - cameraPivotTransform.position;
      direction.Normalize();
      
      if (Physics.SphereCast(cameraPivotTransform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPosition), ignoreLayers))
      {
         float dis = Vector3.Distance(cameraPivotTransform.position, hit.point);
         targetPosition = -(dis - cameraCollisionOffset);
      }
      
      if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
      {
         targetPosition = -minimumCollisionOffset;
      }
      cameraTransformPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, delta / 0.2f);
      cameraTransformPosition.y = 7.5f;
      cameraTransform.localPosition = cameraTransformPosition;
   }
}
