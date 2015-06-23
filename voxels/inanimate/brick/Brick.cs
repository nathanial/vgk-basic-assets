using VGK;

namespace VGKBasicAssets {
  public class Brick : VoxelDefinition {
    public Brick(){
      AllImages = "voxels/inanimate/brick/brick.png";
      Hardness = Hardness.Tough;
      Hitpoints = 3;
    }
  }
}
