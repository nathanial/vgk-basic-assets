using UnityEngine;
using VGK;

namespace VGKBasicAssets {

  public class SpruceTree : VoxelItem {
    public SpruceTree(Entity entity){
      var SPRUCE_LOG = Assets.Voxels["Spruce Log"].Block;
      var SPRUCE_LEAVES = Assets.Voxels["Spruce Leaves"].Block;
      for(var y = 0; y < 10; y++){
        entity[1,y,1] = SPRUCE_LOG;
        if(y > 3){
          for(var x = -1; x < 4; x++){
            for(var z = -1; z < 4; z++){
              if(x == 1 && z == 1){
                continue;
              }
              entity[x,y,z] = SPRUCE_LEAVES;
            }
          }
        }
      }
    }
  }
}
