using VGK;
using SimplexNoise;
using UnityEngine;
using System;

namespace VGKBasicAssets {
  public class IslandTerrain : TerrainGenerator {
    readonly System.Random _random = new System.Random(0);
    readonly Vector3 _grain0Offset;
    readonly Vector3 _grain1Offset;
    readonly Vector3 _grain2Offset;
    readonly float _bulgeOffset;
    readonly float _distanceCoefficient;

    public IslandTerrain(){
        _grain0Offset = new Vector3(
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0)
        );
        _grain1Offset = new Vector3(
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0)
        );
        _grain2Offset = new Vector3(
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0),
          (float)(_random.NextDouble() * 10000.0)
        );
        _bulgeOffset = 200.0f;
        _distanceCoefficient = 0.0005f;
    }

    public override void CreateVoxels(Chunk chunk){
      var GRASS = Assets.Voxels["Grass"].Block;
      var DIRT = Assets.Voxels["Dirt"].Block;
      var BEACON = Assets.Voxels["Beacon"].Block;

      var i = 0;

      for(var x = 0; x < Chunk.Size; x++){
        for(var y = 0; y < Chunk.Size; y++){
          for(var z = 0; z < Chunk.Size; z++){
            var pos = new Vector3(x,y,z) + chunk.Position.ToVector3();
            var mountainValue = CalculateNoiseValue(pos, _grain0Offset, 0.009f);
            var distanceFromCenter = Mathf.Sqrt(Mathf.Pow(pos.x, 2.0f) + Mathf.Pow(pos.z, 2.0f));
            var bulgeCenter = Mathf.Sqrt(Mathf.Pow(pos.x - _bulgeOffset, 2.0f) + Mathf.Pow(pos.z - _bulgeOffset, 2.0f));

            if(mountainValue < 0){
              mountainValue = 0;
            }

            var maxCenterBulge = 100.0f;
            var bulgeSlope = (float)Math.Pow(bulgeCenter, 1.0) * 0.3f;
            var centerBulge = maxCenterBulge - bulgeSlope;
            if(centerBulge < 0){
              centerBulge = 0;
            }
            var centerBulgePercentage = centerBulge / maxCenterBulge;
            mountainValue *= 35.0f;
            mountainValue += centerBulge;
            mountainValue *= Mathf.Min(1.0f, Mathf.Max(centerBulgePercentage, 0.5f));
            mountainValue += 10.0f;

            mountainValue -= (distanceFromCenter * distanceFromCenter) * _distanceCoefficient;

            mountainValue += CalculateNoiseValue(pos, _grain1Offset, 0.05f) * 2.5f - 1.25f;
            if(mountainValue >= Mathf.Pow(y + chunk.Position.y, 1.0f)){
              if(i % 1000 == 0){
                chunk[x,y,z] = BEACON;
              } else {
                chunk[x,y,z] = GRASS;
              }
              if(y > 0 && (chunk[x,y-1,z] == GRASS || chunk[x,y-1,z] == BEACON)) {
                chunk[x,y-1,z] = DIRT;
              }
            }
            i += 1;
          }
        }
      }
    }
  }
}
