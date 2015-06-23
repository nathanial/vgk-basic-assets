using VGK;

namespace VGKBasicAssets {
  public class Clay : VoxelDefinition {
    public Clay(){
      AllImages = "voxels/inanimate/clay/clay.png";
      Hardness = Hardness.Soft;
    }
  }

  public class HardenedClay : VoxelDefinition {
    public HardenedClay(){
      AllImages = "voxels/inanimate/clay/hardened_clay.png";
      Hardness = Hardness.Normal;
      Hitpoints = 2;
    }
  }
}
