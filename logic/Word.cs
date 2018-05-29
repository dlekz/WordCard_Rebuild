using System.Data.Linq.Mapping;

namespace logic {
    [Table]
    public class Words {
        [Column(IsPrimaryKey = true)] public int WORD_ID;
        [Column] public int IMG_ID;
        [Column] public string WORD_NAME;
        [Column] public string WORD_TRANSLATE;
        [Column] public int STATUS;
        [Column] public string CONTEXT;
    }
}
