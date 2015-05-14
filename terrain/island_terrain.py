from VGK.Modules import ITerrainGenerator
from VGK import World, Chunk
from SimplexNoise import Noise
from UnityEngine import Random, Vector3, Mathf


class IslandTerrain(ITerrainGenerator):
    def calculate_noise_value(self, pos, offset, scale):
        noise_x = Mathf.Abs((pos.x + offset.x) * scale)
        noise_y = Mathf.Abs((pos.y + offset.y) * scale)
        noise_z = Mathf.Abs((pos.z + offset.z) * scale)
        return Noise.Generate(noise_x, noise_y, noise_z)

    def get_index(self, x, y, z):
        return x * Chunk.Width * Chunk.Height + y * Chunk.Width + z

    def CreateVoxels(self, chunk):
        Random.seed = World.currentWorld.seed
        grain_0_offset = Vector3(Random.value * 10000, Random.value * 10000, Random.value * 10000)
        grain_1_offset = Vector3(Random.value * 10000, Random.value * 10000, Random.value * 10000)
        grain_2_offset = Vector3(Random.value * 10000, Random.value * 10000, Random.value * 10000)

        height_base = 10
        max_height = 50
        height_swing = max_height - height_base

        x = 0
        y = 0
        z = 0

        while x < Chunk.Width:
            while y < Chunk.Height:
                while z < Chunk.Width:
                    pos = Vector3(x,y,z) + chunk.Position.ToVector3()
                    mountain_value = self.calculate_noise_value(pos, grain_0_offset, 0.009)
                    distance_from_center = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.z, 2))

                    if mountain_value < 0:
                        mountain_value = 0

                    mountain_value *= height_swing
                    mountain_value += height_base
                    mountain_value -= Mathf.Pow(distance_from_center, 2) / 1500

                    block_value = self.calculate_noise_value(pos, grain_2_offset, 0.025)
                    block_value *= height_swing
                    block_value += height_base
                    block_Value /= 2

                    if block_value > y + chunk.Position.y:
                        mountain_value += self.calculate_noise_value(pos, grain_2_offset, 0.08) * 5 - 2.5
                        if mountain_value >= y:
                            chunk.Voxels[self.get_index(x,y,z)] = 2
                    else:
                        mountain_value += self.calculate_noise_value(pos, grain_1_offset, 0.05) * 2.5 - 1.25
                        if mountain_value >= y + chunk.Position.y:
                            chunk.Voxels[self.get_index(x,y,z)] = 1
                            if y > 0 and chunk.Voxels[self.get_index(x,y-1,z)] == 1:
                                chunk.Voxels[self.get_index(x,y-1,z)] = 3
                    z += 1
                y += 1
            x += 1
