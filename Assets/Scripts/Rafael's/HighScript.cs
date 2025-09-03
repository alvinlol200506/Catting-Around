using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HighScript : InteractionTrigger
{
    public Volume volume;

    private Vignette vignette;
    private Bloom bloom;
    private ChromaticAberration chromatic;
    private LensDistortion lensDistortion;
    private DepthOfField depthOfField;
    [SerializeField] int CatnipLick = 0;
    LogicScript ls;

    void Start()
    {
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out bloom);
        volume.profile.TryGet(out chromatic);
        volume.profile.TryGet(out lensDistortion);
        volume.profile.TryGet(out depthOfField);
        ls = FindAnyObjectByType<LogicScript>();
    }

    void Update()
    {
        if (CatnipLick >= 5 && lensDistortion != null)
        {
            lensDistortion.intensity.value = Mathf.Sin(Time.time * 2f) * 0.4f;
            if (chromatic != null)
                chromatic.intensity.value = Mathf.Abs(Mathf.Sin(Time.time));
        }
    }

    public void OneMoreLick()
    {
        if (vignette != null)
            vignette.intensity.value += 0.05f;
        if (bloom != null)
            bloom.intensity.value += 0.1f;

        CatnipLick++;

        if (CatnipLick == 8 && depthOfField != null)
        {
            depthOfField.active = true;
            depthOfField.mode.value = DepthOfFieldMode.Gaussian;
        }
    }

    public override void InteractTrigger()
    {
        OneMoreLick();
    }
}
