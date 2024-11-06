using UnityEngine;

public class ONFALL : MonoBehaviour
{
    [SerializeField] private Animator[] onfallAnimators; // Array to hold multiple animators
    [SerializeField] private bool fallobject = false;
    [SerializeField] private string fallw = "WWWfall";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fallobject)
            {
                foreach (Animator animator in onfallAnimators) // Loop through each animator
                {
                    animator.Play(fallw, 0, 0.0f); // Play the animation on each animator
                }
                gameObject.SetActive(false);
            }
        }
    }
}
