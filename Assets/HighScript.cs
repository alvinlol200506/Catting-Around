using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HighScript : InteractionTrigger
{
    public Volume volume; // drag Volume dari inspector

    private Vignette vignette;
    private Bloom bloom;
    private ChromaticAberration chromatic;
    private LensDistortion lensDistortion;
    private DepthOfField depthOfField; // Ubah dari DepthOfFieldMode
    int CatnipLick=0;
    LogicScript ls;
    void Start()
    {
        // Ambil reference dari Volume Profile
        if (volume.profile.TryGet(out vignette)) { }
        if (volume.profile.TryGet(out lensDistortion)) { }
        if (volume.profile.TryGet(out depthOfField)) { }
        ls = FindAnyObjectByType<LogicScript>();
    }

    // Contoh ganti stage
    public void OneMoreLick()
    {
        vignette.intensity.value += 0.1f;
        lensDistortion.intensity.value += 0.1f;
        CatnipLick++;

        if (CatnipLick == 8)
        {
            depthOfField.active = true;
            depthOfField.mode.value = DepthOfFieldMode.Gaussian; // Set DOF ke Gaussian
            
        }
    }
    
        public override void InteractTrigger()
    {
        OneMoreLick();
        }


}
