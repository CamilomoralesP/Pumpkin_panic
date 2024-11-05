using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destroy the casing object")][SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")][SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")][SerializeField] private float ejectPower = 150f;
    [Tooltip("Tiempo en segundos entre cada disparo")][SerializeField] private float tiempoEntreDisparos = 0.5f;
    [Tooltip("Cantidad máxima de disparos permitidos")][SerializeField] private int disparosMaximos = 15;

    private int disparosActuales = 0; // Inicializa los disparos actuales en 0
    private float ultimoDisparo;
    private float tiempoRecarga = 8f; // Tiempo de espera para recargar
    private bool enRecarga = false; // Controla si el arma está en recarga

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Verifica si se ha hecho clic y si se cumplen las condiciones de tiempo y límite de disparos
        if (Input.GetButtonDown("Fire1") && Time.time - ultimoDisparo >= tiempoEntreDisparos && disparosActuales < disparosMaximos)
        {
            // Llama a la animación de disparo y registra el tiempo y cantidad de disparos
            gunAnimator.SetTrigger("Fire");
            ultimoDisparo = Time.time;
            disparosActuales++;  // Incrementa el contador de disparos
            Shoot();

            // Si alcanza el límite de disparos, inicia la corrutina de recarga
            if (disparosActuales >= disparosMaximos && !enRecarga)
            {
                StartCoroutine(RecargarDisparos());
            }
        }
    }

    // Función de disparo
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            GameObject tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            Destroy(tempFlash, destroyTimer);
        }

        if (!bulletPrefab)
            return;

        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
    }

    // Corrutina para recargar los disparos después de 6 segundos
    private IEnumerator RecargarDisparos()
    {
        enRecarga = true;
        yield return new WaitForSeconds(tiempoRecarga);
        disparosActuales = 0; // Restablece los disparos actuales a 0
        enRecarga = false;
    }

    // Función para crear casquillo en la salida de eyección
    void CasingRelease()
    {
        if (!casingExitLocation || !casingPrefab)
            return;

        GameObject tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation);
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f, 1f);
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCasing, destroyTimer);
    }

    // Función opcional para reiniciar el contador de disparos manualmente
    public void ReiniciarContadorDisparos()
    {
        disparosActuales = 0;
    }
}
