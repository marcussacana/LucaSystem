using AdvancedBinary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
namespace LucaSystem {
    public class CZ1Parser {
        Pixel[] Pallet = new Pixel[256];
        byte[] Texture;
        public CZ1Parser(byte[] Texture) {
            throw new NotImplementedException();
            this.Texture = Texture;
        }

        public Pixel2[] Decode() {
            throw new NotImplementedException();

            const int PalletOffset = 0xF, TextureBegin = 0x40F;
            for (int i = 0; i < Pallet.Length; i++) {
                Pixel Color = new Pixel();
                Tools.ReadStruct(Texture, ref Color, BaseOffset: PalletOffset + (i*4));
                Pallet[i] = Color;
            }

            var Pixels = new List<Pixel2>();
            for (int i = TextureBegin; i < Texture.Length; i++) {
                Pixel P = Pallet[Texture[i]];
                Pixels.Add(new Pixel2() {
                    A = P.A,
                    R = P.G,
                    G = P.B,
                    B = P.R///????
                });
            }

            return Pixels.ToArray();
        }
    }

    
}
 */