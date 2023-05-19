using UnityEngine;

/* Clase que implementa la interfaz IFactory<Ray> para crear
 * rayos que tengan como origen la posicion del objeto y como
 * direccion el vector right del objeto.
 */

public class RightRayFactory : MonoBehaviour, IFactory<Ray>
{
    public Ray Create()
    {
        return new Ray(transform.position, transform.right);
    }
}
