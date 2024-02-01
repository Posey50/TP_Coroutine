using System.Collections;
using UnityEngine;

public class CoroutineScript : MonoBehaviour
{
    /// <summary>
    /// Coroutine of that make the cube rotate.
    /// </summary>
    private Coroutine _rotationRoutine;

    /// <summary>
    /// Speed of the rotation.
    /// </summary>
    [SerializeField]
    private float _rotationSpeed;

    /// <summary>
    /// Called to start the rotation.
    /// </summary>
    public void StartRotation()
    {
        if (_rotationRoutine == null)
        {
            _rotationRoutine = StartCoroutine(Rotation());
        }
    }

    /// <summary>
    /// Called to stop the rotation.
    /// </summary>
    public void StopRotation()
    {
        if (_rotationRoutine != null)
        {
            StopCoroutine(_rotationRoutine);
            _rotationRoutine = null;
        }
    }

    /// <summary>
    /// Waits 5 seconds before to stop the rotation.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Rotation()
    {
        yield return new WaitForSeconds(5f);
        _rotationRoutine = null;
    }

    /// <summary>
    /// Makes the cube rotate while the coroutine is in progress.
    /// </summary>
    private void FixedUpdate()
    {
        if ( _rotationRoutine != null )
        {
            Vector3 rotation = new (0f, _rotationSpeed * Time.deltaTime, 0f);
            transform.Rotate(rotation, Space.World);
        }
    }
}
