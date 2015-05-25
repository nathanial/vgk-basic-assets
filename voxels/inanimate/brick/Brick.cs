using VGK;

namespace VGKBasicAssets {
  public class Brick : VoxelDefinition {
    public Brick(){
      AllImages = "voxel/inanimate/brick/brick.png";
      Hardness = Hardness.Tough;
      Hitpoints = 3;
    }
  }
}
