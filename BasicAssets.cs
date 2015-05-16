using VGK.Modules;

namespace VGKBasicAssets {

  public class BasicAssets : VGKMod {
    public override void Init(){
      new VoxelLoader().LoadVoxels(this.ModFolder);
    }
  }

}
