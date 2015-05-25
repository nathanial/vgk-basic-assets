using VGK;

namespace VGKBasicAssets {
  public class Beacon : VoxelDefinition {

    public Beacon(){
      AllImages = "voxels/artificial/beacon/beacon.png";
      Hardness = Hardness.Brittle;
      Material = typeof(BeaconMaterial);
      Drains += new ManaDrain {
        Mana = ManaKind.Any,
        Max = 10.0,
        Min = 0.0,
        Source = ManaZone.Connection
      };
      Emitters += new ManaEmitter {
        Mana = ManaKind.Luxen,
        ValueFunction = (entity, position) => {
          return Drains[0].FindValue(entity, position) * 0.1;
        },
        EmitTo = ManaZone.Ambient
      };
      Light += new Light {
        Color = "#3c76ff",
        IntensityFunction = (entity, position) => {
          return Drains[0].FindValue(entity, position) * 0.25;
        },
        RangeFunction = (entity, position) => {
          return Drains[0].FindValue(entity, position) * 2;
        }
      };
    }
  }
}
