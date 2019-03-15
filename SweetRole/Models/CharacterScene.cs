using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.Models
{
    public class CharacterScene
    {
        public int CharacterSceneID { get; set; }

        public int? CharacterID { get; set; }
        public virtual Character Character { get; set; }

        public int? SceneID { get; set; }
        public virtual Scene Scene { get; set; }
    }
}
