using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCard {
    public struct Word {
        public int WordId { get; set; }
        public int ImgId { get; set; }
        public string WordName { get; set; }
        public string WordTranslate { get; set; }
        public int Status { get; set; }
        public string Context { get; set; }
    }
}
