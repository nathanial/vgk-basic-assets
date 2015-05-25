using VGK;

namespace VGKBasicAssets {

  public class BasicAssets : VGKMod {
    public override void Init(){
      var basePath = "/Users/nathanial/Documents/VGK/modules/vgk-basic-assets";
      Assets.Voxels.Add(new Beacon());
      Assets.Voxels.Add(new Dirt());
      Assets.Voxels.Add(new Grass());
      Assets.Voxels.Add(new Stone());
      Assets.Materials["BeaconMaterial"] = new BeaconMaterial(basePath);
      Assets.Materials["StandardMaterial"] = new StandardMaterial(basePath);
    }
  }

}
