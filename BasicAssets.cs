using VGK;

namespace VGKBasicAssets {

  public class BasicAssets : VGKMod {
    public override void Init(){
      Assets.Voxels.Add(new Beacon());
      Assets.Voxels.Add(new Dirt());
      Assets.Voxels.Add(new Grass());
      Assets.Voxels.Add(new Stone());
    }
  }

}
